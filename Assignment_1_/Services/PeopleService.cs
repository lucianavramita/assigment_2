using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment_1_.Models;

namespace Assigment_1_.Services
{
	public class PeopleService : IPeopleService
	{

		public async Task<List<Adult>> GetPeoples()
		{
			using HttpClient client = new HttpClient();
			HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/api/People/GetAll");

			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
			string result = await responseMessage.Content.ReadAsStringAsync();

			//Console.Write(result);

			List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>
				(result, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

			return adults;

		}
		
		public async Task<Adult> GetAdult(int id)
		{
			using HttpClient client = new HttpClient();
			string a="https://localhost:5001/api/People/"+ id.ToString();
			//Console.Write(a);
			HttpResponseMessage responseMessage = await client.GetAsync(a);
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
			string result = await responseMessage.Content.ReadAsStringAsync();

			//Console.Write(result);

			Adult adult = JsonSerializer.Deserialize<Adult>
				(result, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
			
			return adult;
		}

		public async Task ModifyAdult(Adult adult)
		{
			using HttpClient client = new HttpClient();
			string AdultAsJson = JsonSerializer.Serialize(adult);
			
			StringContent content = new StringContent(
				AdultAsJson,
				Encoding.UTF8,
				"application/json"
			);
			//Console.Write(AdultAsJson);
			HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:5001/api/People/ModifyAdult",content);
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
			string result = await responseMessage.Content.ReadAsStringAsync();

			//Console.Write(result);
		}
		
		public async Task AddAdult(Adult adult)
		{
			using HttpClient client = new HttpClient();
			string AdultAsJson = JsonSerializer.Serialize(adult);
			
			StringContent content = new StringContent(
				AdultAsJson,
				Encoding.UTF8,
				"application/json"
			);
			//Console.Write(AdultAsJson);
			HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:5001/api/People/AddAdult",content);
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
			string result = await responseMessage.Content.ReadAsStringAsync();

			//Console.Write(result);
		}
		
		public async Task DeleteAdult(int id)
		{
			using HttpClient client = new HttpClient();

			String content = "https://localhost:5001/api/People/DeleteAdult/" + id.ToString();
			//Console.Write(content);
			HttpResponseMessage response = await client.DeleteAsync(content);
			if(!response.IsSuccessStatusCode)
				throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
		}
	}
}
