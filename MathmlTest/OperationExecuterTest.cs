using System;
using Xunit;
using Mathml;

namespace MathmlTest
{
    public class OperationExecuterTest
    {
        [Fact]
        public void Execute_NullValue_NothingHappens()
        {
            OperationExecuter.Execute(null);
        }
    }
}
