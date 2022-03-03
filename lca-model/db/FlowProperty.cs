using System;
using System.Collections;
using System.Collections.Generic;

namespace lca_model.db {

    public class FlowProperty : ReadableFromJson<FlowProperty.FlowPropertyData> {

        private const string FOLDER = "flow_properties/";

        private static Dictionary<string, FlowPropertyData> instantiatedFlows =
            new Dictionary<string, FlowPropertyData>();
        
        public class FlowPropertyData {
            private string _id;
            public string id { 
                get { return _id; }
                set {
                    _id = value;
                    if (instantiatedFlows.ContainsKey(_id))
                    {
                        CopyData(instantiatedFlows[_id]);
                    } else {
                        string filepath = DB_LOC + FOLDER + id + ".json";
                        FlowProperty source = new FlowProperty(filepath);
                        CopyData(source.data);
                    }
                    instantiatedFlows.Add(_id, this);
                }
            }
            public string name { get; set; }
            public string version { get; set; }
            public Category category { get; set; }
            public string flowPropertyType { get; set; }
            public UnitGroup unitGroup { get; set; }
            
            private void CopyData(FlowPropertyData source)
            {
                name = source.name;
                version = source.version;
                category = source.category;
                flowPropertyType = source.flowPropertyType;
                unitGroup = source.unitGroup;
            }
        }

        public FlowProperty(string filepath) : base(filepath) { }


    }

    
}