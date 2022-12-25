using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	[SerializeField] private Animator m_animator;

	public bool isImpostor;

	private void Start()
	{
		m_animator = GetComponent<Animator>();

		if(!isImpostor)
		{
            StartCoroutine(DoCrewmate());
		}
		else
		{
            StartCoroutine(DoImpostor());
		}
    }

	IEnumerator DoCrewmate()
	{
		while (true)
		{
			yield return new WaitForSeconds(0);
		}
	}


    IEnumerator DoImpostor()
    {
        while (true)
        {
			if (GameObject.Find("Manager").GetComponent<Manager>().isPlaying) // currently playing and trying to kill others
			{

			}

			else // doing meeting for example
			{

			}

            yield return new WaitForSeconds(0);
        }
    }
}
