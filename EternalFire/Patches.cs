using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace EternalFire;

[HarmonyPatch(typeof(Firecamp), nameof(Firecamp.UpdateBuriningDuration))]
internal class Firecamp_UpdateBuriningDuration
{
    static void Prefix(Firecamp __instance)
    {
        __instance.m_EndlessFire = true;

        FieldInfo? f = __instance.GetType().GetField("m_BurningDuration", BindingFlags.NonPublic | BindingFlags.Instance);
        f?.SetValue(__instance, 0f);
    }
}

[HarmonyPatch(typeof(Forge), nameof(Forge.ConstantUpdate))]
internal class Forge_ConstantUpdate
{
    static void Prefix(Forge __instance)
    {
        FieldInfo? f = __instance.GetType().GetField("m_BurningDuration", BindingFlags.NonPublic | BindingFlags.Instance);
        f?.SetValue(__instance, 0f);
    }
}

[HarmonyPatch(typeof(Torch), nameof(Torch.UpdateMe))]
internal class Torch_UpdateMe
{
    static void Prefix(Torch __instance)
    {
        FieldInfo? f = __instance.GetType().GetField("m_BurningTime", BindingFlags.NonPublic | BindingFlags.Instance);
        f?.SetValue(__instance, 0f);
        __instance.m_Info.m_Health = 100f;
    }
}

[HarmonyPatch]
internal class Torch_IsInWater
{
    static MethodInfo TargetMethod()
    {
        return typeof(Torch)
            .GetMethod("IsInWater", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    static bool Prefix(ref bool __result)
    {
        __result = false;

        return false;
    }
}

[HarmonyPatch]
internal class Torch_CheckRain
{
    static MethodInfo TargetMethod()
    {
        return typeof(Torch)
            .GetMethod("CheckRain", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    static bool Prefix()
    {
        return false;
    }
}