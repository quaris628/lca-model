using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
    [Serializable]
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string categoryType { get; set; }
    }
}
