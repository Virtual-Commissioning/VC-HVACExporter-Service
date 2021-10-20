﻿using HVACExporter.Models.Spaces;
using HVACExporter.Models.System;
using Newtonsoft.Json;
using System;

namespace HVACExporter.Helpers
{
    public class JsonParser
    {
        public static string ParseToJson(Systems systemToParse, SpacesInModel spacesToParse)
        {
            string system = ParseSystemToJson(systemToParse);
            string spaces = ParseSpacesToJson(spacesToParse);

            string userIdTag = "\"userID\": ";
            string userId = "\"6048a6546223802bb0797796\"";
            string projectIdTag = "\"projectID\": ";
            string projectId = "\"607942d005423f1fb4703b48\"";

            string jsonToWebApp = String.Concat("{",
                userIdTag,
                userId,
                ",",
                projectIdTag,
                projectId,
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

        public static string ParseSpacesToJson(SpacesInModel spacesToParse)
        {
            return JsonConvert.SerializeObject(spacesToParse);
        }
    }
}