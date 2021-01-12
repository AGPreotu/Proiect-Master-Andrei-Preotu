using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Master_Andrei_Preotu.Models
{
    public class Stapan
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta  { get; set; }
        public string NrTelefon { get; set; }
        public ICollection<Catel> Catei { get; set; }

    }
}
