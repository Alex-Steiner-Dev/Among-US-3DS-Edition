using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    private GameObject player;
    private GameObject bots;

    public bool isPlaying;

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
        yield return new WaitForSeconds(1);

        int playerIndex = Random.Range(0, 9);

        if(playerIndex == 0)
        {
            // load your self as an impostor
            Debug.Log("You are the impostor!");

            GameObject.Find("Player").GetComponent<PlayerController>().isImpostor = true;
            GameObject.Find("Player").AddComponent<Imposter>();
            GameObject.Find("Player").AddComponent<CircleCollider2D>().isTrigger = true;
        }

        else if(playerIndex != 0)
        {
            // assign the impostor components to the ai & load you as a crewmate

            Debug.Log("You are a crewmate!");

            player.GetComponent<PlayerController>().LoadCrewmate();

            Debug.Log("AI Player (" + (playerIndex - 1) + ") is the imposotr!");

            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").GetComponent<AIController>().isImpostor = true;
            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").AddComponent<Imposter>();
            GameObject.Find("AI Player (" + (playerIndex - 1) + ")").AddComponent<CircleCollider2D>().isTrigger = true;
        }

        isPlaying = true;
    }
}
