using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidMobileApp.Services
{
    public enum QuickTestResult
    {
        Unknown,
        Negative,
        Positive
    }
    public class QuickTest
    {
        public string Name { get; set; } = "Quick test";
        public Guid UserID { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime CheckedDate { get; set; }
        public TimeSpan CheckedTime { get; set; }
        public QuickTestResult Result { get; set; }
    }
}
