using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assignment_1_.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PeopleController : ControllerBase
	{
        
        public static string text { get; set; } 
        public static List<Adult> adultList { get; set; }
        private List<User> users;
        public PeopleController()
		{
            text = System.IO.File.ReadAllText(@"adultsAPI.json");
            adultList = JsonConvert.DeserializeObject<List<Adult>>(text);
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
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Adult>>> Get()
        {
            List<Adult> adultList = new List<Adult>();
            adultList = JsonConvert.DeserializeObject<List<Adult>>(text);
            return Ok(adultList);
        }

        [HttpGet("{id}")]

        public ActionResult<Adult> GetSingle(int id)
        {
            List<Adult> adultList = new List<Adult>();
            adultList = JsonConvert.DeserializeObject<List<Adult>>(text);
            return Ok(adultList.First(a => a.Id == id));
        }
        
        [HttpGet("{userName}/{password}")] 
        public ActionResult<Adult> ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return Ok(first);
        }

        [HttpPost("AddAdult")]
        public ActionResult<List<Adult>> AddAdult(Adult newAdult)
        {
            int maxId = 0;
            foreach (var  adlt in adultList)
			{
                if (adlt.Id > maxId)
                    maxId = adlt.Id;
			}
            newAdult.Id = maxId+1;
            adultList.Add(newAdult);
            string json = JsonConvert.SerializeObject(adultList);
            System.IO.File.WriteAllText(@"adultsAPI.json", json);
            return Ok(adultList);
        }

        [HttpPut("ModifyAdult")]
        public async void ModifyAdult(Adult MAdult)
        {
            Console.Write(MAdult.FirstName);   
            var index = adultList.FindIndex(c => c.Id == MAdult.Id);
            adultList[index] = MAdult;
            string json = JsonConvert.SerializeObject(adultList);
            System.IO.File.WriteAllText(@"adultsAPI.json", json);
            //return Ok(adultList);
        }

        [HttpDelete("DeleteAdult/{id}")]
        public ActionResult<List<Adult>> deleteAdult(int id)
        {
            //Console.Write("A intrat: "+id.ToString());
            adultList.RemoveAll(c => c.Id == id);
            string json = JsonConvert.SerializeObject(adultList);
            System.IO.File.WriteAllText(@"adultsAPI.json", json);
            return Ok(adultList);
        }

    }
}
