using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace YunStorm.MoCRM.Customer.Customers
{
    public class Customer :
        Entity<long>, IAggregateRoot<long>
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Address { get; private set; }
        public string Remarks { get; private set; }
        public CustomerLevel CustomerLevel { get; private set; }
        private int? _customerLevelId;
        public IReadOnlyCollection<Contact> Contacts => _contacts?.AsReadOnly();
        private List<Contact> _contacts;

        private Customer()
        {
            _contacts = new List<Contact>();
            _customerLevelId = CustomerLevel.General.Id;
        }

        public Customer(string name, string phoneNumber, string emailAddress, string address, int? customerLevelId, string remarks = null) : this()
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Address = address;
            Remarks = remarks;

            _customerLevelId = customerLevelId;
        }

        public void AddContact(string name, string department, string phoneNumber, string emailAddress, byte? gender = null, DateTime? birthday = null, int? roleId = null)
        {
            var contact = new Contact(name, department, phoneNumber, emailAddress, gender, birthday, roleId);
            _contacts.Add(contact);
        }
    }
}
