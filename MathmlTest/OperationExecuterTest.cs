using System;
using Xunit;
using FluentAssertions;
using Mathml;
using System.Collections.Generic;
using Mathml.Operations;

namespace MathmlTest
{
    public class OperationExecuterTest
    {
        [Fact]
        public void Execute_MultipleOperations_AllExecutionLogsReturned()
        {
            // Arrange
            Addition operation1 = new Addition();
            Multiplication operation2 = new Multiplication();
            operation1 = (Addition)PopulateOperation(operation1, "Joe", "SUM", "TURN10", 40, 2, '+');
            operation2 = (Multiplication)PopulateOperation(operation2, "Sam", "MULTIPLY", "TURN10", 2, 3, '*');

            List<Operation> multipleOperations = new List<Operation>();
            multipleOperations.Add(operation1);
            multipleOperations.Add(operation2);

            List<string> correctExecutionLogs = new List<string>
            {
                "Joe - SUM - 40 + 2 = 42",
                "Sam - MULTIPLY - 2 * 3 = 6"
            };

            // Act
            List<string> executionLogs = OperationExecuter.Execute(multipleOperations);

            // Assert
            correctExecutionLogs.Should().BeEquivalentTo(executionLogs);
        }

        [Fact]
        public void Execute_NullValue_NullReturned()
        {
            List<string> executionLogs = OperationExecuter.Execute(null);

            Assert.Null(executionLogs);
        }

        [Fact]
        public void Execute_EmptyList_EmptyReturned()
        {
            List<string> emptyList = new List<string>();

            List<string> executionLogs = OperationExecuter.Execute(new List<Operation>());

            Assert.Equal(emptyList, executionLogs);
        }

        private Operation PopulateOperation(
            Operation operation, 
            string username, 
            string operationName, 
            string miscellaneousInfo, 
            int value1, 
            int value2, 
            char operationSymbol)
        {
            operation.Username = username;
            operation.OperationName = operationName;
            operation.MiscellaneousInfo = miscellaneousInfo;
            operation.Value1 = value1;
            operation.Value2 = value2;
            operation.OperationSymbol = operationSymbol;

            return operation;
        }
    }
}
