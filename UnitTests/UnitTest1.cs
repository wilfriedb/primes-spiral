using System;
using Library;
using Xunit;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void TestMethod1()
    {
        (int, int, int)[] expected =
        [
            // Arrange
            (0,0,0),
            (1,1,0),
            (2,1,-1),
            (3,0,-1),
            (4,-1,-1),
            (5,-1,0),
            (6,-1,1),
            (7,0,1),
            (8,1,1),
            (9,2,1),
            (10,2,0),
            (11,2,-1),
            (12,2,-2),
            (13,1,-2),
            (14,0,-2),
            (15,-1,-2),
            (16,-2,-2),
            (17,-2,-1),
            (18,-2,0),
            (19,-2,1),
            (20,-2,2),
            (21,-1,2),
            (22,0,2),
            (23,1,2),
            (24,2,2),
            (25,3,2)
        ];
        var generator = new CoordinatesGenerator(3);

        // Act
        var enumerator = generator.GetCoordinates().GetEnumerator();

        // Assert
        foreach (var a in expected)
        {
            if (enumerator.MoveNext())
            {
                Assert.Equal(a, enumerator.Current);
            }
            else
            {
                break;
            }
        }

    }
}
