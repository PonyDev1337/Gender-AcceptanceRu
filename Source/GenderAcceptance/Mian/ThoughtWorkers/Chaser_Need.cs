using GenderAcceptance.Mian.Needs;
using RimWorld;
using Verse;

namespace GenderAcceptance.Mian.ThoughtWorkers;

public class Need_Chaser : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        var chaserNeed = (Needs.Need_Chaser)p.needs.TryGetNeed(GADefOf.Need_Chaser);
        if (chaserNeed == null)
            return ThoughtState.Inactive;
        switch (chaserNeed.CurCategory)
        {
            case ChaserCategory.JustHadIntimacy:
                return ThoughtState.ActiveAtStage(0);
            case ChaserCategory.Neutral:
                return ThoughtState.Inactive;
            case ChaserCategory.LongWhile:
                return ThoughtState.ActiveAtStage(1);
            case ChaserCategory.ExtremelyLongWhile:
                return ThoughtState.ActiveAtStage(2);
            case ChaserCategory.Aching:
                return ThoughtState.ActiveAtStage(3);
            default:
                return ThoughtState.Inactive;
        }
    }
}