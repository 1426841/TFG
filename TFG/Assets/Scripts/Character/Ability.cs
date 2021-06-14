using UnityEngine;

public class Ability : MonoBehaviour
{
    private const float MaxAbilityTime = 0.35f;

    public GameObject abilityPoint1, abilityPoint2, abilityPoint3, noAbilityPoint1, noAbilityPoint2, noAbilityPoint3;
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
            if (timeAbility >= MaxAbilityTime)
            {   
                // Ability finished, substracts one ability point and starts cooldown
                usingAbility = false;
                --abilityPoints;

                if (abilityPoints == 2)
                {
                    ActivateAbilityPoints(false, true, true, true, false, false);
                } else if (abilityPoints == 1)
                {
                    ActivateAbilityPoints(false, false, true, true, true, false);
                }
                else
                {
                    ActivateAbilityPoints(false, false, false, true, true, true);
                }

                timeAbility = 0;
                coolDown = true;
            }

        }
        else if (coolDown)
        {
            timeCoolDown += Time.deltaTime;
            if (timeCoolDown >= MaxAbilityTime)
            {
                // CoolDown finished and abilities can be used again
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
        ActivateAbilityPoints(true, true, true, false, false, false);
    }

    private void ActivateAbilityPoints(bool abilityPoint1, bool abilityPoint2, bool abilityPoint3, bool noAbilityPoint1, bool noAbilityPoint2, bool noAbilityPoint3)
    {
        this.abilityPoint1.gameObject.SetActive(abilityPoint1);
        this.abilityPoint2.gameObject.SetActive(abilityPoint2);
        this.abilityPoint3.gameObject.SetActive(abilityPoint3);
        this.noAbilityPoint1.gameObject.SetActive(noAbilityPoint1);
        this.noAbilityPoint2.gameObject.SetActive(noAbilityPoint2);
        this.noAbilityPoint3.gameObject.SetActive(noAbilityPoint3);
    }
}
