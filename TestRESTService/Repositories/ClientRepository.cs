using TestCommon;
using TestRESTService.Repositories.Interfaces;

namespace TestRESTService.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly IPlugin _plugin;

        public ClientRepository(IPlugin plugin)
        {
            _plugin = plugin;
        }

        public Models.Client GetClient(int id)
        {
            Client tcClient = _plugin.GetClient(id);

            return new Models.Client
            {
                Age = tcClient.Age,
                Id = tcClient.Id,
                Name = tcClient.Name,
                Stage = tcClient.Stage
            };
        }

        public void UpdateClient(Models.Client client)
        {
            //We have to get TestCommon.Client first, cause our Controller works only with Models.Client.
            Client tcClient = _plugin.GetClient(client.Id);

            tcClient.Age = client.Age;
            tcClient.Name = client.Name;
            tcClient.Stage = client.Stage;

            _plugin.UpdateClient(tcClient);
        }
    }
}
