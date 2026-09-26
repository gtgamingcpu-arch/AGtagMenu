using BepInEx;
using System;
using UnityEngine;

namespace VapeMenu
{
    [System.ComponentModel.Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Start() // To that one dude that uses SMI to inject my menu, it's this method
        {
            Console.Title = "ii's Stupid Menu // Build " + PluginInfo.Version;

            VapeMenu.Patches.Menu.ApplyHarmonyPatches();
            GameObject Loading = new GameObject();
            Loading.AddComponent<VapeMenu.UI.Main>();
            Loading.AddComponent<VapeMenu.Notifications.NotifiLib>();
            Loading.AddComponent<VapeMenu.Classes.CoroutineManager>();
            UnityEngine.Object.DontDestroyOnLoad(Loading);
        }
    }
}
