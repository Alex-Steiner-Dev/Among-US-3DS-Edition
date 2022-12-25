using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] protected Sprite m_hat;
	[SerializeField] protected Sprite m_leg;

	[SerializeField] public Color m_color;

	[SerializeField] protected string[] m_tasks = new string[3];

	[SerializeField] private UnityEngine.UI.Text taskList;


	[SerializeField] private GameTask[] tasksScripts;

	[SerializeField] public bool isImposter;

	Color temp;
	private void Awake()
	{
		temp = m_color;
    }

	private void Update()
	{
		if(temp != m_color)
		{
			GetComponent<SpriteRenderer>().color = m_color;
			temp = m_color;
		}
	}

	public void LoadCrewmate()
	{
        AssignTaskScript();
        AssignTask();
        EnableTask();
    }

	private void AssignTaskScript()
	{
		GameObject[] allTasks = GameObject.FindGameObjectsWithTag("Task");
		tasksScripts = new GameTask[allTasks.Length];

		for(int i = 0; i < allTasks.Length; i++)
		{
			tasksScripts[i] = allTasks[i].GetComponent<GameTask>();
        }
	}

	private void AssignTask()
	{
        TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
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
				else
				{
                    Destroy(tasksScripts[j].gameObject.GetComponent<GameTask>().panel);
                    tasksScripts[j].enabled = false;
                }
            }
		}
	}
}
