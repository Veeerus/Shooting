using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum GameState
{
    Play,
    Pause,
    Stop
}

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameover;
    public static UI instance;
    [SerializeField] private Image lifeImg;
    [SerializeField] private TMP_Text scoreTxt;
    public FixedJoystick joy;

    Player p;
    public GameState gameState = GameState.Pause;

    public int Life { get; set; } = 3;

    private int score;
    public int Score
    {
        get { return score; } 
        set
        {
            score = value;
            scoreTxt.text = $"Score : {score}";
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        SetLifeImage();
        Score = 0;
    }

    private void FixedUpdate()
    {
        float x = joy.Horizontal;
        float y = joy.Vertical;

        Vector2 vec = new Vector2(x, y);
        vec.Normalize();

        if(p == null)
        {
            p = FindObjectOfType<Player>();
        }

        p.Move(x, y);
    }

    public void SetLifeImage()
    {
        float width = 66.6f;

        lifeImg.rectTransform.sizeDelta = new Vector2(width * Life, 66.6f);
    }
    public void ShowGameOver()
    {
        gameover.SetActive(true);
        gameState = GameState.Stop;
    }
    public void OnRetry()
    {
        SceneChange.instance.OnGoGame();
    }
    public void OnExit()
    {
        SceneChange.instance.OnGoLobby();
    }
}
