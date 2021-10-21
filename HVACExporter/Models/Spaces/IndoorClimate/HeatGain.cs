using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Spaces.IndoorClimate
{
    public class HeatGain
    {
        public PeopleLoad PeopleLoad { get; set; }
        public EquipmentLoad EquipmentLoad { get; set; }
        public LightingLoad LightingLoad { get; set; }
        public ExternalLoad ExternalLoad { get; set; }

        public HeatGain(PeopleLoad peopleLoad, EquipmentLoad equipmentLoad, LightingLoad lightingLoad, ExternalLoad externalLoad)
        {
            PeopleLoad = peopleLoad;
            EquipmentLoad = equipmentLoad;
            LightingLoad = lightingLoad;
            ExternalLoad = externalLoad;
        }
    }
}
