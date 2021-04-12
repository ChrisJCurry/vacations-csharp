namespace Models
{
    public class Trip : Vacation
    {
        public string Airline { get; set; }

        public int Layovers { get; set; }
    }
}