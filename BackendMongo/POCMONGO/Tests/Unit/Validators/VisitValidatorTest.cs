using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
{
    [TestClass]
    public class VisitValidatorTest
    {
        private VisitValidator validator;

        public void SetUp()
        {
            validator = new VisitValidator();
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

            Visit visit = new Visit();
            visit.period = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(visit));

            visit.period = null;
            Assert.IsFalse(validator.IsValid(visit));
        }

        [TestMethod]
        public void testValidatorOnInvalidResponsable()
        {
            SetUp();

            Visit visit = new Visit();
            visit.responsable = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(visit));

            visit.responsable = null;
            Assert.IsFalse(validator.IsValid(visit));
        }

        [TestMethod]
        public void testValidatorOnInvalidPlace()
        {
            SetUp();

            Visit visit = new Visit();
            visit.place = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(visit));

            visit.place = null;
            Assert.IsFalse(validator.IsValid(visit));
        }


        [TestMethod]
        public void testValidatorOnValidVisit()
        {
            SetUp();

            Visit visit = new Visit();
            visit.responsable = "Josias Machado";
            visit.period = "22/05/2024";
            visit.place = "Parque dos Macaquinhos - Caxias do Sul, RS";

            Assert.IsNotNull(validator);
            Assert.IsTrue(validator.IsValid(visit));
        }
    }
}
