namespace WepAPITP1.Models
{
    public class Devise
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

		public Devise()	{}



	}
}
