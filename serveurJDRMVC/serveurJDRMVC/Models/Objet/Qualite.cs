using serveurJDRMVC.Models.Effets;
using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Objet
{
    public class Qualite
    {
        public int Id { get; set; }
        public Equipement.typeMateriel TypeMat { get; set; }
        public int Prix { get; set; }
        public int Poid { get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public virtual List<ValeurQualiteStat> Stats { get; set; }
        public virtual List<Effet> EffetAuToucher { get; set; }
        public virtual List<Effet> EffetAuCrit { get; set; }
        public virtual List<Effet> EffetDebutTour { get; set; }
        public virtual List<Effet> EffetDebutCombat { get; set; }
    }
}