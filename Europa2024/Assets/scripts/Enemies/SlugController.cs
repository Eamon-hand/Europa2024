using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GoombaController : MonoBehaviour,DamageScript
{
    public GameObject pointA;
    public GameObject pointB;
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
        //moves the enemy
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        //makes the enemy change direction when it reaches point B of its path
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flipSprite();
            currentPoint = pointA.transform;
        }

        //and vice versa for point A
        if(Vector2.Distance(transform.position, currentPoint.position) <0.5f && currentPoint == pointA.transform)
        {
            flipSprite();
            currentPoint = pointB.transform;
        }

    }

    private void flipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    //makes the enemy patrol path visible so we can see it and have it look nice
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawLine(pointB.transform.position, pointA.transform.position);
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
