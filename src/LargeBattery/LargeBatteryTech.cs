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
    [HarmonyPatch(typeof(Db), "Initialize")]
    public class LargeBatteryTech
    {
        public static void Prefix(Db __instance)
        {
            Debug.Log((object)"Large Battery - Loaded: ");
            List<string> stringList = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING["PowerRegulation"]);
            stringList.Add("LargeBattery");
            Techs.TECH_GROUPING["PowerRegulation"] = stringList.ToArray();
        }
    }
}
