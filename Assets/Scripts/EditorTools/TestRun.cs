using System.IO;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace MeuPMeLevou.EditorTools
{
    // Starts a test run from code (for example from the unity-mcp) and tells where the result lands.
    // TestResultRecorder writes the summary; the Claude reads SummaryPath after the run.
    public static class TestRun
    {
        public static string SummaryPath => PathInTemp("test-results.txt");

        public static string LogPath => PathInTemp("test-results.log");

        public static void Start(TestMode mode)
        {
            File.WriteAllText(LogPath, string.Empty);
            File.WriteAllText(SummaryPath, "RUNNING\n");

            var api = ScriptableObject.CreateInstance<TestRunnerApi>();
            api.Execute(new ExecutionSettings(new Filter { testMode = mode }));
        }

        private static string PathInTemp(string fileName)
        {
            string projectRoot = Directory.GetParent(Application.dataPath).FullName;
            return Path.Combine(projectRoot, "Temp", fileName);
        }
    }
}
