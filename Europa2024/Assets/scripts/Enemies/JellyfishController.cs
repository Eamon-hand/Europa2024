using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishController : MonoBehaviour, DamageScript
{  
    [SerializeField] private float EnemyHealthNumber = 5f;

    private float currentEnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = EnemyHealthNumber;
    }

    // Update is called once per frame
    void Update()
    {

    }    
    
    //this code is what damages the enemy
    public void Damage(float damage)
    {
        currentEnemyHealth -= damage;    
        
        //this code kills the enemy when its help drops below 1
        if (EnemyHealthNumber <= 0)
        {
            Destroy(gameObject);
        }
    }    

}
