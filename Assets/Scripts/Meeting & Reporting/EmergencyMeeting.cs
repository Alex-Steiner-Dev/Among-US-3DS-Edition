using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyMeeting : MonoBehaviour {
	[SerializeField] private AudioSource alarm;


    [SerializeField] private GameManager gameManager;
    [SerializeField] public GameObject panel;

    [SerializeField] private GameObject votingPanel;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.Find("Player"))
        {
            gameManager.EnableUseButton();
            gameManager.SetPanel(panel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.Find("Player"))
        {
            gameManager.DisableUseButton();
        }
    }

    public void CallMeeting()
	{
        alarm.Play();

        panel.SetActive(false);



        StartCoroutine(EmergencyMeetingPanel());

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
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIMoving>().enabled = false;
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Impostor>().enabled = false;
            }

            catch { }

            // add voting
            if (!(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>()))
            {
                GameObject.FindGameObjectsWithTag("Player")[i].AddComponent<AIVoting>();
            }
        }
    }

    IEnumerator EmergencyMeetingPanel()
    {
        yield return new WaitForSeconds(3);

        votingPanel.SetActive(true);

        // ai vote
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Player")[i] != GameObject.Find("Player"))
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIVoting>().Vote();
                Destroy(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<AIVoting>());
            }
        }
    }
}
