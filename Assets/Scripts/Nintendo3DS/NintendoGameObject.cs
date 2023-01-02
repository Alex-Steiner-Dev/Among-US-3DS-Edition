using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NintendoGameObject : MonoBehaviour {
	private void OnBecomeVisible()
	{
       enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
}
