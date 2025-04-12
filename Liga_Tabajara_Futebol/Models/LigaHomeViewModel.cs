using System.Collections.Generic;

namespace Liga_Tabajara_Futebol.Models
{
    public class LigaHomeViewModel
    {
        public string Apresentacao { get; set; }
        public List<Time> Times { get; set; }
        public string StatusLiga { get; set; }
    }
}
