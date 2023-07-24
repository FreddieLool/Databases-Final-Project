using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectPlayers : MonoBehaviour
{

    public void SetPlayerConnection(int connection, int ID)
    {
        StartCoroutine(ConnectPlayerCoroutine(connection, ID));
    }
    IEnumerator ConnectPlayerCoroutine(int connection, int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/SetConnection?connection=" + connection + "&ID=" + ID);
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
