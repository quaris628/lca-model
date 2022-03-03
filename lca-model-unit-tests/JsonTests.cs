using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class JsonTests
    {
        private const string FILE_LOC = "../../test-files/";

        [TestMethod]
        public void AllTestFilesExist()
        {
                string[] files = {
                "location1.json",
                "location2.json",
                "process1.json",
                "process2.json",
                "unitGroup1.json",
                "unitGroup2.json"
            };

            foreach (string file in files)
            {
            Assert.IsTrue(File.Exists(FILE_LOC + file));
            }
        }

        [TestMethod]
        public void Location1()
        {
            string filepath = FILE_LOC + "location1.json";
         
            Location location = new Location(filepath);

            Assert.AreEqual("0273c379-31a2-34e3-9d4a-351b4c0f4ef2", location.data.id);
            Assert.AreEqual("EU candidate countries 2007", location.data.name);
            Assert.AreEqual("reference location, sources: ILCD", location.data.description);
            Assert.AreEqual("00.00.000", location.data.version);
            Assert.AreEqual("EC-CC2007", location.data.code);
            Assert.AreEqual(0.0f, location.data.latitude);
            Assert.AreEqual(0.0f, location.data.longitude);
            Assert.IsNull(location.data.geometry);
        }

        [TestMethod]
        public void Location2()
        {
            string filepath = FILE_LOC + "location2.json";

            Location location = new Location(filepath);

            Assert.AreEqual("048685d9-6262-3854-82a1-d5bb4a14bc3b", location.data.id);
            Assert.AreEqual("Kuwait", location.data.name);
            Assert.AreEqual("reference location, sources: ISO 3166-1, ecoinvent 3, ILCD, GaBi", location.data.description);
            Assert.AreEqual("00.00.000", location.data.version);
            Assert.AreEqual("KW", location.data.code);
            Assert.AreEqual(29.47f, location.data.latitude);
            Assert.AreEqual(47.37f, location.data.longitude);
            Assert.AreEqual(47.37f, location.data.geometry.coordinates[0]);
            Assert.AreEqual(29.47f, location.data.geometry.coordinates[1]);

        }

        [TestMethod]
        public void UnitGroup1()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = new UnitGroup(filepath);
        }

        [TestMethod]
        public void Process1()
        {
            string filepath = FILE_LOC + "process1.json";
        }

      



    }
}
