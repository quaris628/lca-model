using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class FlowTests
    {
        private const string FILE_LOC = "../../test-files/";

        [TestMethod]
        public void Flow1()
        {
            string filepath = FILE_LOC + "flow1.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Flow obj = flow;
            Assert.AreEqual("2cd09e69-3272-34b7-8583-947ef73f039c", obj.id);
            Assert.AreEqual("L-2-chloropropionic acid isobutyl ester", obj.name);
            Assert.AreEqual(null, obj.description);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("ELEMENTARY_FLOW", obj.flowType);
            Assert.AreEqual(null, obj.refUnit);
            Assert.AreEqual("083261-15-8", obj.cas);
            Assert.AreEqual(null, obj.formula);
            Assert.AreEqual(false, obj.infrastructureFlow);
        }

        [TestMethod]
        public void Flow1_Location()
        {
            string filepath = FILE_LOC + "flow1.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Location obj = flow.location;
            Assert.AreEqual(null, obj);
        }

        [TestMethod]
        public void Flow1_FlowPropertyFactor0()
        {
            string filepath = FILE_LOC + "flow1.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowPropertyFactor obj = flow.flowProperties[0];
            Assert.AreEqual(true, obj.referenceFlowProperty);
            Assert.AreEqual(1.0f, obj.conversionFactor);
        }

        [TestMethod]
        public void Flow1_FlowPropertyFactor0_FlowProperty()
        {
            string filepath = FILE_LOC + "flow1.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowProperty obj = flow.flowProperties[0].flowProperty;
            Assert.AreEqual("93a60a56-a3c8-11da-a746-0800200b9a66", obj.id);
            Assert.AreEqual("Mass", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void Flow2()
        {
            string filepath = FILE_LOC + "flow2.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Flow obj = flow;
            Assert.AreEqual("00b08f68-2fb1-3f4f-bef3-e6f3f4d70de3", obj.id);
            Assert.AreEqual("Phenol resorcinol formaldehyde resin, at plant", obj.name);
            Assert.AreEqual(null, obj.description);
            Assert.AreEqual("00.00.003", obj.version);
            Assert.AreEqual("2019-09-19T11:47:15.334-06:00", obj.lastChange);
            Assert.AreEqual("PRODUCT_FLOW", obj.flowType);
            Assert.AreEqual(null, obj.refUnit);
            Assert.AreEqual(null, obj.cas);
            Assert.AreEqual(null, obj.formula);
            Assert.AreEqual(false, obj.infrastructureFlow);
        }

        [TestMethod]
        public void Flow2_Category()
        {
            string filepath = FILE_LOC + "flow2.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Category obj = flow.category;
            Assert.AreEqual("fedad44c-774e-361d-a007-8ad332a7e93a", obj.id);
            Assert.AreEqual("3252: Resin, Synthetic Rubber, and Artificial and Synthetic Fibers and Filaments Manufacturing", obj.name);
            Assert.AreEqual("Flow", obj.categoryType);
        }


        [TestMethod]
        public void Flow2_Location()
        {
            string filepath = FILE_LOC + "flow2.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Location obj = flow.location;
            // This location uuid can't be found in either database. * shrug *
            // So just leave the other values blank.
            Assert.AreEqual("b320e7db-c758-3ba6-8839-81eb83c9d7d7", obj.id);
            Assert.AreEqual("Northern America", obj.name);
            Assert.AreEqual(null, obj.description);
            Assert.AreEqual(null, obj.version);
            Assert.AreEqual(null, obj.code);
            Assert.AreEqual(0.0f, obj.latitude);
            Assert.AreEqual(0.0f, obj.longitude);
        }

        [TestMethod]
        public void Flow2_FlowPropertyFactor0()
        {
            string filepath = FILE_LOC + "flow2.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowPropertyFactor obj = flow.flowProperties[0];
            Assert.AreEqual(true, obj.referenceFlowProperty);
            Assert.AreEqual(1.0f, obj.conversionFactor);
        }

        [TestMethod]
        public void Flow2_FlowPropertyFactor0_FlowProperty()
        {
            string filepath = FILE_LOC + "flow2.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowProperty obj = flow.flowProperties[0].flowProperty;
            Assert.AreEqual("93a60a56-a3c8-11da-a746-0800200b9a66", obj.id);
            Assert.AreEqual("Mass", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        [TestMethod]
        public void Flow3()
        {
            string filepath = FILE_LOC + "flow3.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Flow obj = flow;
            Assert.AreEqual("009ab972-c6c1-3200-b646-4152b467bea7", obj.id);
            Assert.AreEqual("Methylcyclopentane", obj.name);
            Assert.AreEqual("From FedElemFlowList_1.0.2. Flow Class: Chemicals. Not a preferred flow.", obj.description);
            Assert.AreEqual("01.00.002", obj.version);
            Assert.AreEqual("2020-04-21T23:12:10.262-06:00", obj.lastChange);
            Assert.AreEqual("ELEMENTARY_FLOW", obj.flowType);
            Assert.AreEqual(null, obj.refUnit);
            Assert.AreEqual("96-37-7", obj.cas);
            Assert.AreEqual("C6H12", obj.formula);
            Assert.AreEqual(false, obj.infrastructureFlow);
        }

        [TestMethod]
        public void Flow3_Category()
        {
            string filepath = FILE_LOC + "flow3.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Category obj = flow.category;
            Assert.AreEqual("377c08bc-8c6e-3536-89ab-ae479326c8d4", obj.id);
            Assert.AreEqual("air", obj.name);
            Assert.AreEqual("Flow", obj.categoryType);
        }

        [TestMethod]
        public void Flow3_Location()
        {
            string filepath = FILE_LOC + "flow3.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            Location obj = flow.location;
            Assert.AreEqual(null, obj);
        }

        [TestMethod]
        public void Flow3_FlowPropertyFactor0()
        {
            string filepath = FILE_LOC + "flow3.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowPropertyFactor obj = flow.flowProperties[0];
            Assert.AreEqual(true, obj.referenceFlowProperty);
            Assert.AreEqual(1.0f, obj.conversionFactor);
        }

        [TestMethod]
        public void Flow3_FlowPropertyFactor0_FlowProperty()
        {
            string filepath = FILE_LOC + "flow3.json";

            Flow flow = JsonInstantiable.Instantiate<Flow>(filepath);

            FlowProperty obj = flow.flowProperties[0].flowProperty;
            Assert.AreEqual("93a60a56-a3c8-11da-a746-0800200b9a66", obj.id);
            Assert.AreEqual("Mass", obj.name);
            Assert.AreEqual("00.00.000", obj.version);
            Assert.AreEqual(null, obj.lastChange);
            Assert.AreEqual("PHYSICAL_QUANTITY", obj.flowPropertyType);
        }

        // TODO add more flow tests, for refUnit
        // I'm having trouble finding any flow that has a refUnit field
    }
}
