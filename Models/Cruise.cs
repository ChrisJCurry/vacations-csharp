namespace Models
{
    public class Cruise : Vacation
    {
        public string CruiseLiner { get; set; }

        public int Stops { get; set; }
    }
}