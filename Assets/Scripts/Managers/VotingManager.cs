﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VotingManager : MonoBehaviour {
    [SerializeField] private GameObject buttons;
	[SerializeField] private GameObject taskList;

    [SerializeField] private GameObject ejectionPanel;

    [SerializeField] private GameObject[] playersVoteInput;

    [SerializeField] private int[] votes = new int[10];

	[SerializeField] private int voteCount;

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        int x = 0;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            int count = 0;

            for (int i = 0; i < playersVoteInput.Length; i++)
            {
                if (playersVoteInput[i].name.Contains(player.name))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                playersVoteInput[x].GetComponentInChildren<Button>().interactable = false;
                playersVoteInput[x].GetComponentInChildren<Button>().gameObject.GetComponent<Image>().color = Color.gray;
                playersVoteInput[x].GetComponentInChildren<Button>().enabled = false;
            }

            x++;
        }
    }

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
                    StartCoroutine(WinLose((players[highestValueCount].name + " was an impostor"), 3));
                }

				else
				{
					ejectionPanel.GetComponent<Ejection>().msg = players[highestValueCount].name + " wasn't an impsostor";

					Destroy(players[highestValueCount]);

                    ejectionPanel.SetActive(true);

                    ejectionPanel.GetComponent<Ejection>().StartEjection();

                    StartCoroutine(ResumeGame());
                }
			}

			else // player ejected
			{

                if (players[highestValueCount].GetComponent<AIController>().isImpostor)
                {
                    string msg = (players[highestValueCount].name + " was an impostor");
                    StartCoroutine(WinLose(msg, 4));
                }
                else 
                {
                    string msg = (players[highestValueCount].name + " wasn't an impostor");
                    StartCoroutine(WinLose(msg, 4));
                }
            }

            // - 1 player alive
            GameObject.Find("Manager").GetComponent<Manager>().playersAlive--;
        }
    }

    private IEnumerator ResumeGame()
    {
        // remove the canvas
        // set player to spawn
        // destroy all the dead bodies

        GameObject.Find("Voting Panel").SetActive(false);

        yield return new WaitForSeconds(3);

        ejectionPanel.SetActive(false);


        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Dead").Length; i++)
		{
			Destroy(GameObject.FindGameObjectsWithTag("Dead")[i]);
		}

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();

		try
		{
			buttons.SetActive(true);
			taskList.SetActive(true);	
		}
		catch { }
    }

	IEnumerator WinLose(string msg, int scene)
	{
        ejectionPanel.GetComponent<Ejection>().msg = msg;
        ejectionPanel.GetComponent<Ejection>().StartEjection();

        Destroy(GameObject.Find("Player"));

        yield return new WaitForSeconds(3);

		SceneManager.LoadScene(scene);
	}
}
