using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Recognizers.Text.DataDrivenTests;

namespace Microsoft.Recognizers.Text.Number.Tests
{
    [TestClass]
    class TestNumber_Ukrainian : TestBase
    {
        public static TestResources TestResources { get; protected set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestResources = new TestResources();
            TestResources.InitFromTestContext(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestSpecInitialize(TestResources);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "NumberModel-Ukrainian.csv", "NumberModel-Ukrainian#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void NumberModel()
        {
            TestNumber();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "OrdinalModel-Ukrainian.csv", "OrdinalModel-Ukrainian#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void OrdinalModel()
        {
            TestNumber();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "PercentModel-Ukrainian.csv", "PercentModel-Ukrainian#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void PercentModel()
        {
            TestNumber();
        }
    }
}
