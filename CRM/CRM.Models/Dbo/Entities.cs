using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CRM.Models.Dbo
{

    public abstract class EntityBase<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public User ModifiedBy { get; set; }
        public long ModifiedById { get; set; }

        public DateTime CreatedDate { get; set; }
        public User CreatedBy { get; set; }
        public long CreatedById { get; set; }
    }
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Product> Products {get;set;}

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<Organisation> ModifiedOrganisations { get; set; }

        public virtual ICollection<Organisation> CreatedOrganisations { get; set; }
        public virtual ICollection<Contact> ModifiedContacts { get; set; }

        public virtual ICollection<Contact> CreatedContacts { get; set; }
        public virtual ICollection<ContactActivity> ModifiedContactActivities { get; set; }

        public virtual ICollection<ContactActivity> CreatedContactActivities { get; set; }

        public virtual ICollection<OrganisationActivity> ModifiedOrganisationActivities { get; set; }

        public virtual ICollection<OrganisationActivity> CreatedOrganisationActivities { get; set; }
        public virtual ICollection<ContactNote> ModifiedContactNotes { get; set; }

        public virtual ICollection<ContactNote> CreatedContactNotes { get; set; }

        public virtual ICollection<OrganisationNote> ModifiedOrganisationNotes { get; set; }

        public virtual ICollection<OrganisationNote> CreatedOrganisationNotes { get; set; }


        public virtual ICollection<ContactAppointment> ModifiedContactAppointments { get; set; }

        public virtual ICollection<ContactAppointment> CreatedContactAppointments { get; set; }
        public virtual ICollection<OrganisationAppointment> ModifiedOrganisationAppointments { get; set; }

        public virtual ICollection<OrganisationAppointment> CreatedOrganisationAppointments { get; set; }

        public virtual ICollection<Order> ModifiedOrders { get; set; }

        public virtual ICollection<Order> CreatedOrders { get; set; }
        public virtual ICollection<Product> CreatedProducts { get; set; }

        public virtual ICollection<Product> ModifiedProducts { get; set; }

        public virtual ICollection<OrderItem> CreatedOrderItems { get; set; }

        public virtual ICollection<OrderItem> ModifiedOrderItems { get; set; }

        public virtual ICollection<Address> CreatedAddresses { get; set; }

        public virtual ICollection<Address> ModifiedAddresses { get; set; }
    }

    public class Role : IdentityRole<long>
    {
        public string Description { get; set; }
    }


    public class Contact : EntityBase<long>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public float Budget {get;set;}

        public Organisation Organisation { set; get; }
        public long OrganisationId { set; get; }

        public long UserId {get;set;}

        public User User {get;set;}

        public ICollection<ContactActivity> ContactActivities { get; set; }

        public ICollection<ContactAppointment> ContactAppointments { get; set; }

        public ICollection<ContactNote> ContactNotes { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<ContactAddress> Addresses { get; set; }
    }

    public class Organisation : EntityBase<long>
    {

        public string CompanyName { get; set; }


        public ICollection<Contact> Contacts { get; set; }

        public ICollection<OrganisationActivity> OrganisationActivities { get; set; }

        public ICollection<OrganisationAppointment> OrganisationAppointments { get; set; }

        public ICollection<OrganisationNote> OrganisationNotes { get; set; }

        public ICollection<OrganisationAddress> Addresses { get; set; }
    }

    // public class Relationship
    // {
    //     public int Id {get;set;}
    //     public string Name {get;set;}

    //     public RelationshipType Type {get;set;}
    // }

    // public class CustomerOrganisationRelationship
    // {
    //   public long Id {get;set;}
    //   public Relationship  Relationship {get;set;}
    //   public int  RelationshipId {get;set;}

    //   public Contact Contact {get;set;}
    //   public long ContactId {get;set;}

    //   public Organisation Organisation {get;set;}
    //   public long OrganisationId {get;set;}



    // }

    public class OrganisationAddress
    {
        public long Id { get; set; }
        public OrganisationAddressType Type { get; set; }

        public long AddressId { get; set; }

        public Address Address { get; set; }

        public long OrganisationId { get; set; }

        public Organisation Organisation { get; set; }
    }

    public class ContactAddress
    {
        public long Id { get; set; }
        public ContactAddressType Type { get; set; }
        public long AddressId { get; set; }

        public Address Address { get; set; }

        public long ContactId { get; set; }

        public Contact Contact { get; set; }
    }


    public class Address : EntityBase<long>
    {

        public AddressType AddressType { set; get; }
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Street4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }

        public ContactAddress ContactAddress { get; set; }

        public OrganisationAddress OrganisationAddress { get; set; }
    }

    public class OrganisationActivity : EntityBase<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityStatus Status { get; set; }
        public ActivityType Type { get; set; }

        public string Location { get; set; }

        public long OrganisationId { set; get; }
        public Organisation Organisation { set; get; }

    }

    public class ContactActivity : EntityBase<long>
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityStatus Status { get; set; }
        public ActivityType Type { get; set; }

        public string Location { get; set; }

        public long ContactId { set; get; }

        public Contact Contact { set; get; }

    }

    public class ContactNote : EntityBase<long>
    {
        public string Description { get; set; }
        public long ContactId { set; get; }

        public Contact Contact { set; get; }

    }


    public class OrganisationNote : EntityBase<long>
    {

        public string Description { get; set; }
        public long OrganisationId { set; get; }
        public Organisation Organisation { set; get; }

    }

    public class ContactAppointment : EntityBase<long>
    {


        public long ContactId { set; get; }

        public Contact Contact { set; get; }

    }

    public class OrganisationAppointment : EntityBase<long>
    {

        public long OrganisationId { set; get; }
        public Organisation Organisation { set; get; }
        public string Description { get; set; }

    }


    // public class Appointment : EntityBase<long>
    // {
    //     public string Description { get; set; }

    //     public ContactAppointment ContactAppointment { get; set; }

    //     public OrganisationAppointment OrganisationAppointment { get; set; }
    // }

    #region orders

    public class Order : EntityBase<long>
    {
        public Contact Contact { get; set; }

        public long ContactId { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class Product : EntityBase<long>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem : EntityBase<long>
    {
        public Order Order { get; set; }

        public long OrderId { get; set; }
        public Product Product { get; set; }

        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }

    #endregion

    #region enums

    public enum ActivityStatus
    {
        InProgress = 1,
        Overdue = 2,
        Completed = 3
    }

    public enum RelationshipType
    {
        Contact = 1,
        Organisation = 2
    }

    public enum OrganisationAddressType
    {
        Main = 1,
        ShipTo = 2,
        BillTo = 3
    }

    public enum ContactAddressType
    {
        Home = 1,
        Work = 2,
        Education = 3
    }

    public enum AddressType
    {
        Contact = 1,
        Organisation = 2
    }

    public enum ActivityType
    {
        Task = 1,
        Call = 2
    }

    #endregion
}
