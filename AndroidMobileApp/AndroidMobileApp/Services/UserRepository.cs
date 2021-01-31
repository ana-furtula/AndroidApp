using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace AndroidMobileApp.Services
{
    public class LoginManager
    {
        private static LoginManager _instance;
        private LoginManager()
        { }

        public User LoggedUser { get; set; }
        public static LoginManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginManager();
                }

                return _instance;
            }
        }
    }
    class UserRepository
    {
        private static UserRepository _instance;
        private object _lock = new object();
        private List<User> _users = new List<User>();
        private UserRepository()
        {
        }
        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRepository();
                }

                return _instance;
            }
        }
        public bool Exist(User user)
        {
            return _users.Contains(user);
        }

        public User Register(User user)
        {
            if (_users.Contains(user) == true)
                throw new Exception($"User already exist!");

            lock (_lock)
            {
                user.ID = Guid.NewGuid();
                _users.Add(user);
                LoginManager.Instance.LoggedUser = user;
            }

            return user;
        }

        public void Save()
        {
            lock (_lock)
            {
                var filePath = $"{Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fajl.json")}";

                var jsonText = JsonConvert.SerializeObject(_users, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(filePath, jsonText);
            }
        }
        internal void Load()
        {
            lock (_lock)
            {
                var filePath = $"{Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fajl.json")}";

                var jsonText = File.ReadAllText(filePath);

                var usersFromFile = JsonConvert.DeserializeObject<List<User>>(jsonText);

                _users = usersFromFile == null ? new List<User>() : usersFromFile;

            }
        }
        public User GetUserByCredentials(LoginData loginData)
        {
            return _users.FirstOrDefault(x => x.Username == loginData.Username && x.Password == loginData.Password);
        }
    }

}
