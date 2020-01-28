using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public float maxAnimatorSpeed = 2f;

	private float curAnimatorSpeed;

	void Start()
	{
		curAnimatorSpeed = anim.GetFloat("run_multiplier");
	}

    //  Un nuevo metodo público para alterar
    public void IncreaseAnimatorSpeed(float speedIncrease)
    {
        if(curAnimatorSpeed < maxAnimatorSpeed)
		{
			curAnimatorSpeed += speedIncrease;
			anim.SetFloat("run_multiplier", curAnimatorSpeed);
		}
    }

    public void Grounded()
    {
        anim.SetBool("grounded", true);
    }
    
    public void Jumping()
    {
        anim.SetBool("grounded", false);
    }
}
