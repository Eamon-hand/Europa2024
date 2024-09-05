using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour,DamageScript
{
    [SerializeField] public float EnemyHealthNumber = 5;

    public float currentEnemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = EnemyHealthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //damages the enemy
    public void Damage(float damage)
    {
        currentEnemyHealth -= damage;
        
        //kills the enemy at 0 health
        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
