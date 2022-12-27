using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VotingManager : MonoBehaviour {
	[SerializeField] private GameObject ejectionPanel;

	[SerializeField] private int[] votes = new int[10];

	[SerializeField] private int voteCount;

	public void AddVoteTo(int playerIndex)
	{
		// add a vote to the indexed player
		// after this if the vote count is 10 which means that all players voted
		// it gives the result back

		votes[playerIndex]++;

		voteCount++;

		if (voteCount == GameObject.Find("Manager").GetComponent<Manager>().playersAlive)
		{
			voteCount = 0;
			VoteEvaluation();
		}
	}

	public void VoteEvaluation()
	{
        // iterate trough the array & self in a temp variable the two highest index
        // continue with nothing if votes are the same
        // eject ai if gets many votes
        // if player gets vote end game
        // check if the ai was the impostor

        ejectionPanel.SetActive(true);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		int firstHighestValue = 0;
		int secondHighestValue = 0;

		int highestValueCount = 0;
		int secondtHighestValueCount = 0;

		for(int i = 0; i < votes.Length; i++)
		{
			if (votes[i] > firstHighestValue)
			{
				secondHighestValue = firstHighestValue;
				firstHighestValue = votes[i];

				highestValueCount = i;
			}
		}

        if (firstHighestValue == secondHighestValue) // no one ejected same votes
		{
            ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + "( Tied ) no one was ejected";
        }

		else
		{
			if (players[highestValueCount] != GameObject.Find("Player")) // ai ejected
			{
				if (players[highestValueCount].GetComponent<AIController>().isImpostor)
				{
					ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " was an impostor";

					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // won
				}

				else
				{
					ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " wasn't an impsostor";

					Destroy(players[highestValueCount]);

					ejectionPanel.GetComponent<Ejection>().StartEjection();

					ejectionPanel.SetActive(true);

                    ResumeGame();
                }
			}

			else // player ejected
			{
                ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " was an impostor";

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // lost
            }
		}
    }

    private void ResumeGame()
    {
		// remove the canvas
		// set player to spawn
		// destroy all the dead bodies

		GameObject.Find("Voting Panel").SetActive(false);


        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Dead").Length; i++)
		{
			Destroy(GameObject.FindGameObjectsWithTag("Dead")[i]);
		}

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();

        for (int i = 0; i < 15; i++)
        {
            for (float j = 1.5f; j > 0; j -= Time.deltaTime)
            {
                // wait
            }
        }

		ejectionPanel.SetActive(false);
    }
}
