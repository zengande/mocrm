using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace YunStorm.MoCRM.Customer.Customers
{
    public class Contact :
        Entity<long>
    {
        public string Name { get; private set; }
        public string Department { get; private set; }
        public string Position { get; private set; }
        public byte? Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public DateTime? Birthday { get; private set; }
        public ContactRole ContactRole { get; private set; }
        private int? _contactRoleId;

        private Contact() { }
        public Contact(string name, string department, string phoneNumber, string emailAddress, byte? gender = null, DateTime? birthday = null, int? contactRoleId = null)
        {
            Name = name;
            Department = department;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Gender = gender;
            Birthday = birthday;
            _contactRoleId = contactRoleId ?? ContactRole.Other.Id;
        }
    }
}
