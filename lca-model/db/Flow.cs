
using System;

namespace lca_model.db {

    public class Flow : JsonInstantiable {

        public const string FOLDER = "flows/";

        public string name { get; set; }
        // v could be null
        public string description { get; set; }
        public string version { get; set; }
        // v could be null
        public string lastChange { get; set; }
        public Category category { get; set; }
        public string flowType { get; set; }
        // v could be null v
        public Location location { get; set; }
        public string refUnit { get; set; }
        public string cas { get; set; }
        public string formula { get; set; }
        // ^ could be null ^
        public bool infrastructureFlow { get; set; }
        public FlowPropertyFactor[] flowProperties { get; set; }

        public override void InstantiateNestedJsonInstantiables()
        {
            if (location != null) {
                try {
                    location = InstantiateNested<Location>(Location.FOLDER, location.id);
                } catch (ArgumentException e) {
                    // there is nothing we can do, but it's probably ok
                    // just leave the data as it is
                }
            }
            foreach (FlowPropertyFactor flowPropertyFactor in flowProperties) {
                flowPropertyFactor.flowProperty = InstantiateNested<FlowProperty>(
                        FlowProperty.FOLDER, flowPropertyFactor.flowProperty.id);
            }
        }
    }

    
}