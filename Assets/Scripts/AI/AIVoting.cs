using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVoting : MonoBehaviour {
    public void Vote()
    {
        GameObject.Find("Voting Manager").GetComponent<VotingManager>().AddVoteTo(Random.Range(0, 10));
    }
}
