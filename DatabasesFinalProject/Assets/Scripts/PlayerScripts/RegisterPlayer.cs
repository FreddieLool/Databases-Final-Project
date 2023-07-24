using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(ConnectPlayers))]
public class RegisterPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputField;
    string player_name;
    public int player_id = 0;
    ConnectPlayers connectPlayers;

    private void Start()
    {
        connectPlayers = GetComponent<ConnectPlayers>();
    }
    public void UpdatePlayerFunc()
    {
        player_name = InputField.text;
        Debug.Log(player_name);
        if (ButtonReciever.ClickedButtonName == "Player1")
        {
            player_id = 1;
            connectPlayers.SetPlayerConnection(1, player_id);
            Debug.Log("Player1");
        }
        else
        {
            player_id = 2;
            connectPlayers.SetPlayerConnection(1, player_id);
            Debug.Log("Player2");
        }
        StartCoroutine(UpdatePlayerCoroutine(player_name, player_id));
    }

    IEnumerator UpdatePlayerCoroutine(string name, int ID)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/SetPlayer?name=" + name + "&ID=" + ID);
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
