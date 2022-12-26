using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour {

    public void ReportBody()
    {
        // disable all the players script except for the voting
        // set them to their spawn point
        // initialize voting

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
            if (GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>())
            {
                GameObject.FindGameObjectsWithTag("Player")[i].AddComponent<Voting>();
            }
            else
            {
                GameObject.FindGameObjectsWithTag("Player")[i].AddComponent<AIVoting>();
            }
        }
    }
}
