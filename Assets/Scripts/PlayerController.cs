using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public int moveSpeed;

    private Vector2 input;
    // Update is called once per frame
    private void Update()
    {

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("Speed", input.sqrMagnitude);

        if(input.magnitude > 1.0f)
        {
            input.Normalize();
        }

        if (input.x != 0) input.y = 0;

        if (input != Vector2.zero)
        {

            animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);

            Move(input);

        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

    }

    void Move(Vector2 input)
    {

        rb.velocity = new Vector2(moveSpeed*input.x,moveSpeed*input.y);
        
        //isMoving = true;

        /*        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                    yield return null; 

                }

                transform.position = targetPos;*/

        //isMoving = false;
    
    }


}
