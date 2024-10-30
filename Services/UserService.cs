using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;

namespace Posts_project.Services
{
    public class UserService
    {

        static List<User> UsersData = new List<User>(){
            new User
            {
                Id=214834921,
                Name="Ayala",
                Icon=default,
                Country="Israel",
                Bio="a student of computer programming",
                Email="a83245064@gmail.com",
                Password="1234",
                PhoneNumber="0583245064",
                RegistrationDate=DateTime.Now
            },
            new User
            {
                Id = 1,
                Name = "Alice",
                Email = "alice@example.com",
                Password = "password123",
                PhoneNumber = "1234567890",
                Country = "USA",
                Icon = new byte[] { 0x12, 0x34, 0x56 },
                Bio = "Hello, I'm Alice!",
                RegistrationDate = DateTime.Now
            },
            new User
            {
                Id = 2,
                Name = "Bob",
                Email = "bob@example.com",
                Password = "password456",
                PhoneNumber = "9876543210",
                Country = "Canada",
                Icon = new byte[] { 0xAB, 0xCD, 0xEF },
                Bio = "Hi, I'm Bob!",
                RegistrationDate = DateTime.Now
            }};

        public List<User> Get() => UsersData;
      
        public User GetById(int id) => UsersData.FirstOrDefault(x => x.Id == id);

        public bool AddUser(User user)
        {
            UsersData.Add(user);
            return true;
        }
        public bool Update(int id, User user)
        {
            User existingUserToUpdate = UsersData.FirstOrDefault(x => x.Id == id);
            if (existingUserToUpdate != null)
            {
                existingUserToUpdate.Name = user.Name;
                existingUserToUpdate.Email = user.Email;
                existingUserToUpdate.Password = user.Password;
                existingUserToUpdate.PhoneNumber = user.PhoneNumber;
                existingUserToUpdate.Country = user.Country;
                existingUserToUpdate.Icon = user.Icon;
                existingUserToUpdate.Bio = user.Bio;
                existingUserToUpdate.RegistrationDate = user.RegistrationDate;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return UsersData.Remove(UsersData.FirstOrDefault(x => x.Id == id));
        }

    }
}
