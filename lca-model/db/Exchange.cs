using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
   public class Exchange
   {
      public bool avoidedProduct { get; set; }
      public bool input { get; set; }
      public float amount { get; set; }
      public string description { get; set; }
      public int internalId { get; set; }
      public Process.ProcessData defaultProvider { get; set; }
      public Flow.FlowData flow { get; set; }
      public Unit unit { get; set; }
      public FlowProperty.FlowPropertyData flowProperty { get; set; }
      public bool quantitativeReference { get; set; }
      
   }
}
