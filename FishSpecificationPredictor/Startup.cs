using FishSpecificationPredictor;
using FishSpecificationPredictor.DataModels;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FishSpecificationPredictor
{
    public class Startup : FunctionsStartup
    {
        private readonly string _modelPath;
        public Startup()
        {
            //Development mode model file access
            _modelPath = Path.Combine(Environment.CurrentDirectory, @"PreTrainedModel\", "fishNamePredictor.zip");
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddPredictionEnginePool<FishDetailsModel, FishSpeciesPredictorModel>()
                .FromFile(modelName: "fishNamePredictor", filePath: _modelPath, watchForChanges: true);
        }
    }
}
