using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitingForOtherPlayer : MonoBehaviour
{
    bool player1Connected = false;
    bool player2Connected = false;


    public void RecievePlayerConnection(int playerID)
    {
        StartCoroutine(UpdatePlayerCoroutine(playerID));
    }

    IEnumerator UpdatePlayerCoroutine(int playerID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/getconnection/" + playerID);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            int conn = int.Parse((string)www.downloadHandler.text);

            if (playerID == 1 && conn == 1)
            {
                Debug.Log("Player 1 connected");
                player1Connected = true;
            }
            else if (playerID == 2 && conn == 1)
            {
                Debug.Log("Player 2 connected");
                player2Connected = true;
            }

            if (player1Connected && player2Connected)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
