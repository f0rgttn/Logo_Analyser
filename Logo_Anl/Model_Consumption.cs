using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Logo_Anl
{ 
    class Model_Consumption
    {
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);


        public static ModelOutput Predict(ModelInput input)
        {
           ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            MLContext mLCon = new MLContext();

            //load model
            string mod_Path = string.Format(@"C:\Users\Thom\Documents\sixth form\Computer science\Thom Johnson NEA\NEA\C#\UI\Models\MLModel.zip\schema");
            ITransformer mlModel = mLCon.Model.Load(mod_Path, out var modelInputSchema);
            //create the prediction engine 
            var predengine = mLCon.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            return predengine;
        }
    }

    class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public String Prediction { get; set; }
        public float[] Score { get; set; }
    }

    class ModelInput
    {
        //in Business_type.tsv label is the business types that I have provided
        [ColumnName("Label"), LoadColumn(0)]
        public string Label { get; set; }


        //in Business_type.tsv ImageSource is the path to each individual logo that I habe provided
        [ColumnName("ImageSource"), LoadColumn(1)]
        public string ImageSource { get; set; }

    }
}
