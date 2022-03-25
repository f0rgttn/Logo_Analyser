﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logo_Anl
{
    class ML_Main
    {
        public static Stack<string> ML_Hub(Stack<string> Output, string Logo)
        {
            //create a single instance off the sample data 
            ModelInput sampleData = new ModelInput()
            {
                ImageSource = @Logo,
            };

            var prediction = Model_Consumption.Predict(sampleData);

            string first = "Using model to make single prediction -- Comparing actual Label with predicted Label from sample data...\n\n";
            string second = $"ImageSource: {sampleData.ImageSource}";
            string third = $"\n\nPredicted Label value {prediction.Prediction} \nPredicted Label scores: [{String.Join(",", prediction.Score)}]\n\n";
            Output.Push(third);
            Output.Push(second);
            Output.Push(first);
            return Output;
        }
    }
}
