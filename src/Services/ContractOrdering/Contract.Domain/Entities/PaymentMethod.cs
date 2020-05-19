using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.ContractOrdering.Domain.Entities
{
    /// <summary>
    /// 付款方式
    /// </summary>
    public class PaymentMethod : Enumeration
    {
        public static PaymentMethod UnionPay = new PaymentMethod(1, nameof(UnionPay));
        public static PaymentMethod AliPay = new PaymentMethod(2, nameof(AliPay));
        public static PaymentMethod WePay = new PaymentMethod(3, nameof(WePay));

        public PaymentMethod(int id, string name) : base(id, name)
        {
        }
    }
}
