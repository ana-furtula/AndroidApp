using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidMobileApp.Services
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<SelfExaminationTest> SelfExaminationTests { get; set; } = new List<SelfExaminationTest>();
    }
}
