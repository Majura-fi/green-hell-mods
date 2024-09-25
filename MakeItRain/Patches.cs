using System.Reflection;
using HarmonyLib;

namespace MakeItRain;

[HarmonyPatch]
internal class RainManager_UpdateAreaDensity
{
    static MethodInfo TargetMethod()
    {
        return typeof(RainManager).GetMethod("UpdateAreaDensity", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    static void Postfix()
    {
        RainManager __instance = RainManager.Get();
        MethodInfo m = __instance.GetType().GetMethod("GetAreaDensity", BindingFlags.NonPublic | BindingFlags.Instance);
        AreaDensity result = (AreaDensity)m.Invoke(__instance, null);

        // AreaDensity.Low and AreaDensity.None means 0% chance.
        // Let's bump it to 25% so we get a little bit of rain.
        if (result == AreaDensity.Low)
        {
            FieldInfo f = __instance.GetType().GetField("m_WantedAreaDensity", BindingFlags.NonPublic | BindingFlags.Instance);
            f.SetValue(__instance, 0.25f);
        }
    }
}
