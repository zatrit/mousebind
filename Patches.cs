using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine.InputSystem;

namespace MouseBind.Patches;

[HarmonyPatch(typeof(IngamePlayerSettings), "RebindKey")]
public class AllowMouseBindings {
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes) {
        foreach (var code in codes) {
            var isLdstrMouseCall = code.opcode == OpCodes.Ldstr && code.operand is string operand && operand == "Mouse";
            var isRebindCall = code.Calls(typeof(InputActionRebindingExtensions.RebindingOperation).GetMethod("WithControlsExcluding"));

            if (!isLdstrMouseCall && !isRebindCall) {
                yield return code;
            }
        }
    }
}