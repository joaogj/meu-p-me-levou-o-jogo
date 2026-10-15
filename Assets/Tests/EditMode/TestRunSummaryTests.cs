using MeuPMeLevou.EditorTools;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public class TestRunSummaryTests
    {
        [Test]
        public void Format_CountsEachOutcome()
        {
            string[] lines =
            {
                TestRunSummary.FormatLine(TestRunSummary.Pass, "A.One", ""),
                TestRunSummary.FormatLine(TestRunSummary.Pass, "A.Two", ""),
                TestRunSummary.FormatLine(TestRunSummary.Skip, "A.Three", "ignored"),
                TestRunSummary.FormatLine(TestRunSummary.Inconclusive, "A.Four", ""),
            };

            string summary = TestRunSummary.Format("EditMode", "Passed", lines);

            StringAssert.Contains("mode=EditMode", summary);
            StringAssert.Contains("overall=Passed", summary);
            StringAssert.Contains("total=4", summary);
            StringAssert.Contains("passed=2 failed=0 skipped=1 inconclusive=1", summary);
        }

        [Test]
        public void Format_ListsFailuresWithNameAndMessage()
        {
            string[] lines =
            {
                TestRunSummary.FormatLine(TestRunSummary.Pass, "A.One", ""),
                TestRunSummary.FormatLine(TestRunSummary.Fail, "A.Two", "Expected 1 but was 2"),
            };

            string summary = TestRunSummary.Format("PlayMode", "Failed", lines);

            StringAssert.Contains("passed=1 failed=1", summary);
            StringAssert.Contains("FAIL A.Two :: Expected 1 but was 2", summary);
        }

        [Test]
        public void FormatLine_KeepsEachResultOnOneLine()
        {
            string line = TestRunSummary.FormatLine(TestRunSummary.Fail, "A.Two", "first\r\nsecond\tthird");

            Assert.That(line, Does.Not.Contain("\n"));
            Assert.That(line.Split('\t').Length, Is.EqualTo(3));
        }

        [Test]
        public void Format_WithNoLines_ReportsEmptyRun()
        {
            string summary = TestRunSummary.Format("EditMode", "Passed", new string[0]);

            StringAssert.Contains("total=0", summary);
            StringAssert.Contains("passed=0 failed=0 skipped=0 inconclusive=0", summary);
        }
    }
}
