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

    public class TremBurgConfig : IEntityConfig
    {
        public const string Id = "TremBurg";
        public const string Name = "Seafood Burger";
        public static string Description = $"A large nicely stacked burger with loads of Flakey Fish inside.";
        public static string RecipeDescription = $"Stack some Seared Fish between two pieces of bread.";

        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            var entity = EntityTemplates.CreateLooseEntity(
                id: Id,
                name: UI.FormatAsLink(Name, Id),
                desc: Description,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("funguscapfried_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.7f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                caloriesPerUnit: 4000000f,
                quality: 3,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: TUNING.FOOD.SPOIL_TIME.VERYSLOW,
                can_rot: true);

            var food = EntityTemplates.ExtendEntityToFood(entity, foodInfo);

            Recipe = AddComplexRecipe(
                input: new[] { new ComplexRecipe.RecipeElement(TremLoafConfig.Id, 1f), new ComplexRecipe.RecipeElement(CookedFishConfig.ID, 1f) },
                output: new[] { new ComplexRecipe.RecipeElement(TremBurgConfig.Id, 1f) },
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

