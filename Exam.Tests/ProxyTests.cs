using Xunit;

namespace Exam.Tests
{
    public class ProxyTests
    {
        [Fact]
        public void ProxyTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void FailingProxyTest()
        {
            Assert.True(false);
        }
    }
}