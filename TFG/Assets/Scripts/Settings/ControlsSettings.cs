using UnityEngine;
using UnityEngine.UI;

public class ControlsSettings : MonoBehaviour
{
    private const string ArrowLeftKey = "left";
    private const string ArrowRightKey = "right";
    private const string ArrowUpKey = "up";
    private const string AKey = "a";
    private const string DKey = "d";
    private const string WKey = "w";

    public Dropdown movementsDropdown;
    public Text dashKey;
    public Text repeatedKey;
    private Controller controller;
    

    void Start()
    {
        controller = FindObjectOfType<Controller>();
        dashKey.text = controller.GetDash();
    }

    private void OnDisable()
    {
        repeatedKey.gameObject.SetActive(false);

        if (controller.GetRight() == ArrowRightKey)
        {
           movementsDropdown.value = 0;
        }
    }

    public void SetMovementControls(int selectedMovement)
    {
        if(selectedMovement == 0)
        {
            controller.SetRight(ArrowRightKey);
            controller.SetLeft(ArrowLeftKey);
            controller.SetJump(ArrowUpKey);
            repeatedKey.gameObject.SetActive(false);

        } else if (!controller.IsKeyRepeated(DKey) && !controller.IsKeyRepeated(AKey) && !controller.IsKeyRepeated(WKey))
        {
            controller.SetRight(DKey);
            controller.SetLeft(AKey);
            controller.SetJump(WKey);
            repeatedKey.gameObject.SetActive(false);
        } else
        {
            repeatedKey.gameObject.SetActive(true);
        }
    }
}
