using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speedPlayer;

    SpriteRenderer spriteRenderer;
    Animator animator;
    Rigidbody2D rigidbody2D;
    Transform playerTransform;

    private void Start()
    {
        playerTransform = transform.GetChild(0).transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    float horizontal, vertical;
    private void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            spriteRenderer.flipX = false;
            if (horizontal >= 0)
            {
                SetAnimation("MoveRight");
            }
            else
            {
                SetAnimation("MoveLeft");
            }
        }
        else
        {
            if (Functions.GetMousePosition().x - transform.position.x >= 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }        
            SetAnimation(null);
        }
    }

    private void SetAnimation(string name)
    {
        for (int i = 0; i < animator.parameterCount; i++)
        {
           animator.SetBool(animator.GetParameter(i).name, false);
        }
        if(name != null) animator.SetBool(name, true);
    }

    private void FixedUpdate()
    {
          rigidbody2D.MovePosition(transform.position + new Vector3(horizontal, vertical) * Time.deltaTime * speedPlayer);
    }

}
