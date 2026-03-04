using RimWorld;
using Verse;

namespace GenderAcceptance.Mian.Utilities;

public static class SexualityUtility
{
    public static bool LikesSameGender(this Pawn pawn)
    {
        if (Constants.WBREnabled)
            return WBRUtility.LikesSameGender(pawn);
        
        return (pawn.story?.traits?.HasTrait(TraitDefOf.Gay) ?? false) || (pawn.story?.traits?.HasTrait(TraitDefOf.Bisexual) ?? false);
    }
}