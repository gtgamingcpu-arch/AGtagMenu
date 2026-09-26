using HarmonyLib;
using VapeMenu.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static VapeMenu.Menu.Main;

namespace VapeMenu.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    public class JoinPatch
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=purple>JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                if (customSoundOnJoin)
                {
                    if (!Directory.Exists("VapezyyMenu"))
                    {
                        Directory.CreateDirectory("VapezyyMenu");
                    }
                    File.WriteAllText("VapezyyMenu/VapeMenu_CustomSoundOnJoin.txt", "PlayerJoin");
                }
                oldnewplayer = newPlayer;
            }
        }

        private static Player oldnewplayer;
    }
}