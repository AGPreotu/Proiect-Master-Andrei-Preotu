using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Master_Andrei_Preotu.Models
{
    public class Catel
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Rasa { get; set; }
        public int StapanID {get;set;}
        public Stapan Stapan { get; set; }
        public ICollection<Premiu> Premii { get; set; }
    }
}
