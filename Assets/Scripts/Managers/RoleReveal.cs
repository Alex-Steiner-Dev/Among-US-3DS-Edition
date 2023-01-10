using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleReveal : MonoBehaviour {
    [SerializeField] private GameObject crewmatePanel;
    [SerializeField] private GameObject impostorPanel;

    Manager manager;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();

        manager.players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void RoleRevealPanel(bool impostor)
    {
        StartCoroutine(ShowRole(impostor));
    }

    IEnumerator ShowRole(bool impostor)
    {
        if (!impostor)
        {
            crewmatePanel.SetActive(true);
            crewmatePanel.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(3);

            crewmatePanel.SetActive(false);
        }
        else
        {
            impostorPanel.SetActive(true);
            impostorPanel.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(3);

            impostorPanel.SetActive(false);
        }

        manager.player.GetComponent<PlayerMovement>().enabled = true;

        foreach (GameObject player in manager.players)
        {
            if (player != manager.player)
            {
                player.GetComponent<AIMoving>().enabled = true;
            }
        }

        Destroy(this.gameObject);
    }
}
