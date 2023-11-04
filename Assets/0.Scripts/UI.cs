using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public static UI instance;
    [SerializeField] private Image lifeImg;
    [SerializeField] private TMP_Text scoreTxt;
    public FixedJoystick joy;
    Player p;
    // Start is called before the first frame update
    public int Life { get; set; } = 3;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreTxt.text = $"Score:{score}";
        }
    }
    void Start()
    {
        instance = this;
        SetLifeImage();
        Score = 0;
    }

    // Update is called once per frame
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
        lifeImg.rectTransform.sizeDelta = new Vector2 (width * Life, 66.6f);
    }
}
