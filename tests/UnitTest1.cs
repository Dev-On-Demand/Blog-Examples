using System;
using Custom_identity_Schema;
using Xunit;

namespace tests
{
    public class IdGenTests
    {
        [Fact]
        public void NewIdShouldReturnUniqueValues()
        {
            var idGen = new TestingExample();
            var id1 = idGen.IdGen();
            var id2 = idGen.IdGen();

            Assert.NotEqual(id1, id2);
        }
    }
}
