using BepInEx;
using HarmonyLib;
using MouseBind.Patches;

using static MouseBind.MyPluginInfo;

namespace MouseBind;

#pragma warning disable IDE0051

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
    void Awake() => new Harmony(PLUGIN_GUID).PatchAll(typeof(AllowMouseBindings));
}