using NUnit.Framework;
using NUnit.Framework.Legacy;
using TheInn;

namespace TheInnTests;

[TestFixture]
public class ProperTests
{
    private TheInn.Proper.TheInn inn;

    [SetUp]
    public void Setup()
    {
        inn = new TheInn.Proper.TheInn();
    }

    [Test]
    public void TestAgeOneDay()
    {
        var expected = TestData.ItemsAgedOneDay;
        var actual = AgeItems(inn, 1);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeFiveDays()
    {
        var expected = TestData.ItemsAgedFiveDays;
        var actual = AgeItems(inn, 5);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeTenDays()
    {
        var expected = TestData.ItemsAgedTenDays;
        var actual = AgeItems(inn, 10);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void TestAgeTwentyDays()
    {
        var expected = TestData.ItemsAgedTwentyDays;
        var actual = AgeItems(inn, 20);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    private static IList<EquitableItem> AgeItems(TheInn.Proper.TheInn inn, int days)
    {
        for (var i = 0; i < days; i++)
        {
            inn.UpdateQuality();
        }

        return inn.Items.Select(item => new EquitableItem { Name = item.Name, SellIn = item.SellIn, Quality = item.Quality }).ToList();
    }
}