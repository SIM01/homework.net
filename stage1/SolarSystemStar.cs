using System;

namespace stage1
{
    public class SolarSystemStar:SolarSystemObject
    {
        public override void Move()
        {
            Console.WriteLine($"Звезда '{Name}' вращается вокруг своей оси");
        }
    }
}