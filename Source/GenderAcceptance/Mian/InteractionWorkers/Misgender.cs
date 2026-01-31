using System;
using System.Collections.Generic;
using GenderAcceptance.Mian.Utilities;
using RimWorld;
using Verse;

namespace GenderAcceptance.Mian.InteractionWorkers;

public class Misgender : InteractionWorker
{
    public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
    {
        var baseChance = 0.005f;
        var transphobicStatus = initiator.GetTransphobicStatus();
        if (transphobicStatus.GenerallyTransphobic && initiator.BelievesIsTrans(recipient))
            return 0;
        
        var genderMismatch = recipient.GetGenderedAppearance() != recipient.gender.GetGenderedAppearance() ? 0.05f : 0f;
        var relationship = -initiator.relations.OpinionOf(recipient) / 200;
        
        return Math.Max(0.001f, baseChance + genderMismatch + relationship);
    }

    public override void Interacted(
        Pawn initiator,
        Pawn recipient,
        List<RulePackDef> extraSentencePacks,
        out string letterText,
        out string letterLabel,
        out LetterDef letterDef,
        out LookTargets lookTargets)
    {
        letterText = null;
        letterLabel = null;
        letterDef = null;
        lookTargets = null;

        if (!initiator.GetTransphobicStatus().GenerallyTransphobic)
        {
            var thought = ThoughtMaker.MakeThought(GADefOf.Accidental_Misgender, 0);
            initiator.needs.mood.thoughts.memories.TryGainMemory(thought, recipient);
        }
    }
}