using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField] private AudioSource m_taskComplete;

	public void TaskComplete()
	{
		m_taskComplete.Play();
	}
}
