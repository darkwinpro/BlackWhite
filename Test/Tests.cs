using System;
using NUnit.Framework;
using FluentAssertions;

namespace BlackWhiteTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void WhenConvertToBlackWhite_AndDataIsCorrect_ThenBlackWhitePixelAsResult()
        {
            // Arrange. 
            int width = 10;
            int height = 10;

            var red = new byte[width, height];
            var green = new byte[width, height];
            var blue = new byte[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    red[x, y] += (byte) (x + 15);
                    green[x, y] += (byte) (34 + y);
                    blue[x, y] += (byte) (10 + x);
                }
            }

            // Act. 
            BlackWhiteTask.Program.ConvertToBlackWhite(red, green, blue);

            // Assert. 
            red[0, 0].Should().Be(0);
            red[5, 5].Should().Be(255);
            red[7, 2].Should().Be(0);
            green[1, 2].Should().Be(0);
            green[5, 2].Should().Be(0);
            green[3, 7].Should().Be(255);
            blue[4, 1].Should().Be(0);
            blue[8, 9].Should().Be(255);
            blue[0, 1].Should().Be(0);
        }
    }
}