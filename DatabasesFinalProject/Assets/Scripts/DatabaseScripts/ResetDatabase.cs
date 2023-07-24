using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ResetDatabase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetDatabaseValues();
    }

    void ResetDatabaseValues()
    {
        StartCoroutine(ResetConnectionCoroutine(1));
        StartCoroutine(ResetConnectionCoroutine(2));
        StartCoroutine(ResetNameCoroutine(1));
        StartCoroutine(ResetNameCoroutine(2));
        Debug.Log("Datbase Reset");
    }



    IEnumerator ResetConnectionCoroutine(int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/SetConnection?connection=0" + "&ID=" + ID);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator ResetNameCoroutine(int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/SetPlayer?name=null" + "&ID=" + ID);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }
}
