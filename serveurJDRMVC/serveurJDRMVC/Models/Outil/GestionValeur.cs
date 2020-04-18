using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Outil
{
    public static class GestionValeur
    {
        private static int reduc_puissance = 2;
        private static int reduc_valeur = 200;
        public static int GetValeur(float valeur)
        {
            return (int)valeur;
        }

        public static int GetValeurOn100(float valeur)
        {
            return (int)(100 - (100 / (Math.Pow(2, (valeur / 50)))));
        }

        public static int ReductionDegats(int subit, int resist)
        {
            double val = Math.Pow((double)reduc_puissance, ((double)resist / (double)reduc_valeur));
            val = 100 - (100 / val);
            return (int)(subit - ((subit * val) / 100));
        }
    }
}