using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect_Master_Andrei_Preotu.Models;

namespace Proiect_Master_Andrei_Preotu.Data
{
    public class DbInitializer
    {
        public static void Initialize(DogShowContext context)
        {
            context.Database.EnsureCreated();
            if (context.Catei.Any())
            {
                return; // BD a fost creata anterior
            }

            var stapani = new Stapan[]
            {

 new Stapan{Nume="Doe",Prenume="John",Varsta=25, NrTelefon="0745896321"},
 new Stapan{Nume="Peterson",Prenume="Emily",Varsta=30, NrTelefon="0745896881"},
 new Stapan{Nume="Fitzgerald",Prenume="Doug",Varsta=16, NrTelefon="0789216541"},
 new Stapan{Nume="Preotu",Prenume="Andrei",Varsta=22,NrTelefon="0721453689"},
  new Stapan{Nume="Virlan",Prenume="Diana",Varsta=22,NrTelefon="0721453782"}
 };
            foreach (Stapan s in stapani)
            {
                context.Stapani.Add(s);
            }
            context.SaveChanges();

            var catei = new Catel[]
            {
    new Catel{Nume="Azorel",Rasa="Bichon Maltez",StapanID=1 },
    new Catel{Nume="Bella",Rasa="Yorkshire Terrier",StapanID=2 },
    new Catel{Nume="Rex",Rasa="Ciobanesc German",StapanID=3 },
    new Catel{Nume="Sparky",Rasa = "Pitbull",StapanID = 3 },
    new Catel{Nume="Dop",Rasa="Golden Retriever",StapanID=4 },
    new Catel{Nume="Boop",Rasa="Labrador",StapanID=5 },
    new Catel{Nume="Cola",Rasa="Pudel",StapanID=5 }
            };
            foreach (Catel c in catei)
            {
                context.Catei.Add(c);
            }
            context.SaveChanges();


            var premii = new Premiu[]
            {
    new Premiu{Nume_Competitie="Extravagant Dog Show", Loc=1, Suma=1000, CatelID=1},
    new Premiu{Nume_Competitie="Extravagant Dog Show", Loc=2, Suma=500, CatelID=2},
    new Premiu{Nume_Competitie="Extravagant Dog Show", Loc=3, Suma=200, CatelID=3},
    new Premiu{Nume_Competitie="Woof Woof Academy", Loc=1, Suma=1000, CatelID=4},
    new Premiu{Nume_Competitie="Woof Woof Academy", Loc=2, Suma=500, CatelID=2},
    new Premiu{Nume_Competitie="Woof Woof Academy", Loc=3, Suma=200, CatelID=1},
    new Premiu{Nume_Competitie="Cateliada", Loc=1, Suma=1000, CatelID=5},
    new Premiu{Nume_Competitie="Cateliada", Loc=2, Suma=500, CatelID=6},
    new Premiu{Nume_Competitie="Cateliada", Loc=3, Suma=200, CatelID=7},
    new Premiu{Nume_Competitie="Competita Canina", Loc=1, Suma=1000, CatelID=4},
    new Premiu{Nume_Competitie="Competita Canina", Loc=2, Suma=500, CatelID=3},
    new Premiu{Nume_Competitie="Competita Canina", Loc=3, Suma=200, CatelID=5}
            };
            foreach (Premiu p in premii)
            {
                context.Premii.Add(p);
            }
            context.SaveChanges();

            var Concursri = new Concurs[]
           {
           new Concurs{Nume="Extravagant Dog Show", Locatie="Cluj-Napoca"},
           new Concurs{Nume="Woof Woof Academy", Locatie="Bucuresti"},
           new Concurs{Nume="Cateliada", Locatie="Sibiu"},
           new Concurs{Nume="Competita Canina", Locatie="Cluj-Napoca"},
};
            foreach (Concurs c in Concursri)
            {
                context.Concursuri.Add(c);
            }
            context.SaveChanges();

          var RegistreParticipari = new RegistruParticipari[]
            {

 new RegistruParticipari{CatelID=1,ConcursID=1},
 new RegistruParticipari{CatelID=1,ConcursID=2},
 new RegistruParticipari{CatelID=1,ConcursID=3},
 new RegistruParticipari{CatelID=1,ConcursID=4},
 new RegistruParticipari{CatelID=2,ConcursID=1},
 new RegistruParticipari{CatelID=2,ConcursID=2},
 new RegistruParticipari{CatelID=2,ConcursID=3},
 new RegistruParticipari{CatelID=2,ConcursID=4},
 new RegistruParticipari{CatelID=3,ConcursID=1},
 new RegistruParticipari{CatelID=4,ConcursID=2},
 new RegistruParticipari{CatelID=4,ConcursID=3},
 new RegistruParticipari{CatelID=4,ConcursID=4},
 new RegistruParticipari{CatelID=5,ConcursID=1},
 new RegistruParticipari{CatelID=5,ConcursID=2},
 new RegistruParticipari{CatelID=5,ConcursID=3},
 new RegistruParticipari{CatelID=5,ConcursID=4},
 new RegistruParticipari{CatelID=6,ConcursID=1},
 new RegistruParticipari{CatelID=6,ConcursID=2},
 new RegistruParticipari{CatelID=6,ConcursID=3},
 new RegistruParticipari{CatelID=6,ConcursID=4},
 new RegistruParticipari{CatelID=7,ConcursID=1},
 new RegistruParticipari{CatelID=7,ConcursID=2},
 new RegistruParticipari{CatelID=7,ConcursID=3},
 new RegistruParticipari{CatelID=7,ConcursID=4}
 };
            foreach (RegistruParticipari par in RegistreParticipari)
            {
                context.RegistreParticipari.Add(par);
            }
            context.SaveChanges();

        }
    }
}
