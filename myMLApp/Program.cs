﻿using System;
using MyMLAppML.Model.DataModels;
using Microsoft.ML;

namespace MyMLAppML
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
        }

        public static void ConsumeModel()
        {
            //load model
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            //code to add input data
            var input = new ModelInput();
            input.SentimentText = "This is rude.";

            //try model on sample data
            //True is toxic, false is non-toxic
            ModelOutput result = predEngine.Predict(input);

            Console.WriteLine($"Text: {input.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Toxic" : "Non Toxic")} sentiment");
        }
    }
}

//namespace myMLApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ConsumeModel();
//        }

//        public static void ConsumeModel()
//        {
//            // Load the model
//            MLContext mlContext = new MLContext();

//            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

//            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

//            // Use the code below to add input data
//            var input = new ModelInput();
//            input.SentimentText = "Type your sentiment";

//            // Try model on sample data
//            // True is toxic, false is non-toxic
//            ModelOutput result = predEngine.Predict(input);

//            Console.WriteLine($"Text: {input.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Toxic" : "Non Toxic")} sentiment");
//        }
//    }
//}