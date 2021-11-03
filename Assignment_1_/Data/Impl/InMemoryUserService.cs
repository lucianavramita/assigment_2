using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_1_.Models;

namespace Assignment_1_.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    City = "Horsens",
                    Domain = "via.dk",
                    Password = "123456",
                    Role = "Teacher",
                    BirthYear = 1986,
                    SecurityLevel = 4,
                    UserName = "Troels"
                },
                new User
                {
                    City = "Aarhus",
                    Domain = "hotmail.com",
                    Password = "654321",
                    Role = "Student",
                    BirthYear = 1998,
                    SecurityLevel = 2,
                    UserName = "Jakob"
                }
            }.ToList();
        }
        
        public static async Task<User> validateUser(string userName, string password)
        {
            using HttpClient client = new HttpClient();
            string a = "https://localhost:5001/api/People/"+ userName + "/" + password;
            Console.Write(a);
            HttpResponseMessage responseMessage = await client.GetAsync(a);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.Write(result);
            User user = JsonSerializer.Deserialize<User>
                (result, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return user;
        }

        Task<User> IUserService.validateUser(string userName, string Password)
        {
            return validateUser(userName, Password);
        }
    }
}