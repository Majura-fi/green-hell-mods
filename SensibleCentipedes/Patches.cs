using System.Reflection;
using HarmonyLib;

namespace SensibleCentipedes;

[HarmonyPatch]
internal class HeavyObjectController_GetCentipedeProbability
{
    static MethodInfo TargetMethod()
    {
        return typeof(HeavyObjectController)
            .GetMethod("GetCentipedeProbability", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    static void Postfix(ref float __result)
    {
        // Result is [0.0, 0.5]
        // Use the result as a ratio for 10%.
        // 0.1f => 0.02f (2%)
        // 0.2f => 0.04f (4%)
        // 0.3f => 0.06f (6%)
        // 0.4f => 0.08f (8%)
        // 0.5f => 0.10f (10%)
        __result = (__result / 0.5f) * 0.1f;
    }
}
