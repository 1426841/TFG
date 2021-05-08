using UnityEngine;

public class Ability : MonoBehaviour
{
    private int abilityPoints;
    private float timeAbility;
    private float timeCoolDown;
    private bool usingAbility;
    private bool coolDown;
    private string ability;

    void Start()
    {
        ResetAbility();
    }

    void FixedUpdate()
    {
        if (usingAbility)
        {
            timeAbility += Time.deltaTime;
            if (timeAbility >= 0.35)
            {
                usingAbility = false;
                --abilityPoints;
                timeAbility = 0;
                coolDown = true;
            }

        }
        else if (coolDown)
        {
            timeCoolDown += Time.deltaTime;
            if (timeCoolDown >= 0.35)
            {
                coolDown = false;
                timeCoolDown = 0;
            }
        }
    }

    public void UseAbility(string ability)
    {
        this.ability = ability;
        usingAbility = true;
    }

    public string GetAbility()
    {
        return ability;
    }

    public bool CanUseAbility()
    {
        if (abilityPoints > 0 && !coolDown && !usingAbility)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsUsingAbility()
    {
        return usingAbility;
    }

    public void ResetAbility()
    {
        abilityPoints = 3;
        timeAbility = 0;
        timeCoolDown = 0;
        usingAbility = false;
        coolDown = false;
    }
}
