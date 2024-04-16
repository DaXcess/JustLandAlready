using System.Runtime.CompilerServices;
using BepInEx.Logging;

namespace JustLandAlready;

public static class Logger
{
    private static ManualLogSource logSource;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetSource(ManualLogSource logger)
    {
        logSource = logger;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Log(object message)
    {
        logSource.LogInfo(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogInfo(object message)
    {
        logSource.LogInfo(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogWarning(object message)
    {
        logSource.LogWarning(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogError(object message)
    {
        logSource.LogError(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogDebug(object message)
    {
        logSource.LogDebug(message);
    }
}