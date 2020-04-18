using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Objet
{
    public class Equipement : Item
    {
        public virtual Genre Genre { get; set; }
        public virtual Materiel Materiel { get; set; }
        public virtual Qualite Qualite { get; set; }
        public typeEquipement TypeEquipement { get; set; }

        public override int Poid()
        {
            return (Genre.Poid * Materiel.Poid * Qualite.Poid) / 10000;
        }

        public override int Prix()
        {
            return (Genre.Prix * (Materiel.Prix + Qualite.Prix)) / 100;
        }



        public int GetValueStat(Stat stat)
        {
            int retour = 0;


            ValeurGenreStat genreStat = Genre.Stats.FirstOrDefault(s => s.Stat == stat);
            ValeurMaterielStat matStat = Materiel.Stats.FirstOrDefault(s => s.Stat == stat);
            ValeurQualiteStat qualStat = Qualite.Stats.FirstOrDefault(s => s.Stat == stat);


            int statGenre = 0;
            int statMateriel = 0;
            int statQualite = 0;

            if (genreStat != null)
            {
                statGenre = genreStat.Valeur;
            }
            if (matStat != null)
            {
                statMateriel = matStat.Valeur;
            }
            if (qualStat != null)
            {
                statQualite = qualStat.Valeur;
            }


            return statGenre + statMateriel + statQualite;
            
        }

        public enum typeMateriel
        {
            Metal = 1,
            Tissu = 2,
            Cuir = 3
        }


        public enum typeEquipement
        {
            Arme = 1,
            Armure = 2,
            Bouclier = 3
        }
    }
}