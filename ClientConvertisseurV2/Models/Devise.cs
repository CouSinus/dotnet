using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    internal class Devise
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string? deviseName;

        public string? DeviseName
        {
            get { return deviseName; }
            set { deviseName = value; }
        }

        private double taux;

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        public Devise(int id, string deviseName, double taux)
        {
            Id = id;
            DeviseName = deviseName;
            Taux = taux;
        }

        public Devise() { }
    }
}
