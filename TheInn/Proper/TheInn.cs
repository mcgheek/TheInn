namespace TheInn.Proper;

public class TheInn
{

    public IList<Item> Items = new List<Item>
     {
         new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
         new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
         new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
         new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 },
         new Item { Name = "Backstage passes", SellIn = 15, Quality = 20 },
         new Item { Name = "Conjured", SellIn = 3, Quality = 6 }
     };

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (!ParseItemTypeEnum(item, out var itemType)) continue;
            DecreaseQuality(itemType, item);
            DecrementSellIn(itemType, item);
            if (IsExpired(item)) continue;
            HandleExpiredItems(itemType, item);
        }
    }

    private static bool ParseItemTypeEnum(Item item, out ItemTypeEnum itemType)
    {
        switch (item.Name)
        {
            case "+5 Dexterity Vest":
                itemType = ItemTypeEnum.DexterityVest;
                break;
            case "Aged Brie":
                itemType = ItemTypeEnum.AgedBrie;
                break;
            case "Elixir of the Mongoose":
                itemType = ItemTypeEnum.ElixirOfTheMongoose;
                break;
            case "Sulfuras":
                itemType = ItemTypeEnum.Sulfuras;
                break;
            case "Backstage passes":
                itemType = ItemTypeEnum.BackstagePasses;
                break;
            case "Conjured":
                itemType = ItemTypeEnum.Conjured;
                break;
            default:
                itemType = default;
                return false;
        }

        return true;
    }

    private static void HandleExpiredItems(ItemTypeEnum itemType, Item item)
    {
        if (itemType != ItemTypeEnum.AgedBrie)
        {
            if (itemType != ItemTypeEnum.BackstagePasses)
            {
                if (item.Quality <= 0) return;
                switch (itemType)
                {
                    case ItemTypeEnum.Sulfuras:
                        return;
                    case ItemTypeEnum.Conjured:
                        item.Quality -= 2;
                        break;
                    case ItemTypeEnum.DexterityVest or ItemTypeEnum.AgedBrie or ItemTypeEnum.ElixirOfTheMongoose
                        or ItemTypeEnum.BackstagePasses:
                        break;
                    default:
                        item.Quality -= 1;
                        break;
                }
            }
            else
            {
                item.Quality = 0;
            }
        }
        else
        {
            item.Quality += 1;
        }
    }

    private static void DecrementSellIn(ItemTypeEnum itemType, Item item)
    {
        if (itemType != ItemTypeEnum.Sulfuras)
        {
            item.SellIn -= 1;
        }
    }

    private static bool IsExpired(Item item)
    {
        return item.SellIn >= 0;
    }

    private static void DecreaseQuality(ItemTypeEnum itemType, Item item)
    {
        if (itemType != ItemTypeEnum.AgedBrie && itemType != ItemTypeEnum.BackstagePasses)
        {
            if (item.Quality <= 0) return;
            if (itemType == ItemTypeEnum.Conjured)
            {
                item.Quality -= 2;
            }
            else if (itemType != ItemTypeEnum.Sulfuras)
            {
                item.Quality -= 1;
            }
        }
        else
        {
            if (item.Quality >= 50) return;
            item.Quality += 1;
            AdjustQualityForBackStagePasses(itemType, item);
        }
    }

    private static void AdjustQualityForBackStagePasses(ItemTypeEnum itemType, Item item)
    {
        if (itemType != ItemTypeEnum.BackstagePasses) return;
        if (item is { SellIn: < 11, Quality: < 50 })
        {
            item.Quality += 1;
        }

        if (item is { SellIn: < 6, Quality: < 50 })
        {
            item.Quality += 1;
        }
    }
}