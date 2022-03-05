using HVACExporter.Models.Zone;

namespace HVACExporter.Helpers.ZoneMappers.InternalGainsMappers
{
    public class BuildingShadingMapper
    {
        public static ShadingBuilding MapBuildingShading(Autodesk.Revit.DB.Mechanical.Space associatedSpace)
        {
            //Figure out how this should be made. What should define the shading zones on the site? Add to SelectAllFlowSystens later.
            string id = "Shading_Building";
            string transmSchedule = "NA";
            VertexCoordinates vertexCoordinates = null;

            ShadingBuilding shadingBuilding = new ShadingBuilding(id, transmSchedule, vertexCoordinates);
            return shadingBuilding;
        }
    }
}
