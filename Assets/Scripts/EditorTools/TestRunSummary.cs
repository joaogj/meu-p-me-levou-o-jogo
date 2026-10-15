using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPMeLevou.EditorTools
{
    // Turns the per-test log lines of a test run into the summary the Claude reads. Pure C#, so it is
    // tested in EditMode. Each log line is "<outcome>\t<full name>\t<message>"; the log is a file because
    // a PlayMode run reloads the domain and anything held in memory would be lost.
    public static class TestRunSummary
    {
        public const string Pass = "PASS";
        public const string Fail = "FAIL";
        public const string Skip = "SKIP";
        public const string Inconclusive = "INCONCLUSIVE";

        private const char Separator = '\t';

        public static string FormatLine(string outcome, string fullName, string message)
        {
            return outcome + Separator + Clean(fullName) + Separator + Clean(message);
        }

        public static string Format(string mode, string overall, IEnumerable<string> logLines)
        {
            int passed = 0;
            int failed = 0;
            int skipped = 0;
            int inconclusive = 0;
            var failures = new StringBuilder();

            foreach (string line in logLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(new[] { Separator }, 3);
                switch (parts[0])
                {
                    case Pass:
                        passed++;
                        break;
                    case Fail:
                        failed++;
                        failures.Append("FAIL ").Append(parts.Length > 1 ? parts[1] : "?");
                        if (parts.Length > 2 && parts[2].Length > 0)
                        {
                            failures.Append(" :: ").Append(parts[2]);
                        }

                        failures.AppendLine();
                        break;
                    case Skip:
                        skipped++;
                        break;
                    default:
                        inconclusive++;
                        break;
                }
            }

            var summary = new StringBuilder();
            summary.AppendLine("mode=" + mode);
            summary.AppendLine("overall=" + overall);
            summary.AppendLine("total=" + (passed + failed + skipped + inconclusive));
            summary.AppendLine($"passed={passed} failed={failed} skipped={skipped} inconclusive={inconclusive}");
            summary.Append(failures);
            return summary.ToString();
        }

        private static string Clean(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text.Replace(Separator, ' ').Replace("\r", " ").Replace("\n", " ").Trim();
        }
    }
}
