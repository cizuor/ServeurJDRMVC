using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Objet
{
    public abstract class Item
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public abstract int Prix();
        public abstract int Poid();


    }
}