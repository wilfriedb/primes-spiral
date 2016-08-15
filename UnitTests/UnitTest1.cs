using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = new[]
            {
                // Arrange
                Tuple.Create(0,0,0),
                Tuple.Create(1,1,0),
                Tuple.Create(2,1,-1),
                Tuple.Create(3,0,-1),
                Tuple.Create(4,-1,-1),
                Tuple.Create(5,-1,0),
                Tuple.Create(6,-1,1),
                Tuple.Create(7,0,1),
                Tuple.Create(8,1,1),
                Tuple.Create(9,2,1),
                Tuple.Create(10,2,0),
                Tuple.Create(11,2,-1),
                Tuple.Create(12,2,-2),
                Tuple.Create(13,1,-2),
                Tuple.Create(14,0,-2),
                Tuple.Create(15,-1,-2),
                Tuple.Create(16,-2,-2),
                Tuple.Create(17,-2,-1),
                Tuple.Create(18,-2,0),
                Tuple.Create(19,-2,1),
                Tuple.Create(20,-2,2),
                Tuple.Create(21,-1,2),
                Tuple.Create(22,0,2),
                Tuple.Create(23,1,2),
                Tuple.Create(24,2,2),
                Tuple.Create(25,3,2)
            };
            var generator = new CoordinateGenerator(3);

            // Act
            var enumerator = generator.GetCoordinates().GetEnumerator();

            // Assert
            foreach (var a in expected)
            {
                if (enumerator.MoveNext())
                {
                    Assert.AreEqual(a, enumerator.Current);
                }
                else
                {
                    break;
                }
            }

        }
    }
}
