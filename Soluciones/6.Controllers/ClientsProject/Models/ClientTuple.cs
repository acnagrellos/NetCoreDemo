using System.Collections.Generic;

namespace ClientsProject.Models
{
    public class ClientTuple
    {
        public IEnumerable<ClientDto> Items { get; set; }
        public int Count { get; set; }
    }
}
