using System.Composition;

namespace TestCommon
{
    [Export]
    public class Client
    {
        public int Age { get; set; }
        public int Id { get; set; }
        public long INN { get; set; }
        public string Name { get; set; }
        public string Prof { get; set; }
        public int Stage { get; set; }
    }
}