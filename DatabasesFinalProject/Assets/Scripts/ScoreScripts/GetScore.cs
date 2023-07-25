using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetScore : MonoBehaviour
{
    int score = 0;

    public void GetPlayerScore(int ID)
    {
        GetScoreCoroutine(ID);
    }



    IEnumerator GetScoreCoroutine(int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/score/" + ID);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);


            score = int.Parse((string)www.downloadHandler.text);
        }
    }
}
