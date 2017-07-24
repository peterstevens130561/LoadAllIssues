namespace Connector.UnitTest
{
    /// <summary>
    /// Each paged service should implement these simple tests
    /// </summary>
    public interface IPagedServiceTest
    {
        /// <summary>
        /// Test that all parameters can be set
        /// </summary>
        void ParametersTest();

        /// <summary>
        /// Test that the Page implementation is doing its work
        /// Create a first page with one element, then a second one with no elements
        /// Check that the resulting list has one element, and that it is the same
        /// </summary>
        void PageTest();
    }
}