using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Contract.Domain.ContractAggregate
{
    public class ContractStatus : Enumeration
    {
        /// <summary>
        /// 签约
        /// </summary>
        public static ContractStatus Signing = new ContractStatus(1, nameof(Signing));
        /// <summary>
        /// 执行中
        /// </summary>
        public static ContractStatus Executing = new ContractStatus(2, nameof(Executing));
        /// <summary>
        /// 完成
        /// </summary>
        public static ContractStatus Completed = new ContractStatus(3, nameof(Completed));
        /// <summary>
        /// 意外终止
        /// </summary>
        public static ContractStatus UnexpectedlyTerminated = new ContractStatus(4, nameof(UnexpectedlyTerminated));

        public ContractStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
