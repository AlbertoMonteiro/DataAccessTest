using System;

namespace DataAccessTest
{
    public class TestResult
    {
        public TestResult(string title, TimeSpan elapsed)
        {
            Elapsed = elapsed;
            Title = title;
        }

        public TimeSpan Elapsed { get; private set; }
        public string Title { get; private set; }
    }
}
