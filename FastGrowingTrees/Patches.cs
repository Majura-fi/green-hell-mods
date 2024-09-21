using System.Reflection;
using HarmonyLib;

namespace FastGrowingTrees;

[HarmonyPatch]
public static class StaticObjectsManager_UpdateGrowing
{
    static MethodInfo TargetMethod()
    {
        // We will use the private "UpdateGrowing" method as an entry point.
        // No other reasons than to make sure that we can be sure that 
        // our values will stick during the execution.
        return typeof(StaticObjectsManager)
            .GetMethod("UpdateGrowing", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    [HarmonyPrefix]
    static void Prefix(StaticObjectsManager __instance)
    {
        // Everything, that leaves a stump, normally grows fully in 7 days.
        // Now 7 days is handled in ~41 seconds. Basically you will never run out
        // trees to chop down if you focus on three or four trees.
        SetPrivateStaticFieldValue(__instance, "s_DayInMinutes", 5f);
        SetPrivateStaticFieldValue(__instance, "s_2DayInMinutes", 10f);
        SetPrivateStaticFieldValue(__instance, "s_3DayInMinutes", 15f);
        SetPrivateStaticFieldValue(__instance, "s_4DayInMinutes", 20f);
        SetPrivateStaticFieldValue(__instance, "s_7DayInMinutes", 25f);
    }

    static void SetPrivateStaticFieldValue(StaticObjectsManager __instance, string fieldName, float value)
    {
        try
        {
            FieldInfo? field = typeof(StaticObjectsManager)
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
        
            if (field == null)
            {
                Plugin.ModEntry?.Logger.Error(string.Format(
                    "Failed to get \"{0}\" field!", fieldName
                ));
                return;
            }

            field.SetValue(__instance, value);
        }
        catch (Exception ex)
        {
            Plugin.ModEntry?.Logger.Error(string.Format(
                "Failed to set value to the \"StaticObjectsManager.{0}\" field: {1}",
                fieldName,
                ex.Message
            ));
        }
    }
}