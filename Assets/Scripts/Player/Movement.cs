using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 12;		//	Current movement speed
    public float maxMovementSpeed = 25;		//	Max velocity a player can reach
    private float previousSpeed;            //  Storage for speed changes

    public float jumpForce = 10;			//	Jump force (using Physics)

	public ParticleSystem ps;

    private bool isGrounded;				//	Ground collision check

    private Rigidbody rb;					//	Access to Rigidbody component
    private AnimationController anim;		//	Access to AnimationController class
    private GameManager gameManager;		//	Access to AnimationController class

    void Start()
    {
        rb = GetComponent<Rigidbody>();					//	Assign component Rigidbody of object Player
        anim = GetComponent<AnimationController>();		//	Assign component AnimationController of object Player
		gameManager = FindObjectOfType<GameManager>();
		previousSpeed = movementSpeed;
    }

    void Update()							//	This will be called every frame
    {
        Move();
        if (movementSpeed < maxMovementSpeed)
            movementSpeed += Time.deltaTime / 5;
        if(previousSpeed < (int)movementSpeed)
		{
			previousSpeed = (int)movementSpeed;
			if(anim)
				anim.IncreaseAnimatorSpeed(0.1f);
		}
    }

    void Move()								//	Actions for our player's movement
    {
        transform.position += transform.right * movementSpeed * Time.deltaTime;
    }

    public void Jump()						//	Actions for our player's jump
    {
        if(isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }
    }

	private void Die()						//	Actions for our player's death
	{
		maxMovementSpeed = 0;
		movementSpeed = 0;
		gameManager.GameOver();
	}

	//	Check collisions and triggers

	private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground") && ps)
        {
			ps.transform.position = transform.position;
			ps.Play();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
            if (anim)
                anim.Grounded();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
            if (anim)
                anim.Jumping();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Die();
		}
	}

}
