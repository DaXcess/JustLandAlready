using System;
using UnityEngine;

namespace JustLandAlready;

public class WaitUntilTimeout(Func<bool> predicate, float timeout) : CustomYieldInstruction
{
    private readonly float timeStarted = Time.realtimeSinceStartup;

    public override bool keepWaiting => !predicate() && Time.realtimeSinceStartup - timeStarted < timeout;
}

public class WaitUntilGenerated(Func<bool> predicate) : WaitUntilTimeout(predicate, Plugin.Config.GenerateMapMaxWaitTime.Value);
public class WaitUntilRevived(Func<bool> predicate) : WaitUntilTimeout(predicate, Plugin.Config.RevivePlayersMaxWaitTime.Value);
