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
        StartCoroutine(EjectionPanel());

        ejectedSound.Play();
    }

    IEnumerator EjectionPanel()
    {
        infoTxt.text = "";

        for (int i = 0; i < msg.Length; i++)
        {
            infoTxt.text += msg[i];

            yield return new WaitForSeconds(0.1f);
        }
    }
}
