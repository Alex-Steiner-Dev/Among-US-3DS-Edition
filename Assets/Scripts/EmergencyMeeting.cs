using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyMeeting : MonoBehaviour {

	[SerializeField] private GameManager gameManager;
	[SerializeField] private GameObject panel;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			gameManager.EnableUseButton();
			gameManager.SetPanel(panel);
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.DisableUseButton();
        }
    }

	public void CallMeeting()
	{

	}
}
