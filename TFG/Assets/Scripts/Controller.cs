public class Controller
{
    private string left = "left";
    private string right = "right";
    private string jump = "space";
    private string dash = "q";
    private string settingsMenu = "m";

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

    //Setters
    public void SetLeft(string left)
    {
        this.left = left;
    }

    public void SetRight(string right)
    {
        this.right = right;
    }

    public void SetJump(string jump)
    {
        this.jump = jump;
    }
    public void SetDash(string dash)
    {
        this.dash = dash;
    }

    public void SetSettingsMenu(string settingsMenu)
    {
        this.settingsMenu = settingsMenu;
    }
}
