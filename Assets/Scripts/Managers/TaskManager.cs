using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour {
    [SerializeField] public string[] shortTasks;
    [SerializeField] public string[] commonTasks;
    [SerializeField] public string[] longTasks;

    public void TaskCompleted(GameObject task)
    {
        StartCoroutine(PlaySoundTaskComplete(task));
    }

    IEnumerator PlaySoundTaskComplete(GameObject task)
    {
        GameObject.Find("TaskCompleteSound").GetComponent<AudioSource>().Play();

        GameObject.Find("GameManager").GetComponent<GameManager>().DisableUseButton();
        task.GetComponent<Collider2D>().isTrigger = false;

        yield return new WaitForSeconds(1);

        GameObject.Find("Task List").GetComponent<Text>().text.Replace(task.GetComponent<GameTask>().taskName, "");

        Destroy(task.GetComponent<GameTask>().panel);
        task.GetComponent<GameTask>().enabled = false;
    }
}
