using Microsoft.ML.Data;

namespace FishSpecificationPredictor.DataModels
{
    public class FishSpeciesPredictorModel
    {
        [ColumnName("PredictedLabel")]
        public string PredictedFishName { get; set; }
    }
}
