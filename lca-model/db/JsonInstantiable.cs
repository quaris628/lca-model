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

        public bool IsDuplicate() {
            return instantiated.ContainsKey(id);
        }

        public static T Instantiate<T>(string filepath) where T : JsonInstantiable
        {
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

        protected static JsonInstantiable InstantiateNested<T>(string subFolder, string id) where T : JsonInstantiable {
            string filepath = DB_LOC + subFolder + id + ".json";
            return Instantiate<T>(filepath);
        }

        // Only reads the contents of the file, does not do nested references
        private static T InstantiateNew<T>(string filepath) where T : JsonInstantiable {
            // Find file
            if (!File.Exists(filepath))
            {
                throw new ArgumentException(filepath + " does not exist");
            }

            // Read json
            string json = File.ReadAllText(filepath).Replace("@", "");
            return JsonConvert.DeserializeObject<T>(json);
        }


        // Returns the original instantiation if this is a duplicate,
        // otherwise returns this
        /*
        public JsonInstantiable GetNonDuplicateInstantiation<T>() where T : JsonInstantiable {
            if (instantiated.ContainsKey(id)) {
                // if I have an already-instantiated twin
                return instantiated[id];
            } else {
                // If I don't have a duplicate instantiation
                return this;
                
                T toReturn = InstantiateNewFromId<T>(id);
                
                return toReturn;
            }
        }*/

        /*
        private void OnSetId() {
            if (instantiated.ContainsKey(_id)) {
                // if I have an already-instantiated twin
                duplicate = instantiated[_id];
                // later GetDuplicate() be used to find my twin
            } else if (!instantiating.ContainsKey(_id)) {
                // If I don't have a duplicate instantiation and
                // I am getting constructed because another file references me

                instantiating.Add(_id, this);
                // Find my file and read my data from it
                string filepath = DB_LOC + subFolder + id + ".json";
                T source = JsonReader.ConstructFromJson<T>(filepath);
                CopyFrom(source);
                instantiating.Remove(_id);
                instantiated.Add(_id, this);
            } else if (!allowNestedInstantiation.Contains(_id)) {
                // If I am getting constructed inside the ConstructFromJson method in the line above
                allowNestedInstantiation.Add(_id);
            } else {
                // If I am being referenced by another object found during my construction
                //     in the ConstructFromJson line above

                // Refer the caller to the not-yet-complete twin that is currently being instantiated
                duplicate = instantiating[_id];
                // NOPE!
                // TODO
                // saying this object is a duplicate won't do anything when
                // ConstructFromJson was called for the object this is contained within
            }
            
        }
        

        public bool IsDuplicate() { return duplicate != null; }
        public IJsonInstantiable GetDuplicate() { return duplicate; }

        protected abstract void CopyFrom(T source);
        //*/

    }
}
