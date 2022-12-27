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
    }
}
