using NUnit.Framework;
using NUnit.Framework.Legacy;
using TheInn;

namespace TheInnTests;

[TestFixture]
public class QuickAndDirtyTests
{
    private TheInn.QuickAndDirty.TheInn _inn;

    [SetUp]
    public void Setup()
    {
        _inn = new TheInn.QuickAndDirty.TheInn();
    }

    [Test]
    public void TestAgeOneDay()
    {
        var expected = TestData.ItemsAgedOneDay;
        var actual = AgeItems(_inn, 1);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeFiveDays()
    {
        var expected = TestData.ItemsAgedFiveDays;
        var actual = AgeItems(_inn, 5);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeTenDays()
    {
        var expected = TestData.ItemsAgedTenDays;
        var actual = AgeItems(_inn, 10);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeTwentyDays()
    {
        var expected = TestData.ItemsAgedTwentyDays;
        var actual = AgeItems(_inn, 20);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    private static IList<EquitableItem> AgeItems(TheInn.QuickAndDirty.TheInn inn, int days)
    {
        for(var i = 0; i < days; i++)
        {
            inn.UpdateQuality();
        }

        return inn.Items.Select(item => new EquitableItem { Name = item.Name, SellIn = item.SellIn, Quality = item.Quality }).ToList();
    }
}