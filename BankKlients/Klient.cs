namespace BankKlients
{
    public class Klient
    {
        public string Fio { get; set; }

        public int PassNom { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Klient))
            {
                return false;
            }

            Klient result = (Klient) obj;
            return result.Fio == Fio && result.PassNom == PassNom;
        }

        public override int GetHashCode()
        {
            return PassNom;
        }
    }
}