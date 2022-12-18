using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyMeeting : MonoBehaviour {

	[SerializeField] private GameManager gameManager;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			gameManager.EnableUseButton();
		}
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.DisableUseButton();
        }
    }
}
