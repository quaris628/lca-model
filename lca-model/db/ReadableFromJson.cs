using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lca_model.db
{
    public class ReadableFromJson<T>
    {
        // TODO have these more easily configurable
        protected const string DB_LOC =
                "C:/Users/Public/Documents/Platt 2022 Spring/LCA/combined/";

        public readonly T data;

        public ReadableFromJson(string filepath)
        {
            string json = File.ReadAllText(filepath).Replace("@", "");
            data = JsonConvert.DeserializeObject<T>(json);
        }
    }
}
