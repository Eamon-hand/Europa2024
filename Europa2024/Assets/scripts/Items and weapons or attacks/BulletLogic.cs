using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Header("generic bullet stats")]
    [SerializeField] private float BulletTimer = 3f;
    [SerializeField] private LayerMask CheckForWalls;

    [Header("regular bullet stats")]
    [SerializeField] private float BulletSpeed = 15f;
    [SerializeField] private float BulletDamage = 1f;

    [Header("physics bullet stats")]
    [SerializeField] private float PhysBulletSpeed = 17f;
    [SerializeField] private float PhysBulletGravity = 3f;
    [SerializeField] private float PhysBulletDamage = 5f;

    [Header("super bullet stats")]
    [SerializeField] private float SuperBulletSpeed = 30f;
    [SerializeField] private float SuperBulletDamage = 3f;

    private Rigidbody2D rb;
    private float damge;

    public enum BulletType
    {
        Normal,
        Physics,
        PoweredUp
    }
    public BulletType bulletType;
    
    // basically just sets all of the important things for the bullet to know once it gets spawned into the scene
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestructionTime();

        //changes physics of bullet if bullet type is physics
        SetRBStats();

        //sets velocity based on bullet type
        InitialiseBulletType();
    }

    private void FixedUpdate()
    {
        if (bulletType == BulletType.Physics)
        {
            //this rotates the physics bullet as it falls
            transform.right = rb.velocity;
        }
    }

    private void InitialiseBulletType()
    {
        if (bulletType == BulletType.Normal)
        {
            SetVelocity();
            damge = BulletDamage;
        }

        else if (bulletType == BulletType.Physics)
        {
            SetPhysBulletVelocity();
            damge = PhysBulletDamage;
        }

        else if (bulletType == BulletType.PoweredUp)
        {
            SetSuperBulletSpeed();
            damge = SuperBulletDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((CheckForWalls.value & (1 << collision.gameObject.layer)) > 0)
        {
            //calls a function to hurt an enemy
            DamageScript damage = collision.gameObject.GetComponent<DamageScript>();
            if (damage != null)
            {
                //actually damages the enemy
                damage.Damage(damge);
            }

            //destroys the bullet when it hits a wall or enemy
            Destroy(gameObject);
        }
    }

    //sets the velocity of the bullet upon being created
    private void SetVelocity()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    private void SetPhysBulletVelocity()
    {
        rb.velocity = transform.right * PhysBulletSpeed;
    }

    private void SetSuperBulletSpeed()
    {
        rb.velocity = transform.right * SuperBulletSpeed;
    }

    //sets a destruction timer once the bullet is created in order to prevent them from clogging up the scene
    private void SetDestructionTime()
    {
        Destroy(gameObject, BulletTimer);
    }

    private void SetRBStats()
    {
        if (bulletType == BulletType.Normal || bulletType == BulletType.PoweredUp)
        {
            rb.gravityScale = 0f;
        }

        else if (bulletType == BulletType.Physics)
        {
            rb.gravityScale = PhysBulletGravity;
        }
    }
}
