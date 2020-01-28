using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI uiPoints;
	public Animator	canvas;

	private bool gameOver;
	private float points = 0;

    void Update()
    {
		if(!gameOver)
		{
			points += Time.deltaTime;
        	uiPoints.text = ((int)points).ToString();
		}
    }

	public void GameOver()
	{
		gameOver = true;
		canvas.SetBool("toggle_gameover", true);
	}
}
