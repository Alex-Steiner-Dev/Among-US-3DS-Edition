using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartReactor : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource press;

    [SerializeField] private GameObject[] inputs;
    [SerializeField] private GameObject[] outputs;

    [SerializeField] private List<int> seqList = new List<int> { };

    int count;
    int sequenceCount;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartTask()
    {
        count++;
        ReactorSequence(count);
        StartCoroutine(ExecuteInput(seqList));
    }

    private void ReactorSequence(int count)
    {
        // create sequence
        seqList.Add(Random.Range(0, 8));
    }

    public void RedoTask()
    {
        StopAllCoroutines();

        foreach (GameObject input in inputs)
        {
            input.GetComponent<Image>().enabled = false;
        }

        sequenceCount = 0;
        count = 0;

        seqList = new List<int> { };

        for (int i = 1; i < outputs.Length; i++)
        {
            outputs[i].GetComponent<Image>().color = Color.white;
        }

        StartTask();
    }


    public void TrySequence(int value)
    {
        if(value == seqList[sequenceCount])
        {
            if (sequenceCount == count - 1)
            {
                if (count < 4)
                {
                    outputs[count].GetComponent<Image>().color = new Color(0, 190, 0);
                    sequenceCount = 0;
                    StartTask();
                }
                else
                {
                    GameObject.Find("TaskManager").GetComponent<TaskManager>().TaskCompleted(gameObject);
                }
            }

            else
            {
                sequenceCount++;
            }
        }

        else
        {
            RedoTask();
        }
    }

    IEnumerator ExecuteInput(List<int> seq)
    {
        for(int i = 0; i < seq.Count; i++)
        {
            inputs[seqList[i]].GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(1.5f);
            inputs[seqList[i]].GetComponent<Image>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.onUseButton.AddListener(() => StartTask());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            gameManager.onUseButton.RemoveListener(() => StartTask());
        }
    }
}