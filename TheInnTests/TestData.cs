using TheInn;

namespace TheInnTests;

internal static class TestData
{
    internal static IList<EquitableItem> ItemsAgedOneDay => new List<EquitableItem>
    {
        new() { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 },
        new() { Name = "Aged Brie", SellIn = 1, Quality = 1 },
        new() { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
        new() { Name = "Sulfuras", SellIn = 0, Quality = 80 },
        new() { Name = "Backstage passes", SellIn = 14, Quality = 21 },
        new() { Name = "Conjured", SellIn = 2, Quality = 4 }
    };

    internal static IList<EquitableItem> ItemsAgedFiveDays => new List<EquitableItem>
    {
        new() { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 15 },
        new() { Name = "Aged Brie", SellIn = -3, Quality = 8 },
        new() { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 2 },
        new() { Name = "Sulfuras", SellIn = 0, Quality = 80 },
        new() { Name = "Backstage passes", SellIn = 10, Quality = 25 },
        new() { Name = "Conjured", SellIn = -2, Quality = 0 }
    };

    internal static IList<EquitableItem> ItemsAgedTenDays => new List<EquitableItem>
    {
        new() { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 },
        new() { Name = "Aged Brie", SellIn = -8, Quality = 18 },
        new() { Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0 },
        new() { Name = "Sulfuras", SellIn = 0, Quality = 80 },
        new() { Name = "Backstage passes", SellIn = 5, Quality = 35 },
        new() { Name = "Conjured", SellIn = -7, Quality = 0 }
    };

    internal static IList<EquitableItem> ItemsAgedTwentyDays => new List<EquitableItem>
    {
        new() { Name = "+5 Dexterity Vest", SellIn = -10, Quality = 0 },
        new() { Name = "Aged Brie", SellIn = -18, Quality = 38 },
        new() { Name = "Elixir of the Mongoose", SellIn = -15, Quality = 0 },
        new() { Name = "Sulfuras", SellIn = 0, Quality = 80 },
        new() { Name = "Backstage passes", SellIn = -5, Quality = 0 },
        new() { Name = "Conjured", SellIn = -17, Quality = 0 }
    };
}