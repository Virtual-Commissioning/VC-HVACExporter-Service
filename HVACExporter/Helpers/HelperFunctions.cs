using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers
{
    class HelperFunctions
    {
        public static FilteredElementCollector GetConnectorElements(Document doc)
        {
            // what categories of family instances
            // are we interested in?

            BuiltInCategory[] bics = new BuiltInCategory[] {
                BuiltInCategory.OST_DuctFitting,
                BuiltInCategory.OST_DuctTerminal,
                //BuiltInCategory.OST_DuctCurves,
                BuiltInCategory.OST_DuctAccessory,
                BuiltInCategory.OST_MechanicalEquipment,
                BuiltInCategory.OST_PipeFitting,
                BuiltInCategory.OST_PlumbingFixtures,
                BuiltInCategory.OST_PipeAccessory
                //BuiltInCategory.OST_SpecialityEquipment,
                //BuiltInCategory.OST_Sprinklers
            };

            IList<ElementFilter> a = new List<ElementFilter>(bics.Count());

            foreach (BuiltInCategory bic in bics)
            {
                a.Add(new ElementCategoryFilter(bic));
            }

            LogicalOrFilter categoryFilter
              = new LogicalOrFilter(a);

            LogicalAndFilter familyInstanceFilter
                = new LogicalAndFilter(categoryFilter,
                new ElementClassFilter(typeof(FamilyInstance)));

            IList<ElementFilter> b
              = new List<ElementFilter>(6);

            b.Add(new ElementClassFilter(typeof(Duct)));
            b.Add(new ElementClassFilter(typeof(Pipe)));

            b.Add(familyInstanceFilter);

            LogicalOrFilter classFilter
              = new LogicalOrFilter(b);

            FilteredElementCollector collector
              = new FilteredElementCollector(doc);


            collector.WherePasses(classFilter);

            return collector;
        }

    }
}
