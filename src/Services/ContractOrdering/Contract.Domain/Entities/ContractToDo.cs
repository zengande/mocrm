using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.ContractOrdering.Domain.Entities
{
    /// <summary>
    /// 合同代办事项
    /// </summary>
    public class ContractToDo
        : Entity
    {
        public string SerialNumber { get; private set; }
        public string Content { get; private set; }

        private ContractToDo() { }
        public ContractToDo(string serialNumber, string content)
        {
            SerialNumber = serialNumber;
            Content = content;
        }
    }
}
