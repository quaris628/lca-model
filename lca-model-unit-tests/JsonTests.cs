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
        public void AllFilesExist()
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

        [TestMethod]
        public void UnitGroup1()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("93a60a57-a3c8-12da-a746-0800200c9a66", unitGroup.id);
            Assert.AreEqual("Units of volume", unitGroup.name);
            Assert.AreEqual("00.00.000", unitGroup.version);
        }

        [TestMethod]
        public void UnitGroup1_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", unitGroup.category.id);
            Assert.AreEqual("Technical unit groups", unitGroup.category.name);
            Assert.AreEqual("UnitGroup", unitGroup.category.categoryType);
        }

        [TestMethod]
        public void UnitGroup1_Units0()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 0;
            Assert.AreEqual("91995a9e-3cb4-4fc9-a93b-8c618ff9b948", unitGroup.units[index].id);
            Assert.AreEqual("bbl", unitGroup.units[index].name);
            Assert.AreEqual("Barrel (petroleum)", unitGroup.units[index].description);
            Assert.AreEqual("00.00.000", unitGroup.units[index].version);
            Assert.AreEqual(0.15f, unitGroup.units[index].conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units0Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 0;
            Assert.AreEqual(null, unitGroup.units[index].synonyms);
        }

        [TestMethod]
        public void UnitGroup1_Units4()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 4;
            Assert.AreEqual("07973a41-56b3-4e1b-a208-fd75a09fbd4b", unitGroup.units[index].id);
            Assert.AreEqual("cu ft", unitGroup.units[index].name);
            Assert.AreEqual("Cubic feet", unitGroup.units[index].description);
            Assert.AreEqual("00.00.000", unitGroup.units[index].version);
            Assert.AreEqual(0.02f, unitGroup.units[index].conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units4Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 4;
            Assert.AreEqual("cuft", unitGroup.units[index].synonyms[0]);
        }

        [TestMethod]
        public void UnitGroup1_Units10()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 10;
            Assert.AreEqual("df6987d7-afcc-4c92-ae2c-3ce3bc6f5578", unitGroup.units[index].id);
            Assert.AreEqual("ul", unitGroup.units[index].name);
            Assert.AreEqual("Microlitre", unitGroup.units[index].description);
            Assert.AreEqual("00.00.000", unitGroup.units[index].version);
            Assert.AreEqual(1.0E-9f, unitGroup.units[index].conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units10Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            int index = 10;
            Assert.AreEqual("µl", unitGroup.units[index].synonyms[0]);
            Assert.AreEqual("µL", unitGroup.units[index].synonyms[1]);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("93a60a56-a3c8-22da-a746-0800200c9a66", unitGroup.defaultFlowProperty.id);
            Assert.AreEqual("Volume", unitGroup.defaultFlowProperty.name);
            Assert.AreEqual("00.00.000", unitGroup.defaultFlowProperty.version);
            Assert.AreEqual("PHYSICAL_QUANTITY", unitGroup.defaultFlowProperty.flowPropertyType);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("87cfd36b-db77-3a88-8c0e-7102ce682690", unitGroup.defaultFlowProperty.category.id);
            Assert.AreEqual("Technical flow properties", unitGroup.defaultFlowProperty.category.name);
            Assert.AreEqual("FlowProperty", unitGroup.defaultFlowProperty.category.categoryType);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_UnitGroup()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("93a60a57-a3c8-12da-a746-0800200c9a66", unitGroup.defaultFlowProperty.unitGroup.id);
            Assert.AreEqual("Units of volume", unitGroup.defaultFlowProperty.unitGroup.name);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_UnitGroup_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", unitGroup.defaultFlowProperty.unitGroup.category.id);
            Assert.AreEqual("Technical unit groups", unitGroup.defaultFlowProperty.unitGroup.category.name);
        }

    }
}
