using System;
using System.Collections.Generic;
using System.Linq;

namespace stage5
{
    class Program
    {
        static void Main(string[] args)
        {
            var petia = new Klient() {Fio = "Иванов Пётр Иванович", PassNom = 123456, Sum = 100};
            var kolia = new Klient() {Fio = "Иванов Николай Иванович", PassNom = 234567, Sum = 200};
            var serega = new Klient() {Fio = "Иванов Сергей Иванович", PassNom = 345678, Sum = 100};
            var piotr = new Klient() {Fio = "Иванов Пётр Иванович", PassNom = 456789, Sum = 500};
            var newpetia = new Klient() {Fio = "Иванов Пётр Иванович", PassNom = 123456, Sum = 400};

            List<Klient> klients = new List<Klient>();
            klients.AddRange(new Klient[] {petia, kolia, serega, piotr, newpetia});

            string fioneedtofind = "Иванов".ToUpper();
            var findedkli1 = FindKlientsByFio(fioneedtofind, klients);
            Console.WriteLine($"\nКлиенты у которых FIO LIKE '%{fioneedtofind}%':");
            int i = 0;
            foreach (var men in findedkli1)
            {
                i++;
                Console.WriteLine($"{i}.{men.Fio}  № паспорта: {men.PassNom}");
            }

            decimal limitsum = 400;
            var findedkli2 = FindKlientsByPoor(0, limitsum, klients);
            Console.WriteLine($"\nКлиенты у которых SUM < {limitsum}:");
            i = 0;
            foreach (var men in findedkli2)
            {
                i++;
                Console.WriteLine($"{i}.{men.Fio}  № паспорта: {men.PassNom} сумма={men.Sum}у.е.");
            }

            decimal minsum = klients.Min(p => p.Sum);
            var findedkli3 = FindKlientsByPoor(1, minsum, klients);
            Console.WriteLine("\nКлиенты у которых минимальный остаток на счёте:");
            i = 0;
            foreach (var men in findedkli3)
            {
                i++;
                Console.WriteLine($"{i}.{men.Fio}  № паспорта: {men.PassNom} сумма={men.Sum}у.е.");
            }

            decimal sumsum = klients.Sum(p => p.Sum);
            Console.WriteLine($"\nОстаток на счетах клиентов равен:{sumsum}у.е.");
        }

        public static IEnumerable<Klient> FindKlientsByFio(string name, List<Klient> klients)
        {
            return klients.Where(p => p.Fio.ToUpper().Contains(name)).OrderBy(p => p.Fio);
        }

        public static IEnumerable<Klient> FindKlientsByPoor(int typ, decimal sum, List<Klient> klients)
        {
            if (typ == 0)
            {
                return klients.Where(p => p.Sum.CompareTo(sum) < 0).OrderBy(p => p.Sum);
            }
            else
            {
                return klients.Where(p => p.Sum.CompareTo(sum) == 0).OrderBy(p => p.Sum);
            }
        }
    }
}