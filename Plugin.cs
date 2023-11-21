using BepInEx;
using HarmonyLib;
using MouseBind.Patches;

namespace MouseBind;

#pragma warning disable IDE0051

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
    void Awake() => new Harmony(PluginInfo.PLUGIN_GUID).PatchAll(typeof(AllowMouseBindings));
}