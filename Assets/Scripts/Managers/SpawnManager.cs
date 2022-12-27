using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private Transform[] spawnPoints;

	public void ReturnSpawnPoint()
	{
		// array of players alive
		// set them to spawn position according to index

		for(int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
		{
			GameObject.FindGameObjectsWithTag("Player")[i].transform.position = spawnPoints[i].transform.position;
		}
	}
}
