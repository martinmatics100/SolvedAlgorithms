using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Validation;

namespace BANK_CONSOLE_APP.Test
{
    public class ValidateLastNameTest
    {
        private StringWriter stringWriter;
        private StringReader stringReader;

        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            stringReader = new StringReader("Nwatu");
            Console.SetIn(stringReader);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Dispose();
            stringReader.Dispose();
        }
        [Test]
        public void ValidLNameCollector_ValidInput_ReturnsLastName()
        {
            // Arrange
            var validateLastName = new ValidateLastName();

            // Act
            string lastName = validateLastName.ValidLNameCollector();

            // Assert
            Assert.AreEqual("Nwatu", lastName);
        }
    }
}
