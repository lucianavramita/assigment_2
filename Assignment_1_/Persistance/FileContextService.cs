using System.Collections.Generic;
using Assignment_1_.Models;

namespace DefaultNamespace
{
    public interface FileContextService
    {
        List<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int Id);
        void Update(Adult adult);
        Adult Get(int Id);
    }
}