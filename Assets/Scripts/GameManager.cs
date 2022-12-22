using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [SerializeField] private UnityEngine.UI.Button m_useButton;
    [SerializeField] private GameObject panel;

    public UnityEvent onUseButton = new UnityEvent();

    public void UseButton()
    {
        panel.SetActive(true);
        onUseButton.Invoke();
    }

    public void EnableUseButton()
    {
        m_useButton.interactable = true;
    }

    public void DisableUseButton()
    {
        m_useButton.interactable = false;
    }

    public void SetPanel(GameObject newPanel)
    {
        panel = newPanel;
    }
}
