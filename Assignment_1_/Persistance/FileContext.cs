using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment_1_.Models;
using DefaultNamespace;

namespace FileData
{
    public class FileContext : FileContextService
    {
        //public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }
        public int Id = 14;

        //private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            //Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public List<Adult> GetAdults()
        {
            List<Adult> adults = new List<Adult>(Adults);
            return adults;
        }

        public void AddAdult(Adult adult)
        {
            Id++;
            adult.Id = Id;
            Adults.Add(adult);
            SaveChanges();
        }

        public void RemoveAdult(int Id)
        {
            Adult ToRemove = Adults.First(a => a.Id == Id);
            Adults.Remove(ToRemove);
            SaveChanges();
        }

        public void Update(Adult adult)
        {
            Adult adultToUpdate = Adults.First(a => a.Id == adult.Id);
            adultToUpdate.LastName = adult.LastName;
            SaveChanges();
        }

        public Adult Get(int Id)
        {
            return Adults.FirstOrDefault(a => a.Id == Id);
        }
    }
}
