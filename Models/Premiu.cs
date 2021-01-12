using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Master_Andrei_Preotu.Models
{
    public class Premiu
    {
        public int ID { get; set; }
        public string Nume_Competitie { get; set; }
        public int Loc { get; set; }
        public int Suma { get; set; }
        public int CatelID { get; set; }
        public Catel Catel { get; set; }

    }
}
