using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crewmate : MonoBehaviour {
	[SerializeField] private GameObject reportButton;

	GameObject reportedBody;

	private void Start ()
	{
		reportButton = GameObject.Find("ReportButton");
    }

	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		if (collision2D.gameObject.tag == "Dead")
		{
			reportButton.GetComponent<Button>().interactable = true;

            reportedBody = collision2D.gameObject;
		}
	}

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Dead")
        {
            reportButton.GetComponent<Button>().interactable = false;

            reportedBody = null;
        }
    }
}
