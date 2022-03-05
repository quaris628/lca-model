using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace lca_model.db
{
    [Serializable]
    public abstract class JsonInstantiable {
        // TODO have this more easily configurable
        public const string DB_LOC =
                "C:/Users/Public/Documents/Platt 2022 Spring/LCA/combined/";

        private static readonly Dictionary<string, JsonInstantiable> instantiated =
                new Dictionary<string, JsonInstantiable>();
        
        public string id { get; set; }

        public abstract void InstantiateNestedJsonInstantiables();

        public static T Instantiate<T>(string filepath) where T : JsonInstantiable {
            // Read file
            T toReturn = InstantiateNew<T>(filepath);

            // Check if there exists an already instantiated duplicate
            if (instantiated.ContainsKey(toReturn.id)) {
                // If so, substitute it, and we're done
                toReturn = (T)instantiated[toReturn.id];
            } else {
                // If not:
                
                // Register this as already instantiated, for possible future duplicates
                instantiated.Add(toReturn.id, toReturn);

                // Recursively instantiate JsonInstantiables that this references
                // Note that since instantiated.Add comes before, this won't infinitely recurse
                toReturn.InstantiateNestedJsonInstantiables();
            }
            return toReturn;
        }

        protected static T InstantiateNested<T>(string subFolder, string id) where T : JsonInstantiable {
            string filepath = DB_LOC + subFolder + id + ".json";
            return Instantiate<T>(filepath);
        }

        // Only reads the contents of the file, does not do nested references
        private static T InstantiateNew<T>(string filepath) where T : JsonInstantiable {
            // Find file
            if (!File.Exists(filepath)) {
                throw new ArgumentException(filepath + " does not exist");
            }

            // Read json
            string json = File.ReadAllText(filepath).Replace("@", "");
            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
