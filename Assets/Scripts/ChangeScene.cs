using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using DG.Tweening;

// ボタンを押したらシーンを変更する
public class ChangeScene : MonoBehaviour
{
    [Tooltip("ボタンを押してからシーン移動までの間隔")]
    public float waitTime = 0.5f;

    // -- ボタン押下時イベント --
    public void OnButtonClicked(string nextScene)
    {
        // @解説: コルーチンについては授業2回目参照。このソースはP.6 〜
        StartCoroutine(WaitButtonClicked(nextScene));
    }

    // -----
    IEnumerator WaitButtonClicked(string nextScene)
    {
        // @解説: 授業3回目のP.5 〜
        // SE音
        AudioManager.Instance.PlaySound2D("Buzz");

        // 指定した大きさにビヨヨーンとする
        GetComponent<RectTransform>().DOPunchScale(
            new Vector3(0.1f, 0.1f, 0f), waitTime);

        // waitTime秒待つ
        yield return new WaitForSeconds(waitTime);

        // シーン移動する
        SceneManager.LoadScene(nextScene);
    }
}
