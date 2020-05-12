using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Customer.Domain.Entities
{
    public class ContactRecord
        : Entity
    {
        public DateTime OccurredOn { get; private set; }
        public string Remarks { get; private set; }

        public ContactRecord(DateTime occurredOn, string remarks)
        {
            OccurredOn = occurredOn;
            Remarks = remarks;
        }
    }
}
