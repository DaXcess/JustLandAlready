using BepInEx.Configuration;

namespace JustLandAlready;

public class Config(ConfigFile file)
{
    public ConfigEntry<float> GenerateMapMaxWaitTime { get; } = file.Bind("Timeouts", "GenerateMapMaxWaitTime", 30f, "The maximum time to wait for other players to generate the dungeon");
    public ConfigEntry<float> RevivePlayersMaxWaitTime { get; } = file.Bind("Timeouts", "RevivePlayersMaxWaitTime", 5f, "The maximum time to wait for other players to be revived until allowing the ship to land again");
}