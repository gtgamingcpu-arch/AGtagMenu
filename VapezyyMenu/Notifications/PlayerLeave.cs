using HarmonyLib;
using VapeMenu.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static VapeMenu.Menu.Main;

namespace VapeMenu.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    public class LeavePatch
    {
        private static void Prefix(Player otherPlayer)
        {
            if (otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != a)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>LEAVE</color><color=grey>]</color> <color=white>Name: " + otherPlayer.NickName + "</color>");
                if (customSoundOnJoin)
                {
                    if (!Directory.Exists("VapezyyMenu"))
                    {
                        Directory.CreateDirectory("VapezyyMenu");
                    }
                    File.WriteAllText("VapezyyMenu/VapeMenu_CustomSoundOnJoin.txt", "PlayerLeave");
                }
                a = otherPlayer;
            }
        }

        private static Player a;
    }
}