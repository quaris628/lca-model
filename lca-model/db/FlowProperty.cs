using System;
using System.Collections;
using System.Collections.Generic;

namespace lca_model.db {

    [Serializable]
    public class FlowProperty : JsonInstantiable {

        public const string FOLDER = "flow_properties/";
        
        public string name { get; set; }
        public string version { get; set; }
        // v sometimes null
        public string lastChange { get; set; }
        public Category category { get; set; }
        public string flowPropertyType { get; set; }
        public UnitGroup unitGroup { get; set; }

        public FlowProperty() { }

        public override void InstantiateNestedJsonInstantiables() {
            unitGroup = InstantiateNested<UnitGroup>(UnitGroup.FOLDER, unitGroup.id);
        }

    }

    
}