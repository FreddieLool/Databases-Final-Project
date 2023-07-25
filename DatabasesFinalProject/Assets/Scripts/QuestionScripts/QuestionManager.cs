using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] AudioClip RightAnswer, WrongAnswer;
    [SerializeField] TMPro.TMP_Text Question_text;
    [SerializeField] TMPro.TMP_Text Ans1_text;
    [SerializeField] TMPro.TMP_Text Ans2_text;
    [SerializeField] TMPro.TMP_Text Ans3_text;
    [SerializeField] TMPro.TMP_Text Ans4_text;
    RegisterPlayer rp;
    ScoreManager scoreManager;
    GetScore getScore;
    public AudioSource src;
    int correctID;
    int whichQuestion = 1;
    int playerOneScore = 0;
    int playerTwoScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        rp = FindObjectOfType<RegisterPlayer>();
        getScore = GetComponent<GetScore>();
        scoreManager = GetComponent<ScoreManager>();    
        StartCoroutine(GetQuestion(whichQuestion));
        playerOneScore =  getScore.GetPlayerScore(1);

    }


    IEnumerator GetQuestion(int id)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44335/api/GetQuestion/" + id);
        whichQuestion++;
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);


            Question question = JsonUtility.FromJson<Question>(www.downloadHandler.text);
            if (question != null)
            {
                Question_text.text = question.text;
                Ans1_text.text = question.ans1;
                Ans2_text.text = question.ans2;
                Ans3_text.text = question.ans3;
                Ans4_text.text = question.ans4;
                correctID = question.correctID;
                Debug.Log(question.correctID.ToString());
            }
        }
    }

    public void CheckQuestion()
    {
        if (ButtonReciever.ClickedButtonName == correctID.ToString())
        {
            src.clip = RightAnswer;
            src.Play();
            switch (rp.player_id)
            {
                case 1:
                    scoreManager.SetPlayerScore();
                    break;
                case 2:
                    break;
                default:
                    break;
            }

            Debug.Log("GOOD JOB!!!!1");
            //add score to player LET'S GO
            StartCoroutine(GetQuestion(whichQuestion));
        }
        else
        {
            src.clip = WrongAnswer;
            src.Play();
            Debug.Log("Wrong Answer");
        }
    }
}
