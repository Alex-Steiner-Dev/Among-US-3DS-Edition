using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	[SerializeField] private RectTransform playButton;

    private void OnGUI()
    {
		GUI.color = Color.clear;

        if (GUI.Button(new Rect(Mathf.Abs(playButton.anchoredPosition.x - ((320 - playButton.rect.width) / 2)),Mathf.Abs(playButton.anchoredPosition.y), playButton.rect.width, playButton.rect.height), ""))
		{
			Play();
		}

    }
    public void Play()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
