using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private UnityEngine.UI.Button m_useButton;

    public void UseButton(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void EnableUseButton()
    {
        m_useButton.interactable = true;
    }

    public void DisableUseButton()
    {
        m_useButton.interactable = false;
    }
}
