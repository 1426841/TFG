using UnityEngine;
using UnityEngine.UI;

public class ControlsSettings : MonoBehaviour
{
    private const int ArrowDropdown = 0;
    private const int WASDDropdown = 1;

    public Dropdown movementsDropdown;
    public Text dashKey;
    public Text healKey;
    public Text repeatedKey;
    public Controller controller;
    

    void Start()
    {
        dashKey.text = controller.GetDash();
        healKey.text = controller.GetHeal();

        if (controller.GetRight() == Controller.D)
        {
            movementsDropdown.value = WASDDropdown;
        } else
        {
            movementsDropdown.value = ArrowDropdown;
        }

        repeatedKey.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        repeatedKey.gameObject.SetActive(false);

        // When WASD movement is selected but can't be used because at least one key is repeated, 
        // it selects the arrow keys movement from the dropdown
        if (controller.GetRight() == Controller.Right)
        {
           movementsDropdown.value = ArrowDropdown;
        }
    }

    public void SetMovementControls(int selectedMovement)
    {
        if(selectedMovement == 0)
        {
            controller.SetRight(Controller.Right);
            controller.SetLeft(Controller.Left);
            controller.SetJump(Controller.Jump);
            repeatedKey.gameObject.SetActive(false);

        } else if (!controller.IsKeyRepeated(Controller.D) && !controller.IsKeyRepeated(Controller.A) && !controller.IsKeyRepeated(Controller.W))
        {
            controller.SetRight(Controller.D);
            controller.SetLeft(Controller.A);
            controller.SetJump(Controller.W);
            repeatedKey.gameObject.SetActive(false);
        } else
        {
            repeatedKey.gameObject.SetActive(true);
        }
    }

    public void SetDashControl(string key)
    {
        // Converts the key to lowercase and checks that it's not empty or repeated
        key = key.ToLower();
        if (key != "" && !controller.IsKeyRepeated(key))
        {
            controller.SetDash(key);
            dashKey.text = controller.GetDash();
        }
    }

    public void SetHealControl(string key)
    {
        // Converts the key to lowercase and checks that it's not empty or repeated
        key = key.ToLower();
        if (key != "" && !controller.IsKeyRepeated(key))
        {
            controller.SetHeal(key);
            healKey.text = controller.GetHeal();
        }
    }
}
