using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    public interface ICraftRecipe
    {
        public ItemName GetCraftItem(int qty_one, int qty_two);
    }

    public class StoneWoodCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Stone1Wood1,
            [(1, 2)] = ItemName.Stone1Wood2,
            [(2, 1)] = ItemName.Stone2Wood1,
            [(2, 2)] = ItemName.Stone2Wood2,
        };
        public ItemName GetCraftItem(int qty_one, int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public class StoneIronCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Stone1Iron1,
            [(1, 2)] = ItemName.Stone1Iron2,
            [(2, 1)] = ItemName.Stone2Iron1,
            [(2, 2)] = ItemName.Stone2Iron2,
        };

        public ItemName GetCraftItem(int qty_one,int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public class StoneOilCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Stone1Oil1,
            [(1, 2)] = ItemName.Stone1Oil2,
            [(2, 1)] = ItemName.Stone2Oil1,
            [(2, 2)] = ItemName.Stone2Iron2,
        };

        public ItemName GetCraftItem(int qty_one, int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public class WoodIronCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Wood1Iron1,
            [(1, 2)] = ItemName.Wood1Iron2,
            [(2, 1)] = ItemName.Wood2Iron1,
            [(2, 2)] = ItemName.Wood2Iron2,
        };

        public ItemName GetCraftItem(int qty_one, int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public class WoodOilCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Wood1Oil1,
            [(1, 2)] = ItemName.Wood1Oil2,
            [(2, 1)] = ItemName.Wood2Oil1,
            [(2, 2)] = ItemName.Wood2Oil2,
        };

        public ItemName GetCraftItem(int qty_one, int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public class IronOilCraftRecipe : ICraftRecipe
    {
        Dictionary<(int, int), ItemName> recipeDict = new Dictionary<(int, int), ItemName>
        {
            [(0, 0)] = ItemName.None,
            [(1, 0)] = ItemName.None,
            [(0, 1)] = ItemName.None,
            [(1, 1)] = ItemName.Iron1Oil1,
            [(1, 2)] = ItemName.Iron1Oil2,
            [(2, 1)] = ItemName.Iron2Oil1,
            [(2, 2)] = ItemName.Iron2Oil2,
        };

        public ItemName GetCraftItem(int qty_one, int qty_two)
        {
            var tuple = (qty_one, qty_two);
            return recipeDict[tuple];
        }
    }

    public static class CraftRecipeClassifier
    {
        public static ICraftRecipe GetCraftRecipe(ItemName firstItem, ItemName secondItem)
        {
            var tuple = (firstItem, secondItem);
            switch (tuple)
            {
                case (ItemName.Stone, ItemName.Wood):
                    return new StoneWoodCraftRecipe();
                case (ItemName.Stone, ItemName.Iron):
                    return new StoneIronCraftRecipe();
                case (ItemName.Stone, ItemName.Oil):
                    return new StoneOilCraftRecipe();
                case (ItemName.Wood, ItemName.Iron):
                    return new WoodIronCraftRecipe();
                case (ItemName.Wood, ItemName.Oil):
                    return new WoodOilCraftRecipe();
                case (ItemName.Iron, ItemName.Oil):
                    return new IronOilCraftRecipe();
                default:
                    return null;
            }
        }
    }
}
