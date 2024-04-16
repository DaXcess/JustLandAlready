using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using static HarmonyLib.AccessTools;

namespace JustLandAlready;

[HarmonyPatch]
internal static class JustLandAlreadyPatches
{
    /// <summary>
    /// Inserts the timeout patch for the players fired cinematic
    /// </summary>
    [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.playersFiredGameOver), MethodType.Enumerator)]
    [HarmonyTranspiler]
    [HarmonyDebug]
    private static IEnumerable<CodeInstruction> PlayersFiredGameOverPatch(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false, [new CodeMatch(OpCodes.Stfld, Field(typeof(StartOfRound), nameof(StartOfRound.playersRevived)))])
            .Advance(5)
            .SetOperandAndAdvance(Constructor(typeof(WaitUntilRevived)))
            .InstructionEnumeration();
    }

    /// <summary>
    /// Inserts the timeout patch for the end of the game (after players have been revived)
    /// </summary>
    [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.EndOfGame), MethodType.Enumerator)]
    [HarmonyTranspiler]
    [HarmonyDebug]
    private static IEnumerable<CodeInstruction> EndOfGamePatch(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false, [new CodeMatch(OpCodes.Stfld, Field(typeof(StartOfRound), nameof(StartOfRound.playersRevived)))])
            .Advance(5)
            .SetOperandAndAdvance(Constructor(typeof(WaitUntilRevived)))
            .InstructionEnumeration();
    }

    /// <summary>
    /// Inserts the timeout patch for generating the dungeon
    /// </summary>
    [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.LoadNewLevelWait), MethodType.Enumerator)]
    [HarmonyTranspiler]
    [HarmonyDebug]
    private static IEnumerable<CodeInstruction> LoadNewLevelWaitPatch(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false, [new CodeMatch(OpCodes.Ldstr, "Players finished generating the new floor")])
            .Advance(-10)
            .SetOperandAndAdvance(Constructor(typeof(WaitUntilGenerated)))
            .InstructionEnumeration();
    }
}