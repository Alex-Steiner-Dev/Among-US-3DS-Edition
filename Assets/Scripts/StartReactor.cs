using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartReactor : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private AudioSource press;

    [SerializeField] private GameObject[] inputs;

    int count;
    int sequenceCount;
    int[] sequence;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.EnableUseButton();
            gameManager.SetPanel(panel);

            gameManager.onUseButton.AddListener(() => StartTask());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.DisableUseButton();
            gameManager.onUseButton.RemoveListener(StartTask);
        }
    }

    public void StartTask()
    {
        count++;
        sequence = ReactorSequence(count);
        StartCoroutine(ExecuteInput(sequence));
    }

    private int[] ReactorSequence(int count)
    {
        // create sequence
        int[] seq = new int[count];

        for (int i = 0; i < count; i++)
        {
            seq[i] = Random.Range(0, 9);
        }

        return seq;
    }

    public void TrySequence(int value)
    {
        if(value == sequence[sequenceCount])
        {
            if(sequenceCount == count - 1)
            {
                if(count - 1 < 5)
                    StartTask();
            }

            else
            {
                sequenceCount++;
            }
        }
    }

    IEnumerator ExecuteInput(int[] seq)
    {
        for(int i = 0; i < seq.Length; i++)
        {
            inputs[sequence[i]].GetComponent<UnityEngine.UI.Image>().enabled = (true);
            yield return new WaitForSeconds(1f);
            inputs[sequence[i]].GetComponent<UnityEngine.UI.Image>().enabled = (false);
        }
    }
}