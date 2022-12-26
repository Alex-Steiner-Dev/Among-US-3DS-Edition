using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillButtonHandler : MonoBehaviour {

	public void KillButton()
	{
		GameObject.Find("Player").GetComponent<Impostor>().Kill();
		this.GetComponent<Button>().interactable = false;
	}
}
