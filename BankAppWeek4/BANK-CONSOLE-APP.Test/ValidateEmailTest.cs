using BANK_CONSOLE_APP.Validation;

namespace BANK_CONSOLE_APP.Test
{
    public class ValidateEmailTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidEmail_Test()
        {
            //Arrange
            var stu = new ValidateEmail();
            var expected = true;

            //Act
            var actual = stu.IsValidEmail("martin@gmail.com");
            var actual1 = stu.IsValidEmail("mar@outlook.com");
            var actual2 = stu.IsValidEmail("John@yahoo.com");


            //Assert
            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(expected, Is.EqualTo(actual1));
            Assert.That(expected, Is.EqualTo(actual2));
        }
    }
}