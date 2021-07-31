using System;

namespace stage4
{
    public class Person : People
    {
        public override int GetHashCode()
        {
            return Fio.Length + ((DateTime.Today).Year - DateOfBirth.Year) + PlaceOfBirth.Length + PassNom.Length;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Person))
            {
                return false;
            }

            Person result = (Person) obj;
            return result.Fio == Fio && DateTime.Equals(result.DateOfBirth, DateOfBirth) &&
                   result.PlaceOfBirth == PlaceOfBirth && result.PassNom == PassNom;
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Person first, Person second)
        {
            return first.Equals(second);
        }
    }
}