using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.N3DS;

public class NintendoGUI : MonoBehaviour {

    [SerializeField] bool position;

    RectTransform thisButton;

    private void Start() {
        thisButton = GetComponent<RectTransform>();
    }

    void OnGUI()
    {
        GUI.color = Color.clear;

        if (GetComponent<Button>().interactable)
        {

            if (position)
            {
                if (GUI.Button(new Rect(Mathf.Abs(thisButton.transform.position.x), Mathf.Abs(thisButton.transform.position.y), thisButton.rect.width, thisButton.rect.height), ""))
                {
                    thisButton.GetComponent<Button>().onClick.Invoke();
                }
            }

            else
            {
                if (GUI.Button(new Rect(Mathf.Abs(thisButton.transform.position.x), Mathf.Abs(thisButton.anchoredPosition.y), thisButton.rect.width, thisButton.rect.height), ""))
                {
                    thisButton.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
