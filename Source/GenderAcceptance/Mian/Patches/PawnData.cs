using HarmonyLib;
using Verse;

namespace GenderAcceptance.Mian.Patches;

[HarmonyPatch(typeof(Pawn))]
public static class PawnData
{
    [HarmonyPatch(nameof(Pawn.ExposeData))]
    [HarmonyPostfix]
    public static void GetExtraData(ref Pawn __instance)
    {
        if (!__instance.RaceProps?.Humanlike ?? false)
            return;

        var transknowledge = __instance.GetModifiableTransgenderKnowledge(Scribe.mode == LoadSaveMode.Saving, false);
        var transvestigateTicks = __instance.GetLastTransvestigatedTicks();

        Scribe_Collections.Look(
            ref transknowledge,
            "GABelievedToBeTransgenders",
            LookMode.Deep);
        Scribe_Values.Look(ref transvestigateTicks, "GATransvestigateTicks");

        if (Scribe.mode != LoadSaveMode.Saving)
        {
            __instance.SetTransKnowledges(transknowledge);
            __instance.SetLastTransvestigatedTicks(transvestigateTicks);
        }
    }
}