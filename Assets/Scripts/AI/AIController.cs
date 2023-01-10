using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	public bool isImpostor;

    Manager manager;
    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    private void Update()
	{
		if(isImpostor)
		{
            DoImpostor();
        }
	} 

    public void DoImpostor()
    {
        Impostor m_impostor = GetComponent<Impostor>();

        if (manager.isPlaying) // currently playing and trying to kill others
        {
            // checking if we can kill and have a player near us
            if (m_impostor.canKill && m_impostor.killedPlayer)
            {
                m_impostor.Kill();
            }
        }

        else // doing meeting for example
        {

        }
    }

	private GameObject NearestPlayer()
	{
		// calculate the nearest player
		// in order to do this we will create an array with all the players except for us
		// then calculate the smallest vector distance an return that game object

		GameObject nearestPlayer = null;

		GameObject[] players = new GameObject[manager.players.Length - 1];

		float nearestPlayerDistance = 100;

		// add players to the array
		for(int i = 0; i < players.Length; i++)
		{
			if (players[i] != gameObject)
			{
				players[i] = manager.players[i];
			}
		}

		for(int i = 0; i < players.Length; i++)
		{
			if (Vector3.Distance(this.transform.position, players[i].transform.position) < nearestPlayerDistance){
				// nearest player found & update
				nearestPlayer = players[i];
				nearestPlayerDistance = Vector3.Distance(this.transform.position, players[i].transform.position);
			}
		}

		return nearestPlayer;
	}
}
