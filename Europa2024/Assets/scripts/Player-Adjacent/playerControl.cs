using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float miscinputx;
    private float miscinputy;
    [SerializeField] private float moveSpeed = 6f;
    public float sprintSpeed = 1.5f;
    [SerializeField]private float maxSprint = 10f;
    public float HealthNumber = 10;
    [SerializeField] private GameObject DeathScreen;

    // this code runs once, when the game starts
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // all of this code will run every frame
    void Update()
    {
        //this code moves the player on the x and y axis
        rb.velocity = new Vector2(miscinputx * moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, miscinputy * moveSpeed);

        // this code allows for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float sprint = moveSpeed + sprintSpeed;

            if (sprint >= maxSprint)
                sprint = maxSprint;
            moveSpeed = sprint;
            Debug.Log("Sprint Key Pressed: " + sprint);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
            Debug.Log("Sprint Key Released: " + moveSpeed);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        //this defines what the fields of "miscinputx" and "miscinputy" are
        miscinputx = context.ReadValue<Vector2>().x;
        miscinputy = context.ReadValue<Vector2>().y;
    }

    //this code checks for collision tags to make things happen.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this function allows for us to damage the player when they hit a harmful object
        if (collision.gameObject.CompareTag("Lethal"))
        {
            
            HealthNumber = HealthNumber - 1;
            

        }

        //this code instantly kills the player if they touch something they shouldn't, like an out-of-bounds wall
        if (collision.gameObject.CompareTag("extra lethal"))
        {
            HealthNumber = 0;
        }

        //this is the code that kills the player
        if (HealthNumber < 1)
        {
            Time.timeScale = 0f;
            DeathScreen.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        //this code checks for items and destroys them when touched
        //actual effects have yet to be implemented
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            HealthNumber = 5;
        }
    }
}
