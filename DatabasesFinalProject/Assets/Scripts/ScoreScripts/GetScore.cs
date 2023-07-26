using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetScore : MonoBehaviour
{
    int score = 0;

    public int GetPlayerScore(int ID)
    {
        GetScoreCoroutine(ID);
        return score;
    }



    IEnumerator GetScoreCoroutine(int ID)
    {
        score = 0;
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
