using HarmonyLib;

namespace SuperPlanter;

[HarmonyPatch(typeof(Acre), nameof(Acre.UpdateInternal))]
internal class Acre_UpdateInternal
{
    static void Prefix(Acre __instance)
    {
        __instance.m_WaterAmount = 100f;
        __instance.m_FertilizerAmount = 100f;
    }
}

[HarmonyPatch(typeof(AcreRespawnFruits), nameof(AcreRespawnFruits.UpdateInternal))]
internal class AcreRespawnFruits_UpdateInternal
{
    static void Prefix(AcreRespawnFruits __instance)
    {
        if (__instance.m_TimeToRespawn < 9f)
        {
            __instance.m_TimeToRespawn = 9f;
        }
    }
}
