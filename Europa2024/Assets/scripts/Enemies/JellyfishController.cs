using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishController : MonoBehaviour
{
    public float EnemyHealthNumber = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this code kills the enemy when its help drops below 1
        if (EnemyHealthNumber < 1)
        {
            Destroy(gameObject);
        }
    }

    //this is the code that actually allows us to damage enemies
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerAttack"))
        {
            EnemyHealthNumber = EnemyHealthNumber - 1;
        }
    }
}
