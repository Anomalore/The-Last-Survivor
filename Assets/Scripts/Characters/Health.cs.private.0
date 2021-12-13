using System.Collections;
using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField]private float health;
    [SerializeField]private int maxHealth;
    [SerializeField] private HealthBar bar;

    private void Start() 
    {
        if(gameObject.tag == "Player")
        {
            bar.setMaxHealth(maxHealth);
        }
        else
        {
            bar = GetComponentInChildren<HealthBar>();
            bar.setMaxHealth(maxHealth);
        }   
    }
    public Health(int _maxHealth){
        maxHealth = _maxHealth;
        health = _maxHealth;
    }

    public float getHealth(){
        return health;
    }

    public float getHealthPerecent(){
        return health / maxHealth;
    }

    public void damage(int damamageAmount)
    {
        health -= damamageAmount;
        bar.updateHealth(health);
        if(health < 0){ health = 0;}
    }

    public void heal(int healAmount)
    {
        health += healAmount;
        if(health > maxHealth){ health = maxHealth;}
    }
}
