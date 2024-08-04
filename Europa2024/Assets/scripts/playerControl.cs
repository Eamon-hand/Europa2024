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
        // it isn't a very good sprint but its the thought that counts
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float sprint = moveSpeed +sprintSpeed;
            moveSpeed = sprint;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
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
        //this code "kills" the player and resets the scene
        if (collision.gameObject.CompareTag("Lethal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //this code checks for items and destroys them when touched
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            //moveSpeed = 7f;
        }
    }
}
