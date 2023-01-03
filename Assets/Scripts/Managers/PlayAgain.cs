using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

	public void PlayAgainButtonPressed()
	{
		Destroy(GameObject.Find("Manager"));
		SceneManager.LoadScene(1); // 1 = lobby index;
	}
}
