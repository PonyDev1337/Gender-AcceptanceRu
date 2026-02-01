using Verse;

namespace GenderAcceptance.Mian;

public enum ActualGender
{
    Man,
    Woman,
    Enby
}

public static class ActualGenderExtensions
{
    public static Gender GetGameGender(this ActualGender actualGender)
    {
        switch (actualGender)
        {
            case ActualGender.Man:
                return Gender.Male;
            case ActualGender.Woman:
                return Gender.Female;
            default:
                return Gender.None;
        }
    }
}