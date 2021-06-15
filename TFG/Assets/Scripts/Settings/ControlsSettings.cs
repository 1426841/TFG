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
    public Text healKey;
    public Text repeatedKey;
    public Controller controller;
    

    void Start()
    {
        dashKey.text = controller.GetDash();
        healKey.text = controller.GetHeal();
    }

    private void OnDisable()
    {
        repeatedKey.gameObject.SetActive(false);

        // When WASD movement is selected but can't be used because at least one key is repeated, 
        // it selects the arrow keys movement from the dropdown
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
