using HVACExporter.Models.Spaces;
using HVACExporter.Models.System;
using Newtonsoft.Json;
using System;

namespace HVACExporter.Helpers
{
    public class JsonParser
    {
        public static string ParseToJson(Systems systemToParse, Spaces spacesToParse)
        {
            string system = ParseSystemToJson(systemToParse);
            string spaces = ParseSpacesToJson(spacesToParse);

            (string userId, string projectId) = PromptToken();

            string userIdTag = "\"userID\": ";
            //string userId = "\"6048a6546223802bb0797796\"";
            string projectIdTag = "\"projectID\": ";
            //string projectId = "\"607942d005423f1fb4703b48\"";

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

        public static (string userId, string projectId) PromptToken()
        {
            PromptTokenForm prompt = new PromptTokenForm();

            prompt.ShowDialog();
            string userId = prompt.userId;
            string projectId = prompt.projectId;

            return (userId, projectId);
        }
    }
}
