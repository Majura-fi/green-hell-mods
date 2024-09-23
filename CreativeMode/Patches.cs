using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode;

[HarmonyPatch(typeof(ConstructionGhost), nameof(ConstructionGhost.UpdateState))]
internal class Patch_ConstructionGhost_UpdateState
{
    static void Prefix(ConstructionGhost __instance)
    {
        if ((int)Traverse.Create(__instance).Field("m_State").GetValue() == 1)
        {
            Traverse.Create(__instance).Field("m_CurrentStep").SetValue(999);
            (Traverse.Create(ConstructionGhostManager.Get()).Field("m_AllGhosts").GetValue() as List<ConstructionGhost>)
            ?.ForEach((b) => Traverse.Create(b).Field("m_CurrentStep").SetValue(999));
        }
    }
}