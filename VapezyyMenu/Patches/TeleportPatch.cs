using HarmonyLib;
using UnityEngine;
using static VapeMenu.Menu.Main;

namespace VapeMenu.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer), "LateUpdate")]
    public class TeleportPatch
    {
        public static bool doTeleport = false;
        public static Vector3 telePos;

        public static bool Prefix(GorillaLocomotion.GTPlayer __instance, ref Vector3 ___lastPosition, ref Vector3 ___lastHeadPosition, ref Vector3 ___lastLeftHandPosition, ref Vector3 ___lastRightHandPosition, ref Vector3[] ___velocityHistory, ref Rigidbody ___playerRigidBody)
        {
            if (doTeleport)
            {
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().transform.position = World2Player(telePos);
                ___lastPosition = telePos;

                ___lastHeadPosition = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
                ___lastLeftHandPosition = telePos;
                ___lastRightHandPosition = telePos;

                ___velocityHistory = new Vector3[GorillaLocomotion.GTPlayer.Instance.velocityHistorySize];
                ___playerRigidBody.velocity = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity;

                doTeleport = false;
                return true;
            }
            return true;
        }
    }
}
