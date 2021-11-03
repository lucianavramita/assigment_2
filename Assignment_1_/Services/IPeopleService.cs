using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_1_.Models;


namespace Assigment_1_.Services
{
	public interface IPeopleService
	{
		Task<List<Adult>> GetPeoples();
		Task<Adult> GetAdult(int id);
		Task ModifyAdult(Adult adult);
		Task AddAdult(Adult adult);
		Task DeleteAdult(int id);
	}
}
