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
    public class TremWheatConfig : IEntityConfig
{
    public const string Id = "TremWheatPlant";
    public const string SeedId = "TremWheatSeed";

    public static string Name = "Trem Wheat";
    public static string Description = $"A Small, Crunchy {UI.FormatAsLink("Plant", "PLANTS")} that grows fair amounts of grain in warm environments.";
    public static string DomesticatedDescription = $"A Small, Crunchy {UI.FormatAsLink("Plant", "PLANTS")} that grows fair amounts of grain in warm environments.";

    public static string SeedName = "Trem Wheat Seed";
    public static string SeedDescription = $"The {UI.FormatAsLink("Seed", "PLANTS")} of a {UI.FormatAsLink(Name, Id)}.";
    private const string AnimName = "custom_tremwwheat_kanim";
    private const string AnimNameSeed = "seed_gassygrass_kanim";

    public GameObject CreatePrefab()
    {
        var placedEntity = EntityTemplates.CreatePlacedEntity(
            id: Id,
            name: Name,
            desc: Description,
            mass: 1f,
            anim: Assets.GetAnim(AnimName),
            initialAnim: "idle_loop",
            sceneLayer: Grid.SceneLayer.BuildingFront,
            width: 1,
            height: 2,
            decor: DECOR.BONUS.TIER2,
            defaultTemperature: 320f);

        EntityTemplates.ExtendEntityToBasicPlant(
            template: placedEntity,
            temperature_lethal_low: 283.15f,
            temperature_warning_low: 294.25f,
            temperature_warning_high: 310.15f,
            temperature_lethal_high: 323.15f,
            safe_elements: new[] { SimHashes.CarbonDioxide, SimHashes.Oxygen, SimHashes.ContaminatedOxygen },
            crop_id: TremGrainConfig.Id);

        placedEntity.AddOrGet<TremWheat>();

        var consumer = placedEntity.AddOrGet<ElementConsumer>();
        consumer.elementToConsume = SimHashes.Water;
        consumer.consumptionRate = 0.0233334f;

        var seed = EntityTemplates.CreateAndRegisterSeedForPlant(
            plant: placedEntity,
            id: SeedId,
            name: UI.FormatAsLink(SeedName, Id),
            desc: SeedDescription,
            productionType: SeedProducer.ProductionType.Harvest,
            anim: Assets.GetAnim(AnimNameSeed),
            numberOfSeeds: 0,
            additionalTags: new List<Tag> { GameTags.CropSeed },
            sortOrder: 9,
            domesticatedDescription: "Coolboyoclock",
            width: 0.33f,
            height: 0.33f);

        EntityTemplates.CreateAndRegisterPreviewForPlant(
            seed: seed,
            id: "TremWheat_preview",
            anim: Assets.GetAnim(AnimName),
            initialAnim: "place",
            width: 1,
            height: 1);

        SoundEventVolumeCache.instance.AddVolume("bristleblossom_kanim", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);

        return placedEntity;
    }

    public void OnPrefabInit(GameObject inst)
    {
    }

    public void OnSpawn(GameObject inst)
    {
    }
}
}