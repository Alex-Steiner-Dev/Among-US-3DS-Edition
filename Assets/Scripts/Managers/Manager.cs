using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    private GameObject player;
    private GameObject bots;

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

    private IEnumerator ChooseRole()
    {
        yield return new WaitForSeconds(1);

        int playerIndex = Random.Range(0, 9);

        if(playerIndex == 0)
        {
            Debug.Log("You are the impostor!");
        }

        else if(playerIndex != 0)
        {
            Debug.Log("You are a crewmate!");

            player.GetComponent<PlayerController>().LoadCrewmate();
        }
    }
}
