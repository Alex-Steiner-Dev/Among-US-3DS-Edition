using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private Transform[] spawnPoints;

	GameObject[] importantUI;

	private void Awake()
	{
		importantUI = GameObject.FindGameObjectsWithTag("Important UI");
    }
	public void ReturnSpawnPoint()
	{
		// array of players alive
		// set them to spawn position according to index
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
		{
			players[i].transform.position = spawnPoints[i].transform.position;
			
			for(int j = 0; j < players[i].GetComponents<MonoBehaviour>().Length; j++)
			{
				players[i].GetComponents<MonoBehaviour>()[j].enabled = true;
            }
        }

		for(int i = 0; i < importantUI.Length; i++)
		{
			importantUI[i].SetActive(false);
		}
	}
}
