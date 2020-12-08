using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Play シーン全体を司るクラス
public class PlayController : MonoBehaviour
{
    [Tooltip("スコア表示用テキスト")]
    public Text scoreText;

    int score = 0;

    // -----
    void Start()
    {
        // @解説: 授業3回目のP.4 〜
        // BGM
        AudioManager.Instance.PlayMusic("Funky", 0);
    }

    // -----
    // 点数を加算する
    public void AddScore()
    {
        // SE
        AudioManager.Instance.PlaySound2D("Boink");

        // スコアを加算
        score++;    // (score = score + 1と同等)

        // スコア表示
        scoreText.text = score.ToString();
    }
}
