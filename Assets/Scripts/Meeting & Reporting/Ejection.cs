using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ejection : MonoBehaviour {
    [SerializeField] private AudioSource ejectedSound;

    [SerializeField] private Text infoTxt;
    [SerializeField] public string msg;

    Manager manager;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    public void StartEjection()
    {
        ejectedSound.Play();

        infoTxt.text = msg;

        manager.players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in manager.players)
        {
            if(player != manager.player)
            {
                player.GetComponent<AIMoving>().currentWayPoint = 0;
                player.GetComponent<AIMoving>().targetWayPoint = null;
            }
        }
    }
}
