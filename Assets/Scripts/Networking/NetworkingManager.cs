using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkingManager : MonoBehaviour {
    [SerializeField] private string m_url;

    [SerializeField] private UnityEngine.UI.Text log;

    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(m_url);
        yield return www.Send();

        if (www.isError)
        {
            log.text = www.error.ToString();
        }
        else
        {
           
            log.text = www.downloadHandler.text;
        }
    }
}
