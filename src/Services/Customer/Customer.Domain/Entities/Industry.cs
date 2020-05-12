using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Customer.Domain.Entities
{
    /// <summary>
    /// 行业
    /// </summary>
    public class Industry
        : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Industry(string name)
        {
            Name = name;
        }
    }
}
