using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Outil
{
    public class DicoStat : Dictionary<Stat, int>
    {
        public int this[Stat key]
        {
            get
            {
                int retour = 0;
                if (key == null || !this.TryGetValue(key, out retour))
                {
                    retour = 0;
                }
                return retour;
            }
            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                }
                this.Add(key, value);
            }
        }
    }
}