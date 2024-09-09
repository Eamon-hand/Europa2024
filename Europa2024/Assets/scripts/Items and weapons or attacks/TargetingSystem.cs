using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetingSystem : MonoBehaviour
{
    [SerializeField] private GameObject attackSystem;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletLaunch;

    private GameObject BulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        BulletRotation();
        BulletShooting();
    }

    //this code handles the aiming system rotating towards the cursor
    private void BulletRotation()
    {
        //this rotates the targeting system asset
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)attackSystem.transform.position).normalized;
        attackSystem.transform.right = direction;

        //this vertically flips the targeting system asset when it reaches 90 or -90 degrees
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        attackSystem.transform.localScale = localScale;
    }

    //this code allows us to actually "fire" bullets (create a bullet object)
    private void BulletShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame&&attackSystem.gameObject.activeInHierarchy)
        {
            BulletInst = Instantiate(bullet, bulletLaunch.position, attackSystem.transform.rotation);
        }
    }
}
