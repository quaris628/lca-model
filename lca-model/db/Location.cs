using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
    public class Location : JsonInstantiable
    {
        public const string FOLDER = "locations/";
        
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string code { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        // v could be null
        public Point geometry { get; set; }

        public override void InstantiateNestedJsonInstantiables() { }

    }
}
