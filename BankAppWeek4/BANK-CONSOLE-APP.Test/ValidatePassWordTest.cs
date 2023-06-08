using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Validation;

namespace BANK_CONSOLE_APP.Test
{
        [TestFixture]
        public class ValidatePasswordTests
        {
            private StringWriter stringWriter;
            private StringReader stringReader;

            [SetUp]
            public void Setup()
            {
                stringWriter = new StringWriter();
                Console.SetOut(stringWriter);

                stringReader = new StringReader("P@ssw0rd");
                Console.SetIn(stringReader);
            }

            [TearDown]
            public void TearDown()
            {
                stringWriter.Dispose();
                stringReader.Dispose();
            }

            [Test]
            public void ValidPasswordCollector_ValidInput_ReturnsPassword()
            {
                // Arrange
                var validatePassword = new ValidatePassWord();

                // Act
                string password = validatePassword.ValidPasswordCollector();

                // Assert
                Assert.AreEqual("P@ssw0rd", password);
            }

                        [Test]
            public void IsValidPassword_ValidPassword_ReturnsTrue()
            {
                // Arrange
                var validatePassword = new ValidatePassWord();

                // Act
                bool isValid = validatePassword.IsValidPassword("P@ssw0rd");

                // Assert
                Assert.IsTrue(isValid);
            }

            [TestCase("short")]
            [TestCase("nouppercase")]
            [TestCase("NOLOWER")]
            [TestCase("nopasswordspecialcharacter")]
            public void IsValidPassword_InvalidPassword_ReturnsFalse(string password)
            {
                // Arrange
                var validatePassword = new ValidatePassWord();

                // Act
                bool isValid = validatePassword.IsValidPassword(password);

                // Assert
                Assert.IsFalse(isValid);
            }
        }
}
