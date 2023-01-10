using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour {
    [SerializeField] private GameObject reportingPanel;
    [SerializeField] private GameObject votingPanel;

    Manager manager;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    public void ReportBody()
    {
        // disable all the players script except for the voting
        // set them to their spawn point
        // initialize voting

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();

        for (int i = 0; i < manager.players.Length; i++)
        {
            // disable components
            // player
            try
            {
                manager.players[i].GetComponent<PlayerController>().enabled = false;
                manager.players[i].GetComponent<PlayerMovement>().enabled = false;
                manager.players[i].GetComponent<PlayerAnimationHandler>().enabled = false;
                manager.players[i].GetComponent<Impostor>().enabled = false;
            }

            catch { }

            // ai
            try
            {
                manager.players[i].GetComponent<AIMoving>().enabled = false;
                manager.players[i].GetComponent<AIController>().enabled = false;
                manager.players[i].GetComponent<Impostor>().enabled = false;
            }

            catch { }

            // add voting
            if (!(manager.players[i].GetComponent<PlayerController>()))
            {
                manager.players[i].AddComponent<AIVoting>();
            }
        }

        StartCoroutine(ReportingPanel());
    }

    IEnumerator ReportingPanel()
    {
        try
        {
            GameObject.Find("Task List").SetActive(false);
        }
        catch { }

        reportingPanel.SetActive(true);

        yield return new WaitForSeconds(3);

        reportingPanel.SetActive(false);
        votingPanel.SetActive(true);
          
        GameObject.Find("Buttons").SetActive(false);

        // ai vote
        for(int i = 0; i < manager.players.Length; i++)
        {
            if (manager.players[i] != manager.player)
            {
                manager.players[i].GetComponent<AIVoting>().Vote();
                Destroy(manager.players[i].GetComponent<AIVoting>());
            }
        }
    }
}
