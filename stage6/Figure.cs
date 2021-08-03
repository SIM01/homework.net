namespace stage6
{
    public class Figure
    {
        public int SideCount { get; set; }
        public int SideLenght { get; set; }
        
        public override int GetHashCode()
        {
            return SideCount*SideLenght;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Figure))
            {
                return false;
            }

            Figure result = (Figure) obj;
            return result.SideCount == SideCount && result.SideLenght == SideLenght;
        }
    }
}