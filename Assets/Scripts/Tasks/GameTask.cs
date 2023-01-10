using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask : MonoBehaviour {
    public string taskName;

    [SerializeField] private GameManager gameManager;
    [SerializeField] public GameObject panel;

    Manager manager;
    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && manager.player)
        {
            gameManager.EnableUseButton();
            gameManager.SetPanel(panel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && manager.player)
        {
            gameManager.DisableUseButton();
        }
    }

    public void EnableMovement()
    {

        manager.player.GetComponent<PlayerMovement>().enabled = true;
    }
}
