using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Photon.MonoBehaviour {

	[SerializeField] protected Sprite m_hat;
	[SerializeField] protected Sprite m_leg;

	[SerializeField] protected Color m_color;

	[SerializeField] protected string[] m_tasks = new string[3];

	[SerializeField] private UnityEngine.UI.Text taskList;

	[SerializeField] private PhotonView photonView;

	[SerializeField] private GameTask[] tasksScripts;

	private void LoadPlayer()
	{
		photonView = GetComponent<PhotonView>();

		if (!photonView.isMine)
		{
			GetComponent<PlayerMovement>().enabled = false;
			return;
		}

		AssignTaskScript();
		AssignTask();
		EnableTask();
    }

	private void AssignTaskScript()
	{
		GameObject[] allTasks = GameObject.FindGameObjectsWithTag("Task");

		for(int i = 0; i < allTasks.Length; i++)
		{
			tasksScripts[i] = allTasks[i].GetComponent<GameTask>();

            MonoBehaviour[] scripts = allTasks[i].GetComponents<MonoBehaviour>();
            for (int j = 0; j < allTasks.Length; j++)
            {
				if (scripts[i] != this)
				{
					scripts[i].enabled = false;
					scripts[i].StopAllCoroutines();
					scripts[i].gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
            }
        }
	}

	private void AssignTask()
	{
        TaskManager taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        taskList = GameObject.Find("Task List").GetComponent<UnityEngine.UI.Text>();

        m_tasks[0] = taskManager.shortTasks[Random.Range(0, taskManager.shortTasks.Length)];
        m_tasks[1] = taskManager.commonTasks[Random.Range(0, taskManager.commonTasks.Length)];
        m_tasks[2] = taskManager.longTasks[Random.Range(0, taskManager.longTasks.Length)];

        foreach (string task in m_tasks)
        {
            taskList.text += task + "\n";
        }
    }

	private void EnableTask()
	{
		for(int i = 0; i < tasksScripts.Length; i++)
		{
			for(int j = 0; j < m_tasks.Length; j++)
			{
				if(tasksScripts[i].taskName == m_tasks[j])
				{
					tasksScripts[i].enabled = true;
				}
            }
		}
	}
}
