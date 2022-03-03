using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lca_model.db
{
    public class Location : ReadableFromJson<Location.LocationData>
    {
        private const string FOLDER = "locations/";

        public class LocationData
        {
            private string _id;
            public string id {
                get { return _id; }
                set { _id = value; ReadMyData(_id); }
            }
            public string name { get; set; }
            public string description { get; set; }
            public string version { get; set; }
            public string code { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            // v could be null
            public Point geometry { get; set; }

            private void ReadMyData(string id)
            {
                string filepath = DB_LOC + FOLDER + id + ".json";
                Location duplicate = new Location(filepath);

                name = duplicate.data.name;
                description = duplicate.data.description;
                version = duplicate.data.version;
                code = duplicate.data.code;
                latitude = duplicate.data.latitude;
                longitude = duplicate.data.longitude;
                geometry = duplicate.data.geometry;
            }
        }

        public Location(string filepath) : base(filepath) { }

        
    }
}
