using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] players;

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

        foreach (GameObject x in players)
        {
            if (x == GameObject.Find("Player"))
            {
                x.GetComponent<PlayerMovement>().enabled = false;
            }

            else
            {
                x.GetComponent<AIMoving>().enabled = false;
            }
        }

        if (playerIndex == 0)
        {
            // load your self as an impostor
            GameObject.Find("Role Reveal").GetComponent<RoleReveal>().RoleRevealPanel(true);

            player.GetComponent<PlayerController>().isImpostor = true;
            player.AddComponent<Impostor>();
            player.AddComponent<AudioSource>();

            impostor = player;

            Destroy(GameObject.Find("TaskManager"));
        }

        else if (playerIndex != 0)
        {
            // assign the impostor components to the ai & load you as a crewmate
            GameObject.Find("Role Reveal").GetComponent<RoleReveal>().RoleRevealPanel(false);

            player.GetComponent<PlayerController>().LoadCrewmate();
            player.AddComponent<Crewmate>();

            GameObject tempImpostor = GameObject.Find("AI Player (" + (playerIndex - 1) + ")");

            tempImpostor.GetComponent<AIController>().isImpostor = true;
            tempImpostor.AddComponent<Impostor>();
            tempImpostor.AddComponent<AudioSource>();

            impostor = tempImpostor;

            Destroy(GameObject.Find("KillButton"));
        }

        GameObject.Find("Spawn Points").GetComponent<SpawnManager>().ReturnSpawnPoint();

        isPlaying = true;
    }
}
