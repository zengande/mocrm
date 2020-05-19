using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.ContractOrdering.Domain.Entities
{
    /// <summary>
    /// 合同订单
    /// </summary>
    public class ContractOrder :
        Entity, IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; private set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 成本
        /// </summary>
        public decimal ContractCost { get; private set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal ContractPrice { get; private set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public long CustomerId { get; private set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string CustomerName { get; private set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatorId { get; private set; }
        public DateTime CreationTime { get; private set; }
        /// <summary>
        /// 待办事项
        /// </summary>
        public IReadOnlyCollection<ContractToDo> ToDoList => _todoList?.AsReadOnly();
        private List<ContractToDo> _todoList;
        /// <summary>
        /// 关联产品
        /// </summary>
        public IReadOnlyCollection<ContractProduct> ContractProducts => _contractProducts?.AsReadOnly();
        private List<ContractProduct> _contractProducts;
        /// <summary>
        /// 付款方式
        /// </summary>
        public PaymentMethod PaymentMethod { get; private set; }
        private int? _paymentMethodId;
        /// <summary>
        /// 状态
        /// </summary>
        public ContractStatus ContractStatus { get; private set; }
        private int? _contractStatusId;

        public ContractOrder(string number, string name, decimal contractCost, int? paymentMethodId = null, int? contractStatusId = null)
            : this()
        {
            Number = number;
            Name = name;
            ContractCost = contractCost;

            _paymentMethodId = paymentMethodId;
            _contractStatusId = contractStatusId;
        }

        protected ContractOrder()
        {
            _todoList = new List<ContractToDo>();
            _contractProducts = new List<ContractProduct>();
            CreationTime = DateTime.UtcNow;
        }
    }
}
