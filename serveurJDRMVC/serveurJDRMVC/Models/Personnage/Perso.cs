using serveurJDRMVC.Models.Effets;
using serveurJDRMVC.Models.Outil;
using serveurJDRMVC.Models.Statistique;
using serveurJDRMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Personnage
{
    public class Perso
    {
        private Dal dal = new Dal();
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Definition { get; set; }
        public Boolean Vivant { get; set; }
        public Race Race { get; set; }
        public SousRace SousRace { get; set; }
        public Classe Classe { get; set; }
        public int Lvl { get; set; }
        public List<ValeurPersoStat> Stats { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public List<ValeurBuffStat> Buff { get; set; }
        public List<EffetAppliquer> ListEffets { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Race race &&
                   Id == race.Id;
        }



        public static Perso CreationPerso(PersoViewModel p )
        {
            return CreationPerso(p.Nom,p.Prenom,p.Definition,p.Race,p.SousRace,p.Classe,0);
        }


        public static Perso CreationPerso(String nom , String prenom , String definition , Race race , SousRace sousRace , Classe classe , int lvl)
        {

            Perso perso = new Perso { Nom = nom, Prenom = prenom, Definition = definition, Race = race, SousRace = sousRace, Classe = classe, Lvl = lvl , Vivant = true };

            perso.Stats = new List<ValeurPersoStat>();
            foreach (DeeStat dee in perso.Race.StatDee)
            {
                perso.Stats.Add(new ValeurPersoStat { Stat = dee.Stat,Valeur = Roll.JetDée(dee.TailleDee,dee.NbDee)});
            }

            return perso;
        }


        public int GetStat(Stat stat)
        {
            return GestionValeur.GetValeur(GetValueStat(stat));
        }
        public int GetStatTest(Stat stat)
        {
            return GestionValeur.GetValeurOn100(GetValueStat(stat));
        }

        private int GetValueStat(Stat stat)
        {
            int retour = 0;


            ValeurRaceStat valeurStatRace = Race.Stat.FirstOrDefault(s => s.Stat == stat);
            ValeurSousRaceStat valeurStatSousRace = SousRace.Stat.FirstOrDefault(s => s.Stat == stat);
            ValeurClasseStat valeurStatClasse = Classe.Stat.FirstOrDefault(s => s.Stat == stat);
            ValeurPersoStat valeurStatPerso = Stats.FirstOrDefault(s => s.Stat == stat);
            ValeurBuffStat valeurStatBuf = Buff.FirstOrDefault(s => s.Stat == stat);


            int statRace = 0;
            int statSousRace = 0;
            int statClasse = 0;
            int statPerso = 0;
            int statBuf = 0;


            if(valeurStatRace != null)
            {
                statRace = valeurStatRace.Valeur;
            }
            if(valeurStatSousRace != null)
            {
                statSousRace = valeurStatSousRace.Valeur;
            }
            if(valeurStatClasse != null)
            {
                statClasse = valeurStatClasse.Valeur;
            }
            if(valeurStatPerso != null)
            {
                statPerso = valeurStatPerso.Valeur;
            }
            if(valeurStatBuf != null)
            {
                statBuf = valeurStatBuf.Valeur;
            }






            int bonus = 0;
            if(stat.StatCalculer != null)
            {
                foreach ( StatUtil  util in stat.StatCalculer.ListStatUtils)
                {
                   int tmp =  (GetValueStat(util.StatUtile) * util.Valeur )/100;
                    bonus += tmp; 
                }
            }
            if (stat.Type == Stat.Typestats.Base)
            {
                return ((statRace + statSousRace + statPerso) * (100 + statClasse * Lvl)) / 100 + statBuf + bonus;
            }
            else 
            {
                return statRace + statSousRace + statPerso + (statClasse * Lvl) + statBuf + bonus;
            }
        }



        public int GetPV()
        {
            return GetStat(dal.GetAllStat().FirstOrDefault(s => s.Stats == Stat.stats.PV));
        }
        public int GetPVManquand()
        {
            return GetStat(dal.GetAllStat().FirstOrDefault(s => s.Stats == Stat.stats.PVManquand));
        }


    }
}