using System;
using System.IO;
using System.Collections;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace lca_model.db {

    public class Flow {

        public FlowData data { get; }
        
        public Flow(string filepath) {
            string json = File.ReadAllText(filepath).Replace("@","");
            this.data = JsonConvert.DeserializeObject<FlowData>(json);
            //this.data = JsonSerializer.Deserialize<FlowData>(json);
        }
        
        public class FlowData {
            public string context { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public Category category { get; set; }
            public string flowType { get; set; }
            public bool infrastructureFlow { get; set; }
            public FlowPropertyFactor[] flowProperties { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                string toReturn = "\t" + context + "\n\t" + type + "\n\t" + id + "\n\t" + name
                    + "\n\t" + version + "\n\t{\n\t\t" + category.ToString() + "\n\t}\n\t"
                    + flowType + "\n\t" + infrastructureFlow + " [";
                foreach (FlowPropertyFactor item in flowProperties) {
                    toReturn += item.ToString() + ",";
                }
                return toReturn + "]";
            }
        }

        public class Category {
            public string type { get; set; }
            public string id  { get; set; }
            public string name  { get; set; }
            public string[] categoryPath  { get; set; }
            public string categoryType  { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                return type + " " + id + " " + name + " ["
                    + string.Join(",", categoryPath) + "] " + categoryType;
            }
        }

        public class FlowPropertyFactor {
            public string type { get; set; }
            public bool referenceFlowProperty { get; set; }
            public FlowProperty flowProperty { get; set; }
            // Will I need to change to double instead of float?
            public float conversionFactor { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                return type + " " + referenceFlowProperty+ " {"
                    + flowProperty.ToString() + "} " + conversionFactor;
            }
        }

        public class FlowProperty {
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string[] categoryPath { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                string toReturn = type + " " + id + " " + name + " [";
                foreach (string item in categoryPath) {
                    toReturn += item + ",";
                }
                return toReturn + "]";
            }
        }
        
    }

    
}