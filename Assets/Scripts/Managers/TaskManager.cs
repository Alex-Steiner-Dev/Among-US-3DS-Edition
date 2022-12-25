using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
    [SerializeField] public string[] shortTasks;
    [SerializeField] public string[] commonTasks;
    [SerializeField] public string[] longTasks;

    public void CompletedTask(string name)
    {
        Debug.Log("Task finished: " + name);
    }
}
