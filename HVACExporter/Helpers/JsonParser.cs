using HVACExporter.Models.System;
using HVACExporter.Models.Zone;
using HVACExporter.Models.Zones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HVACExporter.Helpers
{
    public class JsonParser
    {
        public static string ParseToJson(Systems systemToParse, List<Materials> materialsToParse, 
            List<Constructions> constructionsToParse, Zones zonesToParse, string userId, string projectId)
        {
            string system = ParseSystemToJson(systemToParse);
            string materials = ParseMaterialsToJson(materialsToParse);
            string constructions = ParseConstructionsToJson(constructionsToParse);
            string zones = ParseZonesToJson(zonesToParse);

            string userIdTag = "\"userID\": ";
            string projectIdTag = "\"projectID\": ";

            string jsonToWebApp = String.Concat("{",
                userIdTag,
                $"\"{userId}\"",
                ",",
                projectIdTag,
                $"\"{projectId}\"",
                ",",
                "\"system\":",
                system,
                ",",
                "\"materials\":",
                materials,
                ",",
                "\"constructions\":",
                constructions,
                ",",
                "\"zones\":",
                zones);

            return jsonToWebApp;
        }

        public static string ParseSystemToJson(Systems systemToParse)
        {
            return JsonConvert.SerializeObject(systemToParse);
        }

        public static string ParseMaterialsToJson(List<Materials> materialsToParse)
        {
            return JsonConvert.SerializeObject(materialsToParse);
        }

        public static string ParseConstructionsToJson(List<Constructions> constructionsToParse)
        {
            return JsonConvert.SerializeObject(constructionsToParse);
        }

        public static string ParseZonesToJson(Zones zonesToParse)
        {
            return JsonConvert.SerializeObject(zonesToParse);
        }


    }
}
