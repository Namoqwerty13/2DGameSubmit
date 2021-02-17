using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text HighScore;

    public Transform Gameover;
    public bool gameover;

    public Transform Youwin;
    public bool youwin;

    public static float halfHeight;
    public static float ratio;
    public static float halfWidth;
    public static float bottom;

    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;  //orthographic size refers to the height.
        ratio = Camera.main.aspect; //aspect is the ratio of height to width
        halfWidth = halfHeight * ratio;
        bottom = -halfHeight + 0.5f;

        print(halfHeight);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score = " + score;

        HighScore.text = "High Score = " + PlayerPrefs.GetInt("Score");

        if (score == 10 && youwin == false)
        {
            YouWin();
        }

        if (Input.GetAxis("Cancel") != 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        print(PlayerPrefs.GetInt("Score"));
    }
    public void GameOver()
    {
        Instantiate(Gameover, new Vector3(0, 4f, 0), transform.rotation);
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        gameover = true;
    }
    public void YouWin()
    {
        Instantiate(Youwin, new Vector3(0, 4f, 0), transform.rotation);
        youwin = true;
    }
}
