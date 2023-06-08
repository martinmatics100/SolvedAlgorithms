using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Validation;

namespace BANK_CONSOLE_APP.Test
{
    internal class ValidateFirstNameTest
    {
        private StringWriter stringWriter;
        private StringReader stringReader;

        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            stringReader = new StringReader("Martin");
            Console.SetIn(stringReader);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Dispose();
            stringReader.Dispose();
        }
        [Test]
        public void ValidFNameCollector_ValidInput_ReturnsFirstName()
        {
            // Arrange
            var validateFirstName = new ValidateFirstName();

            // Act
            string firstName = validateFirstName.ValidFNameCollector();

            // Assert
            Assert.AreEqual("Martin", firstName);
        }
    }
}
