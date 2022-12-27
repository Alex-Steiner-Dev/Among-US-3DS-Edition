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

		if(firstHighestValue == secondHighestValue) // no one ejected same votes
		{
			ejectionPanel.SetActive(true);
		}

		else
		{
			if (players[highestValueCount] != GameObject.Find("Player")) // ai ejected
			{
				ejectionPanel.SetActive(true);

				if (players[highestValueCount].GetComponent<AIController>().isImpostor)
				{
					ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " was an impostor";

					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // won
				}

				else
				{
					ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " wasn't an impsostor";

					ejectionPanel.GetComponent<Ejection>().StartEjection();

					ejectionPanel.SetActive(true);
				}
			}

			else // player ejected
			{
                ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " was an impostor";

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // lost
            }
		}
	}
}
