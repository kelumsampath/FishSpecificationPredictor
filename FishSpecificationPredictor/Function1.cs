using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FishSpecificationPredictor.DataModels;
using Microsoft.Extensions.ML;

namespace FishSpecificationPredictor
{
    public class Function1
    {
        private readonly PredictionEnginePool<FishDetailsModel, FishSpeciesPredictorModel> _predictionEnginePool;


        public Function1(PredictionEnginePool<FishDetailsModel, FishSpeciesPredictorModel> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [FunctionName("fishspecification")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            //Parse HTTP Request Body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            FishDetailsModel data = JsonConvert.DeserializeObject<FishDetailsModel>(requestBody);

            //Make Prediction
            FishSpeciesPredictorModel prediction = _predictionEnginePool.Predict(modelName: "fishNamePredictor", example: data);

            //Convert prediction to string
            string sentiment = prediction.PredictedFishName;

            //Return Prediction
            return (ActionResult)new OkObjectResult(sentiment);
        }
    }
}
