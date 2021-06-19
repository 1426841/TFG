using System.Collections.Generic;
using UnityEngine;
public class Controller : MonoBehaviour
{
    public const string Left = "left";
    public const string Right = "right";
    public const string Jump = "up";
    public const string A = "a";
    public const string W = "w";
    public const string D = "d";
    private const string Dash = "q";
    private const string Heal = "e";
    private const string SettingsMenu = "m";
    private Dictionary<string, string> usedKeys;
    private const string LeftKey = "right";
    private const string RightKey = "left";
    private const string JumpKey = "jump";
    private const string DashKey = "dash";
    private const string HealKey = "heal";
    private const string SettingsMenuKey = "settingsMenu";

    private void Start()
    {
        usedKeys = new Dictionary<string, string>();
        usedKeys.Add(LeftKey, GetLeft());
        usedKeys.Add(RightKey, GetRight());
        usedKeys.Add(JumpKey, GetJump());
        usedKeys.Add(DashKey, GetDash());
        usedKeys.Add(HealKey, GetHeal());
        usedKeys.Add(SettingsMenuKey, GetSettingsMenu());
    }

    //Getters
    public string GetLeft()
    {
        return PlayerPrefs.GetString(LeftKey, defaultValue: Left);
    }

    public string GetRight()
    {
        return PlayerPrefs.GetString(RightKey, defaultValue: Right);
    }

    public string GetJump()
    {
        return PlayerPrefs.GetString(JumpKey, defaultValue: Jump);
    }
    public string GetDash()
    {
        return PlayerPrefs.GetString(DashKey, defaultValue: Dash);
    }

    public string GetHeal()
    {
        return PlayerPrefs.GetString(HealKey, defaultValue: Heal);
    }

    public string GetSettingsMenu()
    {
        return PlayerPrefs.GetString(SettingsMenuKey, defaultValue: SettingsMenu);
    }

    public bool IsKeyRepeated(string key)
    {
        return usedKeys.ContainsValue(key);
    }

    //Setters
    public void SetLeft(string left)
    {
        PlayerPrefs.SetString(LeftKey, left);
        usedKeys[LeftKey] = left;
    }

    public void SetRight(string right)
    {
        PlayerPrefs.SetString(RightKey, right);
        usedKeys[RightKey] = right;
    }

    public void SetJump(string jump)
    {
        PlayerPrefs.SetString(JumpKey, jump);
        usedKeys[JumpKey] = jump;
    }
    public void SetDash(string dash)
    {
        PlayerPrefs.SetString(DashKey, dash);
        usedKeys[DashKey] = dash;
    }

    public void SetHeal(string heal)
    {
        PlayerPrefs.SetString(HealKey, heal);
        usedKeys[HealKey] = heal;
    }

    public void SetSettingsMenu(string settingsMenu)
    {
        PlayerPrefs.SetString(SettingsMenuKey, settingsMenu);
        usedKeys[SettingsMenuKey] = settingsMenu;
    }
}
