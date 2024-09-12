using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GoombaController : MonoBehaviour,DamageScript
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    
    [SerializeField] public float EnemyHealthNumber = 5;

    public float currentEnemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;

        currentEnemyHealth = EnemyHealthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
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
