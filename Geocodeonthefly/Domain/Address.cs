namespace Geocodeonthefly.Domain
{
    public class Address
    {
        public string CustomIdentifier { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }
        
        public string Street { get; set; }

        public string Number { get; set; }
        
        public string Postalcode { get; set; }

        public double ApiLat { get; set; }

        public double ApiLng { get; set; }

        public string ApiCountry { get; set; }

        public string ApiState { get; set; }

        public string ApiCity { get; set; }

        public string ApiNeighborhood { get; set; }

        public string ApiStreet { get; set; }

        public string ApiNumber { get; set; }

        public string ApiPostalcode { get; set; }
    }
}
