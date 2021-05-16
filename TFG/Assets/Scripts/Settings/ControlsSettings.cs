using UnityEngine;
using UnityEngine.UI;

public class ControlsSettings : MonoBehaviour
{
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

        if (controller.GetRight() == "right")
        {
           movementsDropdown.value = 0;
        }
    }

    public void SetMovementControls(int selectedMovement)
    {
        if(selectedMovement == 0)
        {
            controller.SetRight("right");
            controller.SetLeft("left");
            controller.SetJump("up");
            repeatedKey.gameObject.SetActive(false);

        } else if (!controller.IsKeyRepeated("d") && !controller.IsKeyRepeated("a") && !controller.IsKeyRepeated("w"))
        {
            controller.SetRight("d");
            controller.SetLeft("a");
            controller.SetJump("w");
            repeatedKey.gameObject.SetActive(false);
        } else
        {
            repeatedKey.gameObject.SetActive(true);
        }
    }
}
