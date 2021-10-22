using HVACExporter.Models.Spaces;
using HVACExporter.Models.System;
using Newtonsoft.Json;
using System;

namespace HVACExporter.Helpers
{
    public class JsonParser
    {
        public static string ParseToJson(Systems systemToParse, Spaces spacesToParse, string userId, string projectId)
        {
            string system = ParseSystemToJson(systemToParse);
            string spaces = ParseSpacesToJson(spacesToParse);

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
                "\"spaces\":",
                spaces,
                "}");

            return jsonToWebApp;
        }

        public static string ParseSystemToJson(Systems systemToParse)
        {
            return JsonConvert.SerializeObject(systemToParse);
        }

        public static string ParseSpacesToJson(Spaces spacesToParse)
        {
            return JsonConvert.SerializeObject(spacesToParse);
        }

        
    }
}
