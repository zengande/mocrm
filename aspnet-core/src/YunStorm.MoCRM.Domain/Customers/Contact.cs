using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace YunStorm.MoCRM.Customers
{
    public class Contact : Entity<long>
    {
        public long CustomerId { get; protected set; }
        public string Name { get; protected set; }
        public string Department { get; protected set; }
        public string Position { get; protected set; }
        public int Gender { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string EmailAddress { get; protected set; }
        public DateTime? Birthday { get; protected set; }

        protected Contact() { }
        public Contact(string name, string department, string position, string phoneNumber, string emailAddress, int gender, DateTime? birthday = null)
        {
            Name = name;
            Department = department;
            Position = position;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Gender = gender;
            Birthday = birthday;
        }
    }
}
