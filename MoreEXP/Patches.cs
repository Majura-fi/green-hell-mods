using HarmonyLib;

namespace MoreEXP;

[HarmonyPatch(typeof(SkillCurve), nameof(SkillCurve.Progress))]
internal class SkillCurve_Progress
{
    static void Postfix(ref float __result)
    {
        __result *= 100f;
    }
}
