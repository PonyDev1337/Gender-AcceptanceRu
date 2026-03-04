using System.Collections.Generic;

namespace GenderAcceptance.Mian.Utilities;

public class Constants
{
    public static bool WBREnabled = false;
    public static string Version;

    public static readonly List<string> WarnOnUpdateToVersion = new()
    {
        "1.1"
    };
}