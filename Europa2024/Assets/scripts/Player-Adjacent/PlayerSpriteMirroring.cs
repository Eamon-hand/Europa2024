using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteMirroring : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private float HoriztalInput;
    private bool IsFacingRight = true; 

    // Update is called once per frame
    void Update()
    {
        HoriztalInput = Input.GetAxis("Horizontal");

        SetDirectionbyComponent();
    }

    private void SetDirectionbyScale()
    {
        if(HoriztalInput <0 && IsFacingRight || HoriztalInput > 0 && !IsFacingRight)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1f;
            transform.localScale = playerScale;
        }
    }

    private void SetDirectionbyComponent()
    {
        if (HoriztalInput < 0)
            spriteRenderer.flipX = false;
        else if (HoriztalInput > 0)
            spriteRenderer.flipX = true;
    }
}
