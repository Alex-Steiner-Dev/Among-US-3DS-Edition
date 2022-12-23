using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyMeeting : MonoBehaviour {
	[SerializeField] private AudioSource alarm;

	public void CallMeeting()
	{
		alarm.enabled = true;
	}
}
