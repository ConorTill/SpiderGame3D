using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour {

    // Use this for initialization

    private int damage;
    public float range;
    private int cooldown;
    private int maxCooldown;
    public GameObject target;
    private NavigationComponent navigationComponent;

	void Start () {
        damage = 4;
        range = 1.5f;
        maxCooldown = 30;
        resetCooldown();
        navigationComponent = gameObject.GetComponent<NavigationComponent>();
	}

    public void acquireTarget(GameObject targetUnit)
    {
        target = targetUnit;
        navigationComponent.setDestination(targetUnit.transform.position);
    }

    public void attack()
    {
        if (cooldown <= 0 && target != null)
        {
            target.GetComponent<HealthComponent>().takeDamage(damage);
            resetCooldown();
        } else
        {
            cooldown--;
        }
        if(target.GetComponent<HealthComponent>().alive == false)
        {
            target = null;
        }
    }

    private void resetCooldown()
    {
        cooldown = maxCooldown;
    }

    private bool inRange()
    {
        if(target != null)
            return Vector3.Distance(gameObject.transform.position, target.transform.position) <= range;
        return false;
    }

    private void FixedUpdate()
    {
        if(inRange())
        {
            gameObject.GetComponent<NavigationComponent>().stopNavigating();
            attack();
        } else
        {
            gameObject.GetComponent<NavigationComponent>().continueNavigating();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
