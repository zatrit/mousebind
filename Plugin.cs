namespace MouseBind;

using BepInEx;
using HarmonyLib;
using MouseBind.Patches;

#pragma warning disable IDE0051

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
    private void Awake() {
        var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        harmony.PatchAll(typeof(AllowMouseBindings));
    }
}