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

    private void Start()
    {
        usedKeys = new Dictionary<string, string>();
        usedKeys.Add("right", GetRight());
        usedKeys.Add("left", GetLeft());
        usedKeys.Add("jump", GetJump());
        usedKeys.Add("dash", GetDash());
        usedKeys.Add("settingsMenu", GetSettingsMenu());
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
        usedKeys["left"] = left;
    }

    public void SetRight(string right)
    {
        this.right = right;
        usedKeys["right"] = right;
    }

    public void SetJump(string jump)
    {
        this.jump = jump;
        usedKeys["jump"] = jump;
    }
    public void SetDash(string dash)
    {
        this.dash = dash;
        usedKeys["dash"] = dash;
    }

    public void SetSettingsMenu(string settingsMenu)
    {
        this.settingsMenu = settingsMenu;
        usedKeys["settingsMenu"] = settingsMenu;
    }
}
