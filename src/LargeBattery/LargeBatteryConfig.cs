using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using STRINGS;
using UnityEngine;
using TUNING;
using BUILDINGS = TUNING.BUILDINGS;
using Database;
using LargeBattery;

namespace LargeBattery
{
    public class LargeBatteryConfig : BaseBatteryConfig
    {
        public const string Id = "LargeBattery";
        public const string DisplayName = "Huge Battery";
        public const string Description = "You know what they say, All Toasters, toast, Toast!";
        public static string Effect = $"Stores a large amount of power. 80 kilojoules to be exact.";

        public override BuildingDef CreateBuildingDef()
        {
            var buildingDef = BuildingTemplates.CreateBuildingDef(
                id: Id,
                width: 2,
                height: 3,
                anim: "batterylg_kanim",
                hitpoints: BUILDINGS.HITPOINTS.TIER2,
                construction_time: BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER2,
                construction_mass: BUILDINGS.CONSTRUCTION_MASS_KG.TIER5,
                construction_materials: MATERIALS.ALL_METALS,
                melting_point: BUILDINGS.MELTING_POINT_KELVIN.TIER3,
                build_location_rule: BuildLocationRule.OnFloor,
                decor: new EffectorValues { amount = -20, radius = 6 },
                noise: NOISE_POLLUTION.NOISY.TIER3);

            buildingDef.Floodable = true;
            buildingDef.Overheatable = true;
            buildingDef.AudioCategory = "Metal";
            buildingDef.RequiresPowerInput = true;
            buildingDef.UseWhitePowerOutputConnectorColour = true;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.ElectricalArrowOffset = new CellOffset(1, 0);
            buildingDef.SelfHeatKilowattsWhenActive = 1.35f;
            buildingDef.AudioSize = "small";
            SoundEventVolumeCache.instance.AddVolume("batterylg_kanim", "Battery_rattle", NOISE_POLLUTION.NOISY.TIER3);
            buildingDef.BaseTimeUntilRepair = -1f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
            buildingDef.DefaultAnimState = "off";

            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 80000;
            battery.joulesLostPerSecond = (float)((double)battery.capacity * 0.0500000009990581 / 600.0);
            battery.powerSortOrder = 1600;
            base.DoPostConfigureComplete(go);
        }
    }
}
