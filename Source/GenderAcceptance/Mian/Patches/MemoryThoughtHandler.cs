using System.Collections.Generic;
using GenderAcceptance.Mian.Needs;
using GenderAcceptance.Mian.Utilities;
using HarmonyLib;
using RimWorld;
using Verse;
using GenderUtility = GenderAcceptance.Mian.Utilities.GenderUtility;

namespace GenderAcceptance.Mian.Patches;

[HarmonyPatch(typeof(RimWorld.MemoryThoughtHandler))]
public static class MemoryThoughtHandler
{
    [HarmonyPatch(nameof(RimWorld.MemoryThoughtHandler.TryGainMemory), typeof(Thought_Memory), typeof(Pawn))]
    [HarmonyPostfix]
    public static void LovinThoughtApplied(RimWorld.MemoryThoughtHandler __instance, Thought_Memory newThought,
        Pawn otherPawn)
    {
        // this is like the universal sex thought
        if (newThought.def == ThoughtDefOf.GotSomeLovin)
        {
            Dictionary<string, string> constants =
                new()
                {
                    { "didSex", "True" }
                };
            var sus = !otherPawn.AppearsToHaveMatchingGenitalia();

            if (sus)
            {
                __instance.pawn.GetKnowledgeOnPawn(otherPawn).sex = true;
                TransKnowledgeManager.OnKnowledgeLearned(__instance.pawn, otherPawn, LetterDefOf.NeutralEvent,
                    constants: constants);
            }

            if (__instance.pawn.FindsExtraordinarilyAttractive(otherPawn))
            {
                ((Need_Chaser)__instance.pawn.needs?.TryGetNeed(GADefOf.Need_Chaser))?.GainNeedFromSex();
                otherPawn.needs?.mood?.thoughts?.memories?.TryGainMemory(GADefOf.Dehumanized, __instance.pawn);
            }
        }
    }
}