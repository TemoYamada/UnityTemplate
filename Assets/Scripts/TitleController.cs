using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Title シーン全体を司るクラス
public class TitleController : MonoBehaviour
{
    void Start()
    {
        // @解説: 授業3回目のP.4 〜
        // BGM
        AudioManager.Instance.PlayMusic("Funky", 0);
    }
}
