using System.IO;
using System.Text;
using NUnit.Framework;

namespace KattisSolution.Tests
{
    [TestFixture]
    [Category("sample")]
    public class CustomTest
    {
        [Test]
        public void SampleTest_WithStringData_Should_Pass()
        {
            // Arrange
			const string expectedAnswer = "0x0 0\n0x0 0\n0xffffffff 4294967295\n";
			using (var input = new MemoryStream(Encoding.UTF8.GetBytes("0Xx0x0x0x0x0xffffffffJffffff00000121212686781631318761723")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }
    }
}
