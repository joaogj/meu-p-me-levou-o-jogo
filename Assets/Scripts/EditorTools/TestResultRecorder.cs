using System.IO;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace MeuPMeLevou.EditorTools
{
    // Records every finished test in Temp/test-results.log and, at the end of the run, writes the summary
    // to Temp/test-results.txt. It registers again on every domain reload, which is what lets a PlayMode
    // run (that reloads the domain when it enters Play Mode) still report its result.
    [InitializeOnLoad]
    internal sealed class TestResultRecorder : ICallbacks
    {
        private const string ModeKey = "MeuPMeLevou.TestRun.Mode";

        static TestResultRecorder()
        {
            var api = ScriptableObject.CreateInstance<TestRunnerApi>();
            api.RegisterCallbacks(new TestResultRecorder());
        }

        public void RunStarted(ITestAdaptor testsToRun)
        {
            SessionState.SetString(ModeKey, testsToRun.TestMode.ToString());
        }

        public void TestStarted(ITestAdaptor test)
        {
        }

        public void TestFinished(ITestResultAdaptor result)
        {
            if (result.HasChildren)
            {
                return;
            }

            string outcome;
            switch (result.TestStatus)
            {
                case TestStatus.Passed:
                    outcome = TestRunSummary.Pass;
                    break;
                case TestStatus.Failed:
                    outcome = TestRunSummary.Fail;
                    break;
                case TestStatus.Skipped:
                    outcome = TestRunSummary.Skip;
                    break;
                default:
                    outcome = TestRunSummary.Inconclusive;
                    break;
            }

            File.AppendAllText(TestRun.LogPath, TestRunSummary.FormatLine(outcome, result.FullName, result.Message) + "\n");
        }

        public void RunFinished(ITestResultAdaptor result)
        {
            string mode = SessionState.GetString(ModeKey, "Unknown");
            string[] lines = File.Exists(TestRun.LogPath) ? File.ReadAllLines(TestRun.LogPath) : new string[0];

            File.WriteAllText(TestRun.SummaryPath, TestRunSummary.Format(mode, result.TestStatus.ToString(), lines));
            File.WriteAllText(TestRun.LogPath, string.Empty);
        }
    }
}
