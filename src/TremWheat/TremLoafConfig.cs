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


    public class TremLoafConfig : IEntityConfig
    {
        public const string Id = "TremLoaf";
        public const string Name = "Trem Loaf";
        public static string Description = $"A thick loaf of fluffy, nicely baked {UI.FormatAsLink(TremGrainConfig.Name, TremGrainConfig.Id)}.\n\n.";
        public static string RecipeDescription = $"Nicely Baked {UI.FormatAsLink(TremGrainConfig.Name, TremGrainConfig.Id)}.\n\n.";

        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            var entity = EntityTemplates.CreateLooseEntity(
                id: Id,
                name: UI.FormatAsLink(Name, Id),
                desc: Description,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("frostbread_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.7f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                caloriesPerUnit: 1000000f,
                quality: 2,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: TUNING.FOOD.SPOIL_TIME.VERYSLOW,
                can_rot: true);

            var food = EntityTemplates.ExtendEntityToFood(entity, foodInfo);

            Recipe = AddComplexRecipe(
                input: new[] { new ComplexRecipe.RecipeElement(TremGrainConfig.Id, 3f) },
                output: new[] { new ComplexRecipe.RecipeElement(TremLoafConfig.Id, 1f) },
                fabricatorId: CookingStationConfig.ID,
                productionTime: 120f,
                recipeDescription: RecipeDescription,
                nameDisplayType: ComplexRecipe.RecipeNameDisplay.Result,
                sortOrder: 130
                );

            return food;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
