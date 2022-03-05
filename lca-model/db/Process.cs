using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
   public class Process// : ReadableFromJson<Process.ProcessData>
   {

      public class ProcessData
      {
         public string id { get; set; }
         public string name { get; set; }
         public string description { get; set; }
         public string version { get; set; }
         public string lastChange { get; set; }
         //public Category category { get; set; }
         public string processType { get; set; }
         public string defaultAllocationMethod { get; set; }
         public bool infrastructureProcess { get; set; }
         public Location location { get; set; }
         //public ProcessDocumentation processDocumentation { get; set; }
         public int lastInternalId { get; set; }
         //public Exchange[] exchanges { get; set; }

      }

        public Process(string filepath) { }// : base(filepath) { }
      

   }
}
