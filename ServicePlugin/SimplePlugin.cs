using System.Collections.Concurrent;
using System.Composition;

namespace TestCommon
{
    [Export(typeof(IPlugin))]
    public class SimplePlugin : IPlugin
    {
        //To be able to work with collection from different threads.
        readonly ConcurrentDictionary<int, Client> _clientsTable;

        public SimplePlugin()
        {
            _clientsTable = new ConcurrentDictionary<int, Client>();

            //Default client
            Client _tempClient = new Client
            {
                Age = 31,
                Id = 1,
                INN = 123456789,
                Name = "Client_Test",
                Prof = "C# Developer",
                Stage = 0
            };

            _clientsTable[_tempClient.Id] = _tempClient;
        }

        public Client GetClient(int id)
        {
            return _clientsTable[id];
        }

        public void UpdateClient(Client client)
        {
            _clientsTable[client.Id] = client;
        }
    }
}
