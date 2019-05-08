namespace TestCommon
{
    public interface IPlugin
    {
        Client GetClient(int id);
        void UpdateClient(Client client);
    }
}
