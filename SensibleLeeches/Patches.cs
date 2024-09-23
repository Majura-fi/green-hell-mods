using System.Reflection;
using HarmonyLib;

namespace SensibleLeeches;

[HarmonyPatch(typeof(PlayerInjuryModule), nameof(PlayerInjuryModule.CheckLeeches))]
internal class PlayerInjuryModule_CheckLeeches
{
    static void Prefix(PlayerInjuryModule __instance)
    {
        FieldInfo? f = __instance.GetType().GetField("m_LeechChanceOutsideOfWater", BindingFlags.NonPublic | BindingFlags.Instance);
        f?.SetValue(__instance, 0.05f);

        if (f == null)
        {
            Plugin.ModEntry?.Logger.Warning("m_LeechChanceOutsideOfWater not found.");
        }
    }
}
