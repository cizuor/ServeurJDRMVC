using serveurJDRMVC.Models.Outil;
using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Effets
{
    public class EffetAppliquer
    {
        public int Id { get; set; }

        public int IdEffet { get; set; }
        public virtual List<Effet> ListEffetBonus { get; set; }
        public int Penetration { get; set; }
        public int MinHit { get; set; }
        public int MaxHit { get; set; }
        public virtual Stat StatReduc { get; set; }
        public int CoefStatReduc { get; set; }
        public int ValeurBase { get; set; }
        public virtual Stat StatAffecter { get; set; }
        public int Drain { get; set; }
        public int TailleDee { get; set; }
        public int NbDee { get; set; }


        public Perso Lanceur { get; set; }
        public int Bonus { get; set; }
        public int Reduction { get; set; }
        public int TourRestant { get; set; }
        public Boolean EffetBonus { get; set; }
        public Boolean Actif { get; set; }
        public int BuffDrain { get; set; }
        public int BuffTotal { get; set; }


        public EffetAppliquer()
        {

        }



        public EffetAppliquer(Effet effet) 
        {
            IdEffet = effet.Id;
            ListEffetBonus = effet.ListEffetBonus;
            Penetration = effet.Penetration;
            MinHit = effet.MinHit;
            MaxHit = effet.MaxHit;
            StatReduc = effet.StatReduc;
            CoefStatReduc = effet.CoefStatReduc;
            ValeurBase = effet.ValeurBase;
            StatAffecter = effet.StatAffecter;
            Drain = effet.Drain;
            TailleDee = effet.TailleDee;
            NbDee = effet.NbDee;

            TourRestant = Roll.minmax(effet.DureMin, effet.DureMax);
            Boolean isEffetBonus;
            int result;
            Roll.Jet100(effet.ChanceEffetBonus, out result, out isEffetBonus);
            EffetBonus = isEffetBonus;

        }



        public void Resolution(Perso perso)
        {
            if (Actif)
            {
                int total = 0;
                int nbHit = Roll.minmax(MinHit, MaxHit);
                for (int i = 0; i < nbHit; i++)
                {
                    int tmp = 0;
                    tmp += ValeurBase + Roll.JetDée(TailleDee, NbDee);

                    tmp = (tmp * (100 + Bonus)) / 100;
                    tmp = GestionValeur.ReductionDegats(tmp, (Reduction * (100 - Penetration)) / 100);
                    total += tmp;
                }

                if (!perso.Buff.Any(b => b.Stat == StatAffecter))
                {
                    perso.Buff.Add(new ValeurBuffStat { Stat = StatAffecter, Valeur = 0 });
                }

                ValeurBuffStat buff = perso.Buff.First(b => b.Stat == StatAffecter);
                buff.Valeur += total;
                BuffTotal = total;

                if (!Lanceur.Buff.Any(b => b.Stat == StatAffecter))
                {
                    Lanceur.Buff.Add(new ValeurBuffStat { Stat = StatAffecter, Valeur = 0 });
                }
                ValeurBuffStat buffDrain = Lanceur.Buff.First(b => b.Stat == StatAffecter);
                if (Drain != 0)
                {
                    buffDrain.Valeur += (total * Drain) / 100;
                    BuffDrain = (total * Drain) / 100;
                }


                // si c'est une attaque ou un soin
                if (StatAffecter.Stats == Stat.stats.PVManquand)
                {
                    int pv = perso.GetPV();
                    int pvManquand = perso.GetPVManquand();

                    if (pvManquand > pv)
                    {
                        perso.Vivant = false;
                    }

                    if (buff.Valeur < 0)
                    {
                        buff.Valeur = 0;
                    }

                    pv = Lanceur.GetPV();
                    pvManquand = Lanceur.GetPVManquand();

                    if (pvManquand > pv)
                    {
                        Lanceur.Vivant = false;
                    }

                    if (buffDrain.Valeur < 0)
                    {
                        buffDrain.Valeur = 0;
                    }

                }
                else
                {
                    Actif = false;
                }
            }
        }

        public void Dissipation(Perso perso)
        {
            if (StatAffecter.Stats != Stat.stats.PVManquand)
            {
                ValeurBuffStat buff = perso.Buff.First(b => b.Stat == StatAffecter);
                buff.Valeur -= BuffTotal;
                ValeurBuffStat buffDrain = Lanceur.Buff.First(b => b.Stat == StatAffecter);
                buffDrain.Valeur -= BuffDrain;
            }
            perso.ListEffets.Remove(this);
        }

    }
}