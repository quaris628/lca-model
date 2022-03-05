using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lca_model.db
{
    public class JsonReader
    {
        private JsonReader() { }
        /*
        public static T ConstructFromJson<T>(string filepath) where T : JsonInstantiable
        {
            if (!File.Exists(filepath)) {
                throw new ArgumentException(filepath + " does not exist");
            }

            // read json file
            string json = File.ReadAllText(filepath).Replace("@", "");
            T toReturn = JsonConvert.DeserializeObject<T>(json);
            
            // I know type checking isn't the best, but I don't see a better design
            if (toReturn is JsonInstantiable j) {
                if (j.IsDuplicate()) {
                    // set toReturn to the original instantiation
                    toReturn = (T)j.GetNonDuplicateInstantiation<T>();
                } else {
                    // instantiate fields that reference other files
                    toReturn.InstantiateNestedJsonInstantiables();
                }
            }
            return toReturn;
        }
        //*/
    }
}
