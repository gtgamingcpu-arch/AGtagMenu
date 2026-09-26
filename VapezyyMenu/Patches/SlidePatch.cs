using HarmonyLib;
using GorillaLocomotion;
using static VapeMenu.Menu.Main;

namespace VapeMenu.Patches
{
    [HarmonyPatch(typeof(GTPlayer), "GetSlidePercentage")]
    public class SlidePatch
    {
        private static void Postfix(GTPlayer __instance, ref float __result)
        {
            try
            {
                if (EverythingSlippery == true)
                {
                    __result = 1;
                }

                if (EverythingGrippy == true)
                {
                    __result = 0;
                }
            }
            catch { }
        }
    }
}