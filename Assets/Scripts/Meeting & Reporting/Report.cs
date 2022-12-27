using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour {
    [SerializeField] private GameObject reportingPanel;
    [SerializeField] private GameObject votingPanel;

    public void ReportBody()
    {
        // disable all the players script except for the voting
        // set them to their spawn point
        // initialize voting

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            // disable components
            // player
            try
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerMovement>().enabled = false;
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerAnimationHandler>().enabled = false;
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Impostor>().enabled = false;
            }

            catch { }

            // ai
            try
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIController>().enabled = false;
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Impostor>().enabled = false;
            }

            catch { }

            // add voting
            if (!(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>()))
            {
                GameObject.FindGameObjectsWithTag("Player")[i].AddComponent<AIVoting>();
            }
        }

        StartCoroutine(ReportingPanel());
    }

    IEnumerator ReportingPanel()
    {
        GameObject.Find("Task List").SetActive(false);

        reportingPanel.SetActive(true);

        yield return new WaitForSeconds(3);

        reportingPanel.SetActive(false);
        votingPanel.SetActive(true);
          
        GameObject.Find("Buttons").SetActive(false);

        // ai vote
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Player")[i] != GameObject.Find("Player"))
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIVoting>().Vote();
                Destroy(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIVoting>());
            }
        }
    }
}
