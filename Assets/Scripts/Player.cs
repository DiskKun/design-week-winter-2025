using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 direction;

    public float speed;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1792, 1344, true);
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }


        if (direction.magnitude == 0) {
            animator.SetBool("idle", true);
        }

        animator.SetFloat("xVelocity", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("yVelocity", Input.GetAxisRaw("Vertical"));
        
    }
}
