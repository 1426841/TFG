using System.Collections.Generic;
using UnityEngine;
public class Controller : MonoBehaviour
{
    private string left = "left";
    private string right = "right";
    private string jump = "up";
    private string dash = "q";
    private string settingsMenu = "m";
    private Dictionary<string, string> usedKeys;
    private const string LeftKey = "right";
    private const string RightKey = "left";
    private const string JumpKey = "jump";
    private const string DashKey = "dash";
    private const string SettingsMenuKey = "settingsMenu";

    private void Start()
    {
        usedKeys = new Dictionary<string, string>();
        usedKeys.Add(LeftKey, GetLeft());
        usedKeys.Add(RightKey, GetRight());
        usedKeys.Add(JumpKey, GetJump());
        usedKeys.Add(DashKey, GetDash());
        usedKeys.Add(SettingsMenuKey, GetSettingsMenu());
    }

    //Getters
    public string GetLeft()
    {
        return left;
    }

    public string GetRight()
    {
        return right;
    }

    public string GetJump()
    {
        return jump;
    }
    public string GetDash()
    {
        return dash;
    }

    public string GetSettingsMenu()
    {
        return settingsMenu;
    }

    public bool IsKeyRepeated(string key)
    {
        return usedKeys.ContainsValue(key);
    }

    //Setters
    public void SetLeft(string left)
    {
        this.left = left;
        usedKeys[LeftKey] = left;
    }

    public void SetRight(string right)
    {
        this.right = right;
        usedKeys[RightKey] = right;
    }

    public void SetJump(string jump)
    {
        this.jump = jump;
        usedKeys[JumpKey] = jump;
    }
    public void SetDash(string dash)
    {
        this.dash = dash;
        usedKeys[DashKey] = dash;
    }

    public void SetSettingsMenu(string settingsMenu)
    {
        this.settingsMenu = settingsMenu;
        usedKeys[SettingsMenuKey] = settingsMenu;
    }
}
