using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreManager : MonoBehaviour
{
    public void SetPlayerScore(int score, int ID)
    {
        SetScoreCoroutine(score, ID);
    }



    IEnumerator SetScoreCoroutine(int score, int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/SetScore?score=" + score + "&ID=" + ID);
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
