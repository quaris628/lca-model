using System;
using System.IO;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lca_model.db {

    public class FlowProperty {

        public FlowPropertyData data { get; }
        
        public FlowProperty(string filepath) {
            string json = File.ReadAllText(filepath).Replace("@","");
            this.data = JsonSerializer.Deserialize<FlowPropertyData>(json);
        }
        
        public class FlowPropertyData {
            public string context { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public Category category { get; set; }
            public string flowPropertyType { get; set; }
            public UnitGroup unitGroup { get; set; }
            
            // for serialization testing purposes
            public override string ToString() {
                return "\t" + context + "\n\t" + type + "\n\t" + id + "\n\t" + name + " "
                    + version + "\n\t{\n\t\t" + category.ToString() + "\n\t}\n\t"
                    + flowPropertyType + "\n\t{\n\t\t" + unitGroup.ToString() + "\n\t}";
                
            }
        }

        // same as UnitGroup.Category
        public class Category {
            public string type { get; set; }
            public string id  { get; set; }
            public string name  { get; set; }
            public string categoryType  { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                return type + " " + id + " " + name + " " + categoryType;
            }
        }

        public class UnitGroup {
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string[] categoryPath { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                return type + " " + id + " " + name + " ["
                    + string.Join(",", categoryPath) + "]";
            }
        }

        
    }

    
}