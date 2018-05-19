using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public int health;
    private int armour;
    private bool immune;
    public bool alive;
    public int team;

    // Use this for initialization
    void Start()
    {
        health = 100;
        alive = true;
    }

    public void takeDamage(int damage)
    {
        if (health > 0 && !immune)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            alive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
