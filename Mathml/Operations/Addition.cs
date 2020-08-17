namespace Mathml.Operations
{
    /// <summary>
    /// An addition operation. Adds the two values together when executed.
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Executes the operation, which adds the two values together.
        /// </summary>
        /// <returns>The result of adding the two values</returns>
        public override float Execute()
        {
            return Value1 + Value2;
        }
    }
}
