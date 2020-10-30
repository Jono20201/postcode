namespace Postcode.PostcodesIO.Model
{
    public class ApiLookupResponseResult
    {
        public string Postcode { get; set; }
        public int Eastings { get; set; }
        public int Northings { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public string Parish { get; set; }
        public string AdminCounty { get; set; }
    }
}