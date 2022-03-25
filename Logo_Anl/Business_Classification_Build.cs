using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using System.Windows.Forms;


namespace Logo_Anl
{
    class Business_Classification_Build
    {
        private static string Data_Path = @".\..\..\..\Business_type.tsv";
        private static string Model_Path = @".\..\..\..\Models\MLModel.zip";



        //random seed set for repeatable results across multiple training
        private static MLContext mlContext = new MLContext(seed: 1);

        // Create MLContext to be shared across the model creation workflow objects 
        public Business_Classification_Build()
        {
            //Loading Data
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: Data_Path,
                                            hasHeader: true,
                                            separatorChar: '\t',
                                            allowQuoting: true,
                                            allowSparse: false);

            IEstimator<ITransformer> Training_Pipeline = Training_Pipeline_Builder(mlContext);

            ITransformer mlModel = Train_Model(mlContext, trainingDataView, Training_Pipeline);

            Save_Mod(mlContext, mlModel, Model_Path, trainingDataView.Schema);
        }

        public static IEstimator<ITransformer> Training_Pipeline_Builder(MLContext mlContext)
        {
            //configuration for data process (DP) with pipeline (PL) data transformations
            var DP_PL = mlContext.Transforms.Conversion.MapValueToKey("Label", "Label")
                .Append(mlContext.Transforms.LoadRawImageBytes("ImageSource_featurized", null, "ImageSource")) 
                .Append(mlContext.Transforms.CopyColumns("Features", "ImageSource_featurized"));    //append= create new estimator chain by appending a new estimator chain to end

            //training algorithm
            var train = mlContext.MulticlassClassification.Trainers.ImageClassification(new ImageClassificationTrainer.Options() { LabelColumnName = "Label", FeatureColumnName = "Features" }) //creates classification andd applies column names
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel")); //allows for the conversion of the keys to be mapped to there original state

            EstimatorChain<TransformerChain<Microsoft.ML.Transforms.KeyToValueMappingTransformer>> trainPL = DP_PL.Append(train);

            return trainPL;
        }


        //train the model of business types for later use
        public static ITransformer Train_Model(MLContext mLContext, IDataView trainingDataView, IEstimator<ITransformer> trainPL)
        {
            Console.WriteLine("Training Model");

            ITransformer Business_Models = trainPL.Fit(trainingDataView);

            return Business_Models;
        }

        private static void Save_Mod(MLContext mLContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchem)
        {
            MessageBox.Show("Saving model");
            mlContext.Model.Save(mlModel, modelInputSchem, GetPath(modelRelativePath));
        }

        public static string GetPath(string relativePath)
        {
            FileInfo Data_Root = new FileInfo(typeof(ML_Main).Assembly.Location); //stores file information of ML_Main within Data_Root
            string Assembly_Path = Data_Root.Directory.FullName;  //stores path to the directory for Data_Root within a string

            string Full_Path = Path.Combine(Assembly_Path, relativePath);
            return Full_Path;
        }

        //EVal method is used to cross-validate (CV) single datasets, so to evaluate and get the accuracy metrics of the model
        //Methods from this point onwards are for testing classifier and the user will not have much to do with
        private static void Eval(MLContext mLContext, IDataView trainingDataView, IEstimator<ITransformer> trainPL)
        {
            MessageBox.Show("Cross-validation \n");
            var CV_Results = mLContext.MulticlassClassification.CrossValidate(trainingDataView, trainPL, numberOfFolds: 5, labelColumnName: "Label");
            PrintAvgMetrics(CV_Results);
        }

        //method will print the metrics for the multi class classification
        //MulticlassClassificationMetrics evaluates the results for the multiclass training seen used in method Eval
        public static void PrintMCCmetrics(MulticlassClassificationMetrics metrics) 
        {
            Console.WriteLine("Metrics for the Multi-class classification Model");
            Console.WriteLine($"    MacroAccuracy = {metrics.MacroAccuracy:0.####}, a value between 0 and 1, the closer to 1, the better");
            Console.WriteLine($"    MicroAccuracy = {metrics.MicroAccuracy:0.####}, a value between 0 and 1, the closer to 1, the better");
            Console.WriteLine($"    LogLoss = {metrics.LogLoss:0.####}, the closer to 0, the better");

            for (int i = 0; i < metrics.PerClassLogLoss.Count; i++)
            {
                Console.WriteLine($"    LogLoss for class {i + 1} = {metrics.PerClassLogLoss[i]:0.####}, the closer to 0, the better \n \n");
            }
        }

        //print the average metrics for the multi class classification
        //TrainCatalogBase = Base class for training catalog
        //CrossValidationResult = cross val results, in this case it is the MulticlassClassificationMetrics
        public static void PrintAvgMetrics(IEnumerable<TrainCatalogBase.CrossValidationResult<MulticlassClassificationMetrics>> crossValResults)
        {
            var metricsInMultipleFolds = crossValResults.Select(r => r.Metrics);

            var microAccuracyValues = metricsInMultipleFolds.Select(m => m.MicroAccuracy);
            var microAccuracyAverage = microAccuracyValues.Average();
            var microAccuraciesStdDeviation = CalcStandardDeviation(microAccuracyValues);
            var microAccuraciesConfidenceInterval95 = CalcConfidenceInterval(microAccuracyValues);

            var macroAccuracyValues = metricsInMultipleFolds.Select(m => m.MacroAccuracy);
            var macroAccuracyAverage = macroAccuracyValues.Average();
            var macroAccuraciesStdDeviation = CalcStandardDeviation(macroAccuracyValues);
            var macroAccuraciesConfidenceInterval95 = CalcConfidenceInterval(macroAccuracyValues);

            var logLossValues = metricsInMultipleFolds.Select(m => m.LogLoss);
            var logLossAverage = logLossValues.Average();
            var logLossStdDeviation = CalcStandardDeviation(logLossValues);
            var logLossConfidenceInterval95 = CalcConfidenceInterval(logLossValues);

            var logLossReductionValues = metricsInMultipleFolds.Select(m => m.LogLossReduction);
            var logLossReductionAverage = logLossReductionValues.Average();
            var logLossReductionStdDeviation = CalcStandardDeviation(logLossReductionValues);
            var logLossReductionConfidenceInterval95 = CalcConfidenceInterval(logLossReductionValues);

        }

        //calculates the standard deviation within values using equation of root(square population/size of population)
        public static double CalcStandardDeviation (IEnumerable<double> values)
        {
            double avg = values.Average();

            //calculates the sum of the square differences using
            //the square of (values from population - population mean)
            double SquareDif = values.Select(val => (val - avg)* (val - avg)).Sum();
            double standardDeviation = Math.Sqrt(SquareDif / (values.Count() - 1)); 
            return standardDeviation;
        }

        public static double CalcConfidenceInterval (IEnumerable<double> values)
        {
            //use 1.96 as a constant as the confideqnce interval used is 95
            double confidenceInterval = 1.96 * CalcStandardDeviation(values) / Math.Sqrt((values.Count() - 1));
            return confidenceInterval; //returning confidence interval of 95
        }
    }
}
