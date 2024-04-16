using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace JustLandAlready;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private const string PLUGIN_GUID = "io.daxcess.justlandalready";
    private const string PLUGIN_NAME = "JustLandAlready";
    private const string PLUGIN_VERSION = "1.0.0";

    public new static Config Config { get; private set; }

    private void Awake()
    {
        JustLandAlready.Logger.SetSource(Logger);
        Config = new Config(base.Config);

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        Logger.LogInfo("I don't wanna wait!");
    }
}