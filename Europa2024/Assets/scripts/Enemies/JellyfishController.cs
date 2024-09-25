using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishController : MonoBehaviour, DamageScript
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] public float speed = 5f;

    [SerializeField] public float EnemyHealthNumber = 7f;

    public float currentEnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //currentPoint = pointA.transform;

        currentEnemyHealth = EnemyHealthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //moves the enemy
        //Vector2 point = currentPoint.position - transform.position;
        //if (currentPoint == pointA.transform)
        //{
            //rb.velocity = new Vector2(speed, 0);
        //}

        //else
        //{
            //rb.velocity = new Vector2(-speed, 0);
        //}

        //makes the enemy change direction when it reaches point A of its path
        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        //{
            //currentPoint = pointB.transform;
            //speed = 2f;
        //}

        //and vice versa for point B
        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        //{
            //currentPoint = pointA.transform;
            //speed = 5f;
        //}
    }

    //makes the enemy patrol path visible
    //yes I copied this from the slug controller. sue me.
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    //this code is what damages the enemy
    public void Damage(float damage)
    {
        currentEnemyHealth -= damage;    
        
        //this code kills the enemy when its help drops below 1
        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }    

}
