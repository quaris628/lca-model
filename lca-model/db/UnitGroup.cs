using System;
using System.IO;
using System.Collections;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace lca_model.db {

    public class UnitGroup {

        // TODO write unit tests for us json-reading files!
        public UnitGroupData data { get; }
        
        public UnitGroup(string filepath) {
            string json = File.ReadAllText(filepath).Replace("@","");
            this.data = JsonConvert.DeserializeObject<UnitGroupData>(json);
            //this.data = JsonSerializer.Deserialize<UnitGroupData>(json);
        }
        
        public class UnitGroupData {
            public string context { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public Category category { get; set; }
            public Unit[] units { get; set; }
            public FlowProperty defaultFlowProperty { get; set; }
            
            // for serialization testing purposes
            public override string ToString() {
                return "\t" + context + "\n\t" + type + "\n\t" + id + "\n\t" + name + " "
                    + version + "\n\t{\n\t\t" + category.ToString() + "\n\t}\n\t[\n\t\t{"
                    + string.Join("},\n\t\t{", (object[])units)
                    + "\n\t]\n\t" + defaultFlowProperty;
                
            }
        }

        // same as FlowProperty.Category
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

        public class Unit {
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string version { get; set; }
            public float conversionFactor { get; set; }
            public string[] synonyms { get; set; }

            // for serialization testing purposes
            public override string ToString() {
                return type + " " + id + " " + name + " " + description
                    + " " + version + " " + conversionFactor
                    + " [" + (synonyms == null ? "null"
                    : string.Join(",", synonyms)) + "]";
            }
        }

        public class FlowProperty {
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