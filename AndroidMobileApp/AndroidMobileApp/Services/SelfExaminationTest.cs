using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidMobileApp.Services
{
    public enum TestResult
    {
        Positive,
        Negative
    }
    public class SelfExaminationTest
    {
        public string Name { get; set; } = "Self-examination test";
        public Guid UserID { get; set; }
        public DateTime IssueDate { get; set; }
        public bool BeingInContactWithInfected { get; set; }
        public bool Fever { get; set; }
        public bool Cough { get; set; }
        public bool GeneralWeakness { get; set; }
        public bool LossOfSenseOfSmellOrTaste { get; set; }
        public TestResult Result { get; set; }
    }
}
