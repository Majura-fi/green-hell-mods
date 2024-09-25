using HarmonyLib;

namespace CreativeMode;

[HarmonyPatch(typeof(ConstructionGhost), nameof(ConstructionGhost.SetState))]
internal class ConstructionGhost_SetState
{
    static void Postfix(ConstructionGhost __instance)
    {
        // Build only the placed down ghost.
        // Otherwise we will build things in our hands.
        if (__instance.m_State == ConstructionGhost.GhostState.Building)
        {
            __instance.m_CurrentStep = 999;

            // Iterate all childsteps, such as bridges, fences and palisades.
            foreach (GhostStep step in __instance.m_Steps)
            {
                foreach (GhostSlot slot in step.m_Slots)
                {
                    slot.Fulfill();
                }
            } 
        }
    }
}