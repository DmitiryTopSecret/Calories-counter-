using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    public class UserController : ControllerBase
    {

        private const string USER_FILE_NAME = "users.dat";
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can't be empty!", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Verification

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        public void Save()  
        {
            Save(USER_FILE_NAME, Users);           
        }     
    }
}
