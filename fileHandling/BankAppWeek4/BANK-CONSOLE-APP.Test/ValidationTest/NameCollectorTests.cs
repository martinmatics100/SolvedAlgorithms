using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Implementations;

namespace BANK_CONSOLE_APP.Test.ValidationTest
{
    [TestFixture]
    public class ValidNameCollectorTests
    {
        [Test]
        public void ValidNameCollector_ValidName_ReturnsName()
        {
            // Arrange
            var prompt = "name";
            var inputName = "John";
            var expectedName = "John";
            string userInput = $"{inputName}{Environment.NewLine}";

            // Arrange Console inputs and outputs
            var consoleInput = new StringReader(userInput);
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = new Validation();
            result.ValidNameCollector(prompt);

            // Assert
            Assert.AreEqual(expectedName, inputName);
            Assert.AreEqual($"Enter Your {prompt} (Kindly begin name with uppercase): ", consoleOutput.ToString());
        }

        //[Test]
        //public void ValidNameCollector_InvalidName_NotUpperCase()
        //{
        //    // Arrange
        //    var prompt = "name";
        //    var inputName = "john";
        //    //var expectedName = false;
        //    string userInput = $"{inputName}{Environment.NewLine}";

        //    // Arrange Console inputs and outputs
        //    var consoleInput = new StringReader(userInput);
        //    var consoleOutput = new StringWriter();
        //    Console.SetIn(consoleInput);
        //    Console.SetOut(consoleOutput);

        //    // Act
        //    var result = new Validation();
        //    result.ValidNameCollector(prompt);

        //    // Assert
        //    Assert.AreEqual($"Your name did not start with upper case, try again{Environment.NewLine}" +
        //        $"Enter Your {prompt} (Kindly begin name with uppercase): ", consoleOutput.ToString());
        //    Assert.IsEmpty((System.Collections.IEnumerable)result);
        //}

        //[Test]
        //public void ValidNameCollector_InvalidName_StartsWithDigit()
        //{
        //    // Arrange
        //    string prompt = "name";
        //    string inputName = "1John";
        //    string userInput = $"{inputName}{Environment.NewLine}";

        //    // Arrange Console inputs and outputs
        //    var consoleInput = new StringReader(userInput);
        //    var consoleOutput = new StringWriter();
        //    Console.SetIn(consoleInput);
        //    Console.SetOut(consoleOutput);

        //    // Act
        //    var result = new Validation();
        //    result.ValidNameCollector(prompt);

        //    // Assert
        //    Assert.AreEqual($"Your name must not start with a digit{Environment.NewLine}" +
        //        $"Enter Your {prompt} (Kindly begin name with uppercase): ", consoleOutput.ToString());
            
        //}
    }
}
