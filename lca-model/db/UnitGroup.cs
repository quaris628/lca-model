using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace lca_model.db {

    [Serializable]
    public class UnitGroup : JsonInstantiable {

        public const string FOLDER = "unit_groups/";

        public string name { get; set; }
        public string version { get; set; }
        public Category category { get; set; }
        public Unit[] units { get; set; }
        public FlowProperty defaultFlowProperty { get; set; }

        public override void InstantiateNestedJsonInstantiables()
        {
            defaultFlowProperty = (FlowProperty)InstantiateNested<FlowProperty>(FlowProperty.FOLDER, defaultFlowProperty.id);
        }
    }

    
}