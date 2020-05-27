using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using YunStorm.MoCRM.Customers.Events;

namespace YunStorm.MoCRM.Customers
{
    public class Customer : AggregateRoot<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber { get; protected set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailAddress { get; protected set; }
        /// <summary>
        /// 网站
        /// </summary>
        public string WebSite { get; protected set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; protected set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public IReadOnlyCollection<Contact> Contacts => _contacts?.AsReadOnly();
        private List<Contact> _contacts;

        protected Customer()
        {
            _contacts = new List<Contact>();
            CreatedAt = DateTime.UtcNow;
        }
        public Customer(string name, string phoneNumber, string emailAddress, string webSite = null, string remarks = null) : this()
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            WebSite = webSite;
            Remarks = remarks;
        }

        public void AddContact(string name, string department, string position, string phoneNumber, string emailAddress, int gender, DateTime? birthday = null)
        {
            var contact = new Contact(name, department, position, phoneNumber, emailAddress, gender, birthday);
            _contacts.Add(contact);
            var @event = new ContactAddedDomainEvent();
            AddLocalEvent(@event);
        }
    }
}
