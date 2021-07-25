namespace stage1
{
    class Program
    {
        static void Main()
        {
            SolarSystemStar star = new SolarSystemStar() {Name = "Sun"};
            SolarSystemPlanet mercury = new SolarSystemPlanet() {Name = "Mercury"};
            SolarSystemPlanet venus = new SolarSystemPlanet() {Name = "Venus"};
            SolarSystemPlanet earth = new SolarSystemPlanet() {Name = "Earth"};
            SolarSystemPlanet mars = new SolarSystemPlanet() {Name = "Mars"};
            SolarSystemPlanet jupiter = new SolarSystemPlanet() {Name = "Jupiter"};
            SolarSystemPlanet saturn = new SolarSystemPlanet() {Name = "Saturn"};
            SolarSystemPlanet uranus = new SolarSystemPlanet() {Name = "Uranus"};
            SolarSystemPlanet neptune = new SolarSystemPlanet() {Name = "Neptune"};
            SolarSystemObject.DisplayCounter();
            
            SolarSystemObject[] spaceobjbects = new SolarSystemObject[]
                {star, mercury, venus, earth, mars, jupiter, saturn, uranus, neptune};
            foreach (var item in spaceobjbects)
            {
                item.Move();
            }
        }
    }
}