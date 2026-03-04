using BetterRomance;
using Verse;

namespace GenderAcceptance.Mian.Utilities;

public class WBRUtility
{
    public static bool LikesSameGender(Pawn pawn)
    {
        return pawn.IsHomo() || pawn.IsBi();
    }
}