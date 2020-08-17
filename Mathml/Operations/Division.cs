namespace Mathml.Operations
{
    /// <summary>
    /// A division operation. Divides the first value by the second when executed.
    /// </summary>
    public class Division : Operation
    {
        /// <summary>
        /// Executes the operation, which divides the first value by the second.
        /// </summary>
        /// <returns>The result of dividing the first value by the second</returns>
        public override float Execute()
        {
            return (float)Value1 / Value2;
        }
    }
}
