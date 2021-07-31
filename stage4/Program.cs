using System;
using System.Reflection.Metadata;

namespace stage4
{
    class Program
    {
        static void Main(string[] args)
        {
            var petia = new Person()
            {
                Fio = "Иванов Пётр Иванович", DateOfBirth = new DateTime(1985, 7, 20), PlaceOfBirth = "СССР г.Воронеж",
                PassNom = "123456"
            };
            var kolia = new Person()
            {
                Fio = "Иванов Николай Иванович", DateOfBirth = new DateTime(1984, 7, 20),
                PlaceOfBirth = "СССР г.Воронеж", PassNom = "234567"
            };
            var serega = new Person()
            {
                Fio = "Иванов Сергей Иванович", DateOfBirth = new DateTime(1983, 7, 20),
                PlaceOfBirth = "СССР г.Воронеж", PassNom = "345678"
            };
            var piotr = new Person()
            {
                Fio = "Иванов Пётр Иванович", DateOfBirth = new DateTime(1980, 7, 20), PlaceOfBirth = "СССР г.Воронеж",
                PassNom = "456789"
            };
            var newpetia = new Person()
            {
                Fio = "Иванов Пётр Иванович", DateOfBirth = new DateTime(1985, 7, 20), PlaceOfBirth = "СССР г.Воронеж",
                PassNom = "123456"
            };
            var people = new Person[] {petia, kolia, serega, piotr, newpetia};
            foreach (var men in people)
            {
                var hash = men.GetHashCode();
                Console.WriteLine($"{men.Fio} хэш {hash}");
            }
            
            var status1 = petia.Equals(kolia);
            var status2 = petia == serega;
            var status3 = petia.Equals(newpetia);
            var status4 = petia == newpetia;
        }
    }
}