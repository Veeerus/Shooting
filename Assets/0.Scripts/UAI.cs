using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UAI : MonoBehaviour
{
    [SerializeField] private TMP_Text curScoreTxt;
    [SerializeField] private TMP_Text bestScoreTxt;
    private int curScore;
    public int CurrentScore
    {
        get { return curScore; }
        set
        {
            curScore = value;
            curScoreTxt.text = $"{curScore}";
            if (curScore >= bestScore)
            {
                BestScore = curScore;
            }
        }
    }
    private int bestScore;
    public int BestScore
    {
        get { return bestScore; }
        set
        {
            bestScore = value;
            bestScoreTxt.text = $"{bestScore}";
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            int bset = PlayerPrefs.GetInt("bestScore");
        }
        else
        {
            BestScore = 0;
        }
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}