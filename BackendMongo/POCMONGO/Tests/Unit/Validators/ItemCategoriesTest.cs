using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
{
    [TestClass]
    public class ItemCategoriesTest
    {
        [TestMethod]
        public void testItemCategoriesOnValidValues()
        {
            ItemCategories ic = new ItemCategories();
            Assert.IsTrue(ic.IsValid(ItemCategories.CPU));
            Assert.IsTrue(ic.IsValid(ItemCategories.RAM));
            Assert.IsTrue(ic.IsValid(ItemCategories.DISK));
            Assert.IsTrue(ic.IsValid(ItemCategories.SERVER));
            Assert.IsTrue(ic.IsValid(ItemCategories.BOARDS));
            Assert.IsTrue(ic.IsValid(ItemCategories.PHONE));
        }

        [TestMethod]
        public void testItemCategoriesOnInalidValues()
        {
            ItemCategories ic = new ItemCategories();
            Assert.IsFalse(ic.IsValid(-66));
            Assert.IsFalse(ic.IsValid(-13));
        }
    }
}
