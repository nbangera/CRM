using System;

namespace CRM.Models.Dbo
{
  public class User
    {
        
    }

    public class Contact
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address HomeAddress { get; set; }
    }

    public class Organisation
    {
        public long OrganisationId { get; set; }      
        public string CompanyName { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public long AddressId { get; set; }
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Street4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
    }


}