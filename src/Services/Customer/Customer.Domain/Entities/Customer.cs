using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Customer.Domain.Entities
{
    public class Customer
        : Entity, IAggregateRoot
    {
        /// <summary>
        /// 客户名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; private set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; private set; }
        /// <summary>
        /// 星级
        /// </summary>
        public int StarRating { get; private set; }

        private Customer() { }
    }
}
