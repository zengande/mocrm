using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using YunStorm.MoCRM.ContractOrdering.Domain.Entities;

namespace ContractOrdering.UnitTests
{
    public class ContractOrderAggregateTest
    {
        public ContractOrderAggregateTest()
        {

        }

        [Fact]
        public void Create_contract_todo_success()
        {
            // Arrange
            var number = "DO202005111702000001";
            var content = "test todo";

            // Act
            var todo = new ContractToDo(number, content);

            // Assert
            Assert.NotNull(todo);
        }
    }
}
