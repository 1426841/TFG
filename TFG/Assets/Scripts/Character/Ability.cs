using UnityEngine;

public class Ability : MonoBehaviour
{
    private float timeAbility;
    private bool usingAbility;
    private string ability;

    void Start()
    {
        timeAbility = 0;
        usingAbility = false;
    }

    void FixedUpdate()
    {
        if (usingAbility)
        {
            timeAbility += Time.deltaTime;
            if (timeAbility >= 0.35)
            {
                usingAbility = false;
                timeAbility = 0;
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

    public bool IsUsingAbility()
    {
        return usingAbility;
    }
}
