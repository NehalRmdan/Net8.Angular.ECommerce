using core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace core.Entities.OrderAggregates
{
    public class Address 
    {
        public Address()
        {
        }

        public Address(string? firstName
            , string? lastName
            , string? city
            , string? state
            , string? street
            , string? building
            , string? appartment
            , string? zIPCode
            , string? mark)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            Street = street;
            Building = building;
            Appartment = appartment;
            ZIPCode = zIPCode;
            Mark = mark;
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Appartment { get; set; }

        public string? ZIPCode { get; set; }

        public string? Mark { get; set; }

    }
}
