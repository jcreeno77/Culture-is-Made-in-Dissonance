using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    public delegate void textCompleteAction();
    public static event textCompleteAction onEnterPressed;

    public delegate void correctCharPressed();
    public static event correctCharPressed onCorrectCharPressed;

    public bool entPressValid = false;
    public int playerTurn;
    public bool matchingCharPressed;
    public float WPM;
    float leftWPM;
    float rightWPM;
    float timer;
    int charsPressed;
    int player1Score;
    int player2Score;

    [SerializeField] GameObject player1WPM;
    [SerializeField] GameObject player2WPM;
    [SerializeField] GameObject player1ScoreText;
    [SerializeField] GameObject player2ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = 0;
        matchingCharPressed = false;
        timer = 0f;

        player1Score = 0;
        player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (entPressValid)
        {
            if (onEnterPressed != null)
            {
                onEnterPressed();
            }
            if (playerTurn % 2 == 0)
            {
                player1Score += (int)WPM;
            }
            else
            {
                player2Score += (int)WPM;
            }


            timer = 0f;
            charsPressed = 0;
            playerTurn++;
            entPressValid = false;
            
        }


        if (matchingCharPressed)
        {
            matchingCharPressed = false;
            charsPressed++;
            WPM = (charsPressed / timer)*60;
            WPM = WPM / 4.8f;
            if(onCorrectCharPressed != null)
            {
                onCorrectCharPressed();
            }
        }

        if (playerTurn % 2 == 0)
        {
            leftWPM = WPM;
            rightWPM = 0;
        }
        else
        {
            rightWPM = WPM;
            leftWPM = 0;
        }

        player1WPM.GetComponent<TextMeshProUGUI>().text = ((int)leftWPM).ToString();
        player2WPM.GetComponent<TextMeshProUGUI>().text = ((int)rightWPM).ToString();
        player1ScoreText.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        player2ScoreText.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();

    }
}
