namespace Postcode.Models
{
    public class PostcodeLookup
    {
        public string Postcode { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public string BuildingName { get; set; }
        public string SecondaryBuildingName { get; set; }
        public string BuildingNumber { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Country { get; set; }

        public int Eastings { get; set; }
        public int Northings { get; set; }
    }
}