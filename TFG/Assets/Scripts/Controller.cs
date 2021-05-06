public class Controller
{
    private string left = "left";
    private string right = "right";
    private string jump = "space";
    private string dash = "q";

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
}
