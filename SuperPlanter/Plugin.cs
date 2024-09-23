using System.Reflection;
using HarmonyLib;
using static UnityModManagerNet.UnityModManager;

namespace SuperPlanter;

public static class Plugin
{
    private static Harmony? harmony;
    public static ModEntry? ModEntry { get; private set; }
    public static bool Enabled { get; private set; }

    public static bool Load(ModEntry mod)
    {
        harmony = new Harmony(mod.Info.Id);

        ModEntry = mod;
        ModEntry.OnToggle = OnToggle;
        ModEntry.Logger.Log("SuperPlanter loaded.");
        return true;
    }

    private static bool OnToggle(ModEntry entry, bool enable)
    {
        if (enable)
        {
            harmony!.PatchAll(Assembly.GetExecutingAssembly());
            entry.Logger.Log("SuperPlanter enabled.");
        }
        else
        {
            harmony!.UnpatchAll(ModEntry!.Info.Id);
            entry.Logger.Log("SuperPlanter disabled.");
        }

        Enabled = enable;
        return true;
    }
}
