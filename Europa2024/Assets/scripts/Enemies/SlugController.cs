using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float EnemyHealthNumber = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
