using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignEngine : MonoBehaviour {

	[SerializeField] private GameObject engine;
	[SerializeField] private UnityEngine.UI.Slider slider;

	float valueBefore = -90;
	readonly float OFFSET = 2.19f;

	private void Update()
	{ 
        if (slider.value == -2)
        {
            engine.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
    }

    public void MoveEngine()
	{
		engine.transform.localEulerAngles = new Vector3(0,0,1) * slider.value / OFFSET * -1;
	}
}