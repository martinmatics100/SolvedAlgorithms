using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Accounts;

namespace BANK_CONSOLE_APP.Test
{
        [TestFixture]
        public class ChooseAccountTests
        {
            private StringWriter stringWriter;
            private StringReader stringReader;

            [SetUp]
            public void Setup()
            {
                stringWriter = new StringWriter();
                Console.SetOut(stringWriter);

                stringReader = new StringReader("1");
                Console.SetIn(stringReader);
            }

            [TearDown]
            public void TearDown()
            {
                stringWriter.Dispose();
                stringReader.Dispose();
            }

            [Test]
            public void AccountNumber_ValidInput_ReturnsAccountNumber()
            {
                // Arrange
                var chooseAccount = new ChooseAccount();
                stringReader = new StringReader("2");
                Console.SetIn(stringReader);

                // Act
                string accountNumber = chooseAccount.AccountNumber();

                // Assert
                Assert.IsTrue(int.TryParse(accountNumber, out int _));
            }

            [Test]
            public void AccountType_SavingsAccountChoice_ReturnsSavingsAccount()
            {
                // Arrange
                var chooseAccount = new ChooseAccount();
                chooseAccount.choice = "1";

                // Act
                string accountType = chooseAccount.AccountType();

                // Assert
                Assert.AreEqual("Savings Account", accountType);
            }

            [Test]
            public void AccountType_CurrentAccountChoice_ReturnsCurrentAccount()
            {
                // Arrange
                var chooseAccount = new ChooseAccount();
                chooseAccount.choice = "2";

                // Act
                string accountType = chooseAccount.AccountType();

                // Assert
                Assert.AreEqual("Current Account", accountType);
            }
        }
}
