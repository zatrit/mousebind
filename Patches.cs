using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;

using static UnityEngine.InputSystem.InputActionRebindingExtensions;

namespace MouseBind.Patches;

[HarmonyPatch(typeof(IngamePlayerSettings), "RebindKey")]
public class AllowMouseBindings {
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes) =>
        codes.Where(code => {
            var isLdstrMouse = code.opcode == OpCodes.Ldstr && code.OperandIs("Mouse");
            var isExcludeCall = code.Calls(typeof(RebindingOperation).GetMethod("WithControlsExcluding"));

            return !isLdstrMouse && !isExcludeCall;
        });
}