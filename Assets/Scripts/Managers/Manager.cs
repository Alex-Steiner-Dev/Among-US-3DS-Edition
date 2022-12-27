using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    private GameObject player;
    private GameObject bots;

    public bool isPlaying;

    public int playersAlive = 10;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        player = GameObject.Find("Player");

        DontDestroyOnLoad(player);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        StartCoroutine(ChooseRole());
    }

    IEnumerator ChooseRole()
    {
        yield return new WaitForSeconds(.1f);

        GameObject impostor = null;

        int playerIndex = Random.Range(0, 9);

        if (playerIndex == 0)
        {
            // load your self as an impostor
            GameObject.Find("Role Reveal").GetComponent<RoleReveal>().RoleRevealPanel(true);

            Debug.Log("You are the impostor!");

            GameObject.Find("Player").GetComponent<PlayerController>().isImpostor = true;
            GameObject.Find("Player").AddComponent<Impostor>();
            GameObject.Find("Player").AddComponent<AudioSource>();

            impostor = GameObject.Find("Player");
        }

        else if(playerIndex != 0)
        {
            // assign the impostor components to the ai & load you as a crewmate
            GameObject.Find("Role Reveal").GetComponent<RoleReveal>().RoleRevealPanel(false);

            Debug.Log("You are a crewmate!");

            player.GetComponent<PlayerController>().LoadCrewmate();
            player.AddComponent<Crewmate>();

            Debug.Log("AI Player (" + (playerIndex - 1) + ") is the imposotr!");

            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").GetComponent<AIController>().isImpostor = true;
            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").AddComponent<Impostor>();
            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").AddComponent<AudioSource>();

            impostor = GameObject.Find("AI Player (" + (playerIndex - 1) + ")");

            Destroy(GameObject.Find("KillButton"));
        }

        isPlaying = true;

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();
    }
}
