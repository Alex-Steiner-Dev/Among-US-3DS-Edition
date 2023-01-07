using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ejection : MonoBehaviour {
    [SerializeField] private AudioSource ejectedSound;

    [SerializeField] private Text infoTxt;
    [SerializeField] public string msg;

    public void StartEjection()
    {
        ejectedSound.Play();

        infoTxt.text = msg;

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(player != GameObject.Find("Player"))
            {
                player.GetComponent<AIMoving>().currentWayPoint = 0;
                player.GetComponent<AIMoving>().targetWayPoint = null;
            }
        }
    }
}
