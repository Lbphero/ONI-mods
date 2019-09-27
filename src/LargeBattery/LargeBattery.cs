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
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public class LargeBattery
    {
        public static void Prefix()
        {
            Debug.Log((object)"LargeBattery - Prefix: ");
            Strings.Add("STRINGS.BUILDINGS.PREFABS.LARGEBATTERY.NAME", "Huge Battery");
            Strings.Add("STRINGS.BUILDINGS.PREFABS.LARGEBATTERY.DESC", "You know what they say, All Toasters, toast, Toast!");
            Strings.Add("STRINGS.BUILDINGS.PREFABS.LARGEBATTERY.EFFECT", "Stores an awful lot of power.");
            ModUtil.AddBuildingToPlanScreen((HashedString)"Power", "LargeBattery");
        }
    }

}
