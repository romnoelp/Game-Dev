using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Vector3 movementDirection;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(xMovement, yMovement, 0).normalized;

        if (movementDirection.sqrMagnitude > 0)
        {
            if (xMovement > 0) 
            {
                transform.localScale = Vector3.one;
            }
            else if (xMovement < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            animator.SetBool("isMoving", true);
            animator.SetFloat("xMovement", xMovement);
            animator.SetFloat("yMovement", yMovement);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("xMovement", xMovement);
            animator.SetFloat("yMovement", yMovement);
        }

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}