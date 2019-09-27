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
using Testwheat;

namespace TestWheat
{


    public class TremWheatPatches
    {
        [HarmonyPatch(typeof(EntityConfigManager))]
        [HarmonyPatch(nameof(EntityConfigManager.LoadGeneratedEntities))]
        public class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                AddPlantStrings(TremWheatConfig.Id, TremWheatConfig.Name, TremWheatConfig.Description, TremWheatConfig.DomesticatedDescription);
                AddPlantSeedStrings(TremWheatConfig.Id, TremWheatConfig.SeedName, TremWheatConfig.SeedDescription);
                AddFoodStrings(TremLoafConfig.Id, TremLoafConfig.Name, TremLoafConfig.Description, TremLoafConfig.RecipeDescription);
                AddFoodStrings(TremBurgConfig.Id, TremBurgConfig.Name, TremBurgConfig.Description, TremBurgConfig.RecipeDescription);
                AddFoodStrings(TremGrainConfig.Id, TremGrainConfig.Name, TremGrainConfig.Description);
                AddCropType(TremGrainConfig.Id, 5, 16);
            }
        }

    }
}
