using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTService.Repositories.Interfaces
{
    public interface IClientRepository
    {
        //Task<Models.Client> GetClient(int id);
        //Task UpdateClient(Models.Client client);
        Models.Client GetClient(int id);
        void UpdateClient(Models.Client client);
    }
}
