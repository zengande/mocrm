using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace YunStorm.MoCRM.Customers
{
    public class Customer : AggregateRoot<long>
    {
        public string Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string EmailAddress { get; protected set; }
        public IReadOnlyCollection<Contact> Contacts => _contacts?.AsReadOnly();
        private List<Contact> _contacts;

        protected Customer()
        {
            _contacts = new List<Contact>();
        }

        public Customer(string name, string phoneNumber, string emailAddress) : this()
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
