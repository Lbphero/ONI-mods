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
    public class TremGrainConfig : IEntityConfig
    {
        public static string Id = "TremGrain";
        public static string Name = "Trem Grain";
        public static string Description = "An inedible grain of Trem Wheat.";

        public GameObject CreatePrefab()
        {
            var entity = EntityTemplates.CreateLooseEntity(
                id: Id,
                name: UI.FormatAsLink(Name, Id),
                desc: Description,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("coldwheat_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.77f,
                height: 0.48f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                caloriesPerUnit: 0.0f,
                quality: TUNING.FOOD.FOOD_QUALITY_AWFUL,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: TUNING.FOOD.SPOIL_TIME.VERYSLOW,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(entity, foodInfo);

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
