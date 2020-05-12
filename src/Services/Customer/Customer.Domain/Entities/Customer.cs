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
        /// 简称
        /// </summary>
        public string Abbreviation { get; private set; }
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
        /// <summary>
        /// 负责人的id
        /// </summary>
        public string IdOfPersonInCharge { get; private set; }
        /// <summary>
        /// 负责人的名字
        /// </summary>
        public string NameOfPersonInCharge { get; private set; }
        /// <summary>
        /// 联系记录
        /// </summary>
        public IReadOnlyCollection<ContactRecord> ContactRecords => _contactRecords?.AsReadOnly();
        private List<ContactRecord> _contactRecords;

        /// <summary>
        /// 行业
        /// </summary>
        private int? _industryId;

        public int? GetIndustryId => _industryId;

        public Customer(string name, string abbreviation, string tel, int starRating, int? industryId = null, string idOfPersonInCharge = null, string nameOfPersonInCharge = null)
            : this()
        {
            Name = name;
            Abbreviation = abbreviation;
            Tel = tel;
            StarRating = starRating;
            _industryId = industryId;
            IdOfPersonInCharge = idOfPersonInCharge;
            NameOfPersonInCharge = nameOfPersonInCharge;
        }

        private Customer()
        {
            _contactRecords = new List<ContactRecord>();
        }
    }
}
