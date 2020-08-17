namespace Mathml.Operations
{
    /// <summary>
    /// A subtraction operation. Subtracts the second value from the first when executed.
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Executes the operation, which subtracts the second value from the first.
        /// </summary>
        /// <returns>The result of subtracting the second value from the first</returns>
        public override float Execute()
        {
            return Value1 - Value2;
        }
    }
}
