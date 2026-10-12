
using System.Diagnostics;

namespace ServiceA.Telemetry;

public static class ActivitySources
{
    public static readonly ActivitySource Source =
        new("service-a");
}