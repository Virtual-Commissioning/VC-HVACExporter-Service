using Autodesk.Revit.DB;
using System;

namespace HVACExporter.Models.Spaces
{
    public class Space
    {
        public string Id { get; set; }
        public string Tag { get; set; }
        public double HeatingDemand { get; set; }
        public SpaceBoundingBox SpaceBoundingBox { get; set; }

        public Space(string id, string tag, double heatingDemand, SpaceBoundingBox spaceBoundingBox)
        {
            Id = id;
            Tag = tag;
            HeatingDemand = heatingDemand;
            SpaceBoundingBox = spaceBoundingBox;
        }

        public void GetContainedMechanicalElements(Element space)
        {
            throw new NotImplementedException();
        }
    }
}
