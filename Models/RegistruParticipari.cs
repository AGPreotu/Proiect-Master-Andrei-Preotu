using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Master_Andrei_Preotu.Models
{
    public class RegistruParticipari
    {
        public int ID { get; set; }
        public int CatelID { get; set; }
        public int ConcursID { get; set; }
        public Catel Catel { get; set; }
        public Concurs Concurs { get; set; }
    }
}
