using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
    public class FlowPropertyFactor
    {
        public bool referenceFlowProperty { get; set; }
        public FlowProperty flowProperty { get; set; }
        // Will I need to change to double instead of float?
        public float conversionFactor { get; set; }
    }
}
