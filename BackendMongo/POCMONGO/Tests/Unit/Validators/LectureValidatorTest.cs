using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
{
    [TestClass]
    public class LectureValidatorTest
    {
        private LectureValidator validator;

        public void SetUp()
        {
            validator = new LectureValidator();
        }

        [TestMethod]
        public void testValidatorOnNull()
        {
            SetUp();
            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(null));
        }

        [TestMethod]
        public void testValidatorOnInvalidDate()
        {
            SetUp();

            Lecture lecture = new Lecture();
            lecture.datetime = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(lecture));

            lecture.datetime = null;
            Assert.IsFalse(validator.IsValid(lecture));
        }

        [TestMethod]
        public void testValidatorOnInvalidResponsable()
        {
            SetUp();

            Lecture lecture = new Lecture();
            lecture.person = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(lecture));

            lecture.person = null;
            Assert.IsFalse(validator.IsValid(lecture));
        }

        [TestMethod]
        public void testValidatorOnInvalidPlace()
        {
            SetUp();

            Lecture lecture = new Lecture();
            lecture.local = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(lecture));

            lecture.local = null;
            Assert.IsFalse(validator.IsValid(lecture));
        }

        [TestMethod]
        public void testValidatorOnValidLecture()
        {
            SetUp();

            Lecture lecture = new Lecture();
            lecture.datetime = "08/08/2022";
            lecture.person = "Gildo";
            lecture.local = "UCS  - CDX410";

            Assert.IsTrue(validator.IsValid(lecture));
        }
    }
}
