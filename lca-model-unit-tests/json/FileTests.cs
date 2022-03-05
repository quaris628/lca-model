using lca_model.db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace lca_model_unit_tests
{
   [TestClass]
    public class FileTests
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
                "unitGroup2.json",
                "flowProperty1.json",
                "flow1.json",
                "flow2.json",
                "flow3.json"
            };

            foreach (string file in files) {
                Assert.IsTrue(File.Exists(FILE_LOC + file));
            }
        }

    }
}
