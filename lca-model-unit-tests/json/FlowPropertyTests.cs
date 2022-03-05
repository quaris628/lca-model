using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class FlowPropertyTests
    {
        private const string FILE_LOC = "../../test-files/";

        [TestMethod]
        public void FlowProperty1()
        {
            string filepath = FILE_LOC + "flowProperty1.json";

            FlowProperty flowProperty = JsonInstantiable.Instantiate<FlowProperty>(filepath);

            FlowProperty obj = flowProperty;
            Assert.AreEqual("22eef182-e237-4903-a10e-5c78eb30b286", obj.id);
            Assert.AreEqual("Beryllium in alloy (E)", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual("2016-04-15T22:56:25-06:00", obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void FlowProperty1_Category()
        {
            string filepath = FILE_LOC + "flowProperty1.json";

            FlowProperty flowProperty = JsonInstantiable.Instantiate<FlowProperty>(filepath);

            Category obj = flowProperty.category;
            Assert.AreEqual("87cfd36b-db77-3a88-8c0e-7102ce682690", obj.id);
            Assert.AreEqual("Technical flow properties", obj.name);
            Assert.AreEqual("FlowProperty", obj.categoryType);
        }

        [TestMethod]
        public void FlowProperty1_UnitGroup()
        {
            string filepath = FILE_LOC + "flowProperty1.json";

            FlowProperty flowProperty = JsonInstantiable.Instantiate<FlowProperty>(filepath);

            UnitGroup obj = flowProperty.unitGroup;
            Assert.AreEqual("93a60a57-a4c8-11da-a746-0800200c9a66", obj.id);
            Assert.AreEqual("Units of mass", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
        }

        [TestMethod]
        public void FlowProperty1_UnitGroup_Category()
        {
            string filepath = FILE_LOC + "flowProperty1.json";

            FlowProperty flowProperty = JsonInstantiable.Instantiate<FlowProperty>(filepath);

            Category obj = flowProperty.unitGroup.category;
            Assert.AreEqual("00d44049-4768-313c-b2a5-c2d545f8e0ec", obj.id);
            Assert.AreEqual("Technical unit groups", obj.name);
            Assert.AreEqual("UnitGroup", obj.categoryType);
        }

    }
}
