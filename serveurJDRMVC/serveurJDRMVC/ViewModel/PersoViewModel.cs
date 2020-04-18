using serveurJDRMVC.Models.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.ViewModel
{
    public class PersoViewModel
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Definition { get; set; }
        public virtual Race Race { get; set; }
        public virtual SousRace SousRace { get; set; }
        public virtual Classe Classe { get; set; }
    }
}