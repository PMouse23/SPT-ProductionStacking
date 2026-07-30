#nullable enable

using BepInEx.Configuration;
using UnityEngine;

internal static class Globals
{
    public static bool Debug = false;
    public static KeyboardShortcut SpecialShortcut = new KeyboardShortcut(KeyCode.LeftControl);
}