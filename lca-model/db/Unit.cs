using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
    [Serializable]
    public class Unit
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public float conversionFactor { get; set; }
        // v sometimes null
        public bool referenceUnit { get; set; }
        // v sometimes null
        public string[] synonyms { get; set; }

    }
}
