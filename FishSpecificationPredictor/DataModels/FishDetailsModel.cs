using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishSpecificationPredictor.DataModels
{
    public class FishDetailsModel
    {
        [Column("Species")]
        public string Species;
        [Column("Weight")]
        public float Weight;
        [Column("Length1")]
        public float Length1;
        [Column("Length2")]
        public float Length2;
        [Column("Length3")]
        public float Length3;
        [Column("Height")]
        public float Height;
        [Column("Width")]
        public float Width;
    }
}
