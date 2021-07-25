using System;

namespace stage1
{
    public class SolarSystemObject : ISolarOrbit
    {
        private static int _counter = 0;

        public SolarSystemObject()
        {
            _counter++;
        }

        public virtual void Move()
        {
            Console.WriteLine($"Обьект '{Name}' как-то движется");
        }

        public string Name { get; set; }

        public static void DisplayCounter()
        {
            Console.WriteLine($"Создано {_counter} объектов");
        }
    }
}