using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class UnitGroupTests
    {
        private const string FILE_LOC = "../../test-files/";

        [TestMethod]
        public void UnitGroup1()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            UnitGroup obj = unitGroup;
            Assert.AreEqual("93a60a57-a3c8-12da-a746-0800200c9a66", obj.id);
            Assert.AreEqual("Units of volume", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
        }

        [TestMethod]
        public void UnitGroup1_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.category;
            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", obj.id);
            Assert.AreEqual("Technical unit groups", obj.name);
            Assert.AreEqual("UnitGroup", obj.categoryType);
        }

        [TestMethod]
        public void UnitGroup1_Units0()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[0];
            Assert.AreEqual("91995a9e-3cb4-4fc9-a93b-8c618ff9b948", obj.id);
            Assert.AreEqual("bbl", obj.name);
            Assert.AreEqual("Barrel (petroleum)", obj.description);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(0.15f, obj.conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units0Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[0];
            Assert.AreEqual(null, obj.synonyms);
        }

        [TestMethod]
        public void UnitGroup1_Units4()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[4];
            Assert.AreEqual("07973a41-56b3-4e1b-a208-fd75a09fbd4b", obj.id);
            Assert.AreEqual("cu ft", obj.name);
            Assert.AreEqual("Cubic feet", obj.description);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(0.02f, obj.conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units4Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            string[] obj = unitGroup.units[4].synonyms;
            Assert.AreEqual("cuft", obj[0]);
        }

        [TestMethod]
        public void UnitGroup1_Units10()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[10];
            Assert.AreEqual("df6987d7-afcc-4c92-ae2c-3ce3bc6f5578", obj.id);
            Assert.AreEqual("ul", obj.name);
            Assert.AreEqual("Microlitre", obj.description);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(false, obj.referenceUnit);
            Assert.AreEqual(1.0E-9f, obj.conversionFactor);
        }

        [TestMethod]
        public void UnitGroup1_Units10Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            string[] obj = unitGroup.units[10].synonyms;
            Assert.AreEqual("µl", obj[0]);
            Assert.AreEqual("µL", obj[1]);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            FlowProperty obj = unitGroup.defaultFlowProperty;
            Assert.AreEqual("93a60a56-a3c8-22da-a746-0800200c9a66", obj.id);
            Assert.AreEqual("Volume", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.defaultFlowProperty.category;
            Assert.AreEqual("87cfd36b-db77-3a88-8c0e-7102ce682690", obj.id);
            Assert.AreEqual("Technical flow properties", obj.name);
            Assert.AreEqual("FlowProperty", obj.categoryType);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_UnitGroup()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            UnitGroup obj = unitGroup.defaultFlowProperty.unitGroup;
            Assert.AreEqual("93a60a57-a3c8-12da-a746-0800200c9a66", obj.id);
            Assert.AreEqual("Units of volume", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_UnitGroup_Category()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.defaultFlowProperty.unitGroup.category;
            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", obj.id);
            Assert.AreEqual("Technical unit groups", obj.name);
            Assert.AreEqual("UnitGroup", obj.categoryType);
        }

        [TestMethod]
        public void UnitGroup1_Equals_DefaultFlowProperty_UnitGroup()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual(unitGroup, unitGroup.defaultFlowProperty.unitGroup);
        }

        [TestMethod]
        public void UnitGroup1_DefaultFlowProperty_Equals_DefaultFlowProperty_UnitGroup_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup1.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual(unitGroup.defaultFlowProperty, unitGroup.defaultFlowProperty.unitGroup.defaultFlowProperty);
        }

        [TestMethod]
        public void UnitGroup2()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            UnitGroup obj = unitGroup;
            Assert.AreEqual("36932b14-ba61-417b-a80c-eb9935d193f1", obj.id);
            Assert.AreEqual("Units of length*area", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
        }

        [TestMethod]
        public void UnitGroup2_Category()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.category;
            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", obj.id);
            Assert.AreEqual("Technical unit groups", obj.name);
            Assert.AreEqual("UnitGroup", obj.categoryType);
        }

        [TestMethod]
        public void UnitGroup2_Units0()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[0];
            Assert.AreEqual("0dc79b8e-47a1-4ec7-96b1-c9b9da2769fa", obj.id);
            Assert.AreEqual("mm*m2", obj.name);
            Assert.AreEqual("Millimetre times square metre", obj.description);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(true, obj.referenceUnit);
            Assert.AreEqual(1.0f, obj.conversionFactor);
        }

        [TestMethod]
        public void UnitGroup2_Units0Synonyms()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Unit obj = unitGroup.units[0];
            Assert.AreEqual(null, obj.synonyms);
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            FlowProperty obj = unitGroup.defaultFlowProperty;
            Assert.AreEqual("45915a2c-6ee8-45bd-8a46-070a7261558e", obj.id);
            Assert.AreEqual("Groundwater Replenishment (Occ.)", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty_Category()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.defaultFlowProperty.category;
            Assert.AreEqual("87cfd36b-db77-3a88-8c0e-7102ce682690", obj.id);
            Assert.AreEqual("Technical flow properties", obj.name);
            Assert.AreEqual("FlowProperty", obj.categoryType);
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty_UnitGroup()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            UnitGroup obj = unitGroup.defaultFlowProperty.unitGroup;
            Assert.AreEqual("36932b14-ba61-417b-a80c-eb9935d193f1", obj.id);
            Assert.AreEqual("Units of length*area", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty_UnitGroup_Category()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Category obj = unitGroup.defaultFlowProperty.unitGroup.category;
            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", obj.id);
            Assert.AreEqual("Technical unit groups", obj.name);
            Assert.AreEqual("UnitGroup", obj.categoryType);
            
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty_UnitGroup_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            FlowProperty obj = unitGroup.defaultFlowProperty.unitGroup.defaultFlowProperty;
            Assert.AreEqual("45915a2c-6ee8-45bd-8a46-070a7261558e", obj.id);
            Assert.AreEqual("Groundwater Replenishment (Occ.)", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void UnitGroup2_Equals_DefaultFlowProperty_UnitGroup()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual(unitGroup, unitGroup.defaultFlowProperty.unitGroup);
        }

        [TestMethod]
        public void UnitGroup2_DefaultFlowProperty_Equals_DefaultFlowProperty_UnitGroup_DefaultFlowProperty()
        {
            string filepath = FILE_LOC + "unitGroup2.json";

            UnitGroup unitGroup = JsonInstantiable.Instantiate<UnitGroup>(filepath);

            Assert.AreEqual(unitGroup.defaultFlowProperty, unitGroup.defaultFlowProperty.unitGroup.defaultFlowProperty);
        }

    }
}
