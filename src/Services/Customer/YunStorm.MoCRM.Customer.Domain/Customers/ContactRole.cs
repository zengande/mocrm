using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Values;
using YunStorm.MoCRM.BuildingBlocks.Common;

namespace YunStorm.MoCRM.Customer.Customers
{
    public class ContactRole : 
        Enumeration
    {
        public static ContactRole PolicyMaker = new ContactRole(1, nameof(PolicyMaker).ToUpper(), "决策者");
        public static ContactRole Approver = new ContactRole(2, nameof(Approver).ToUpper(), "审批者");
        public static ContactRole Assessor = new ContactRole(3, nameof(Assessor).ToUpper(), "评估者");
        public static ContactRole User = new ContactRole(4, nameof(User).ToUpper(), "用户");
        public static ContactRole Other = new ContactRole(5, nameof(Other).ToUpper(), "其他");

        protected ContactRole()
        {
        }

        public ContactRole(int id, string name )
            : base(id, name)
        {
        }

        public ContactRole(int id, string name, string displayName)
            : base(id, name, displayName)
        {
        }

        public static IEnumerable<ContactRole> List() =>
            new[] { PolicyMaker, Approver, Assessor, User, Other };

        public static ContactRole FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                //throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ContactRole From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                //throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
