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
                usingAbility = false;
                --abilityPoints;

                if(abilityPoints == 2)
                {
                    this.abilityPoint1.gameObject.SetActive(false);
                    this.abilityPoint2.gameObject.SetActive(true);
                    this.abilityPoint3.gameObject.SetActive(true);
                    this.noAbilityPoint1.gameObject.SetActive(true);
                    this.noAbilityPoint2.gameObject.SetActive(false);
                    this.noAbilityPoint3.gameObject.SetActive(false);
                } else if(abilityPoints == 1)
                {
                    this.abilityPoint1.gameObject.SetActive(false);
                    this.abilityPoint2.gameObject.SetActive(false);
                    this.abilityPoint3.gameObject.SetActive(true);
                    this.noAbilityPoint1.gameObject.SetActive(true);
                    this.noAbilityPoint2.gameObject.SetActive(true);
                    this.noAbilityPoint3.gameObject.SetActive(false);
                }
                else
                {
                    this.abilityPoint1.gameObject.SetActive(false);
                    this.abilityPoint2.gameObject.SetActive(false);
                    this.abilityPoint3.gameObject.SetActive(false);
                    this.noAbilityPoint1.gameObject.SetActive(true);
                    this.noAbilityPoint2.gameObject.SetActive(true);
                    this.noAbilityPoint3.gameObject.SetActive(true);
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
        this.abilityPoint1.gameObject.SetActive(true);
        this.abilityPoint2.gameObject.SetActive(true);
        this.abilityPoint3.gameObject.SetActive(true);
        this.noAbilityPoint1.gameObject.SetActive(false);
        this.noAbilityPoint2.gameObject.SetActive(false);
        this.noAbilityPoint3.gameObject.SetActive(false);
    }
}
