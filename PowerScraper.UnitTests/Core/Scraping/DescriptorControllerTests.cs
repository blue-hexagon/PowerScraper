using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.UnitTests.Core.Scraping
{
    [TestFixture]
    public class DescriptorTests
    {
        [SetUp]
        public void SetUp()
        {
            TreeAccessor.MakeTree();
        }

        // [Test]
        // public void CollectorsAreConnectedToCategories_DescriptorsAreConnected_NotNull()
        // {
        //     var collectors = DescriptorTreeLinkage.RootNode;
        //     foreach (var collector in collectors)
        //     {
        //         Assert.That(collector.CategoryDescriptor, Is.Not.Null);
        //     }
        // }
        //
        // [Test]
        // public void CategoriesAreConnectedToCollectors_DescriptorsAreConnected_CollectorCountIsGreaterThanZero()
        // {
        //     var categories = DescriptorController.CategoryDescriptorList;
        //     foreach (var category in categories)
        //     {
        //         Assert.That(category.Collectors.Count, Is.GreaterThan(0));
        //     }
        // }
        //
        // [Test]
        // public void RootDescriptorExists_DescriptorsAreConnected_IsNotNull()
        // {
        //     Assert.That(DescriptorController.GetCategoryFromCliArg("--all"), Is.Not.Null);
        // }
        //
        // [Test]
        // public void GetCategoryFromCliArg_CliArgDoesNotExists_ThrowsException()
        // {
        //     Assert.Throws<KeyNotFoundException>(() =>
        //         DescriptorController.GetCategoryFromCliArg("--invalid-collector")
        //     );
        // }
        //
        // [Test]
        // public void GetCollectorFromCliArg_CliArgDoesNotExists_ThrowsException()
        // {
        //     Assert.Throws<KeyNotFoundException>(() =>
        //         DescriptorController.GetCollectorFromCliArg("--invalid-category")
        //     );
        // }
    }
}