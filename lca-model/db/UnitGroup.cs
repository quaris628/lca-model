using System;
using System.IO;
using System.Collections;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace lca_model.db {

    public class UnitGroup : ReadableFromJson<UnitGroup.UnitGroupData> {

        
        public class UnitGroupData {
            public string id { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public Category category { get; set; }
            public Unit[] units { get; set; }
            public FlowProperty defaultFlowProperty { get; set; }
            
        }
        
        public UnitGroup(string filepath) : base(filepath) { }
    }

    
}