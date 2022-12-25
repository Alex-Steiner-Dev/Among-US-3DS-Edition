using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobePanel : MonoBehaviour {

    public void SetColor()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().m_color = this.GetComponent<UnityEngine.UI.Image>().color;
    }
}
