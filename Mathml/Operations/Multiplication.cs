namespace Mathml.Operations
{
    /// <summary>
    /// A muliplication operation. Multiplies the two values when executed.
    /// </summary>
    public class Multiplication : Operation
    {
        /// <summary>
        /// Executes the operation, which multiplies the two values.
        /// </summary>
        /// <returns>The result of multiplying the two values</returns>
        public override float Execute()
        {
            return Value1 * Value2;
        }
    }
}
