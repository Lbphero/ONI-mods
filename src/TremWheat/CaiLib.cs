using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STRINGS;
using Harmony;
using UnityEngine;
using Klei;
using TUNING;
using CREATURES = STRINGS.CREATURES;
using static CaiLib.Utils.RecipeUtils;
using static CaiLib.Utils.PlantUtils;
using static CaiLib.Utils.StringUtils;

namespace CaiLib.Utils
{
    public class RecipeUtils
    {
        public static ComplexRecipe AddComplexRecipe(ComplexRecipe.RecipeElement[] input, ComplexRecipe.RecipeElement[] output,
            string fabricatorId, float productionTime, string recipeDescription, ComplexRecipe.RecipeNameDisplay nameDisplayType, int sortOrder, string requiredTech = null)
        {
            var recipeId = ComplexRecipeManager.MakeRecipeID(fabricatorId, input, output);

            return new ComplexRecipe(recipeId, input, output)
            {
                time = productionTime,
                description = recipeDescription,
                nameDisplay = nameDisplayType,
                fabricators = new List<Tag> { fabricatorId },
                sortOrder = sortOrder,
                requiredTech = requiredTech
            };
        }
    }

    public class PlantUtils
    {
        public static void AddCropType(string cropId, float domesticatedGrowthTimeInCycles, int producedPerHarvest)
        {
            CROPS.CROP_TYPES.Add(new Crop.CropVal(cropId, domesticatedGrowthTimeInCycles * 600, producedPerHarvest));
        }
    }

    public static class StringUtils
    {
        public static void AddBuildingStrings(string buildingId, string name, string description, string effect)
        {
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{buildingId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, buildingId));
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{buildingId.ToUpperInvariant()}.DESC", description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{buildingId.ToUpperInvariant()}.EFFECT", effect);
        }

        public static void AddPlantStrings(string plantId, string name, string description, string domesticatedDescription)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, plantId));
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DESC", description);
            Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DOMESTICATEDDESC", domesticatedDescription);
        }

        public static void AddPlantSeedStrings(string plantId, string name, string description)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{plantId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, plantId));
            Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{plantId.ToUpperInvariant()}.DESC", description);
        }

        public static void AddFoodStrings(string foodId, string name, string description, string recipeDescription = null)
        {
            Strings.Add($"STRINGS.ITEMS.FOOD.{foodId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, foodId));
            Strings.Add($"STRINGS.ITEMS.FOOD.{foodId.ToUpperInvariant()}.DESC", description);

            if (recipeDescription != null)
                Strings.Add($"STRINGS.ITEMS.FOOD.{foodId.ToUpperInvariant()}.RECIPEDESC", recipeDescription);
        }
    }
}
