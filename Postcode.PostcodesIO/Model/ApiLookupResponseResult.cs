namespace Postcode.PostcodesIO.Model
{
    public class ApiLookupResponseResult
    {
        public string Postcode { get; set; }
        public int Eastings { get; set; }
        public int Northings { get; set; }
        public double Longitude { get; set; }
        public string Region { get; set; }
        public string AdminCounty { get; set; }
    }
}