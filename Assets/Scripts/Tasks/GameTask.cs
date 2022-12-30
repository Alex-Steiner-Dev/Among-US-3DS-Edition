using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask : MonoBehaviour {
    public string taskName;

    [SerializeField] private GameManager gameManager;
    [SerializeField] public GameObject panel;

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
}
