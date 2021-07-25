using System;

namespace stage1
{
    public class SolarSystemPlanet : SolarSystemObject
    {
        public override void Move()
        {
            Console.WriteLine($"Планета '{Name}' вращается по орбите");
        }

    }
}