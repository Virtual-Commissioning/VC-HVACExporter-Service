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
            List<Constructions> constructionsToParse, Dictionary<string, Site> siteToParse, string userId, string projectId)
        {
            string system = ParseSystemToJson(systemToParse);
            string materials = ParseMaterialsToJson(materialsToParse);
            string constructions = ParseConstructionsToJson(constructionsToParse);
            string site = ParseSiteToJson(siteToParse);

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
                "\"Materials\":",
                materials,
                ",",
                "\"Constructions\":",
                constructions,
                ",",
                "\"BOT\":",
                site);

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

        public static string ParseSiteToJson(Dictionary<string, Site> siteToParse)
        {
            return JsonConvert.SerializeObject(siteToParse);
        }


    }
}
