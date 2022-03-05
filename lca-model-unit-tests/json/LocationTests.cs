using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class LocationTests
    {
        private const string FILE_LOC = "../../test-files/";

        [TestMethod]
        public void Location1()
        {
            string filepath = FILE_LOC + "location1.json";
         
            Location location = JsonInstantiable.Instantiate<Location>(filepath);

            Assert.AreEqual("0273c379-31a2-34e3-9d4a-351b4c0f4ef2", location.id);
            Assert.AreEqual("EU candidate countries 2007", location.name);
            Assert.AreEqual("reference location, sources: ILCD", location.description);
            Assert.AreEqual("00.00.000", location.version);
            Assert.AreEqual("EC-CC2007", location.code);
            Assert.AreEqual(0.0f, location.latitude);
            Assert.AreEqual(0.0f, location.longitude);
        }

        [TestMethod]
        public void Location1_Geometry()
        {
            string filepath = FILE_LOC + "location1.json";

            Location location = JsonInstantiable.Instantiate<Location>(filepath);

            Assert.IsNull(location.geometry);
        }

        [TestMethod]
        public void Location2()
        {
            string filepath = FILE_LOC + "location2.json";

            Location location = JsonInstantiable.Instantiate<Location>(filepath);

            Assert.AreEqual("048685d9-6262-3854-82a1-d5bb4a14bc3b", location.id);
            Assert.AreEqual("Kuwait", location.name);
            Assert.AreEqual("reference location, sources: ISO 3166-1, ecoinvent 3, ILCD, GaBi", location.description);
            Assert.AreEqual("00.00.000", location.version);
            Assert.AreEqual("KW", location.code);
            Assert.AreEqual(29.47f, location.latitude);
            Assert.AreEqual(47.37f, location.longitude);

            Assert.AreEqual(47.37f, location.geometry.coordinates[0]);
            Assert.AreEqual(29.47f, location.geometry.coordinates[1]);

        }

        [TestMethod]
        public void Location2_Geometry()
        {
            string filepath = FILE_LOC + "location2.json";

            Location location = JsonInstantiable.Instantiate<Location>(filepath);

            Assert.AreEqual(47.37f, location.geometry.coordinates[0]);
            Assert.AreEqual(29.47f, location.geometry.coordinates[1]);

        }


    }
}
