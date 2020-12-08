using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [RequireComponent(typeof(Rigidbody))]
public class ColliderController : MonoBehaviour
{
    [Tooltip("衝突してきたオブジェクトのTag")]
    public string _tag;

    [Tooltip("ここにPrefabを指定すると、衝突時にオブジェクトを生成する")]
    public GameObject createPrefab = null;

    [Tooltip("これにチェックを付けると、衝突してきた相手をDestroyする")]
    public bool destroy = false;

    [Tooltip("衝突時に他に処理を登録したい場合、ここに追加する")]
	public UnityEvent enterActions;

    [Tooltip("当たり判定から抜けるときに処理を登録したい場合、ここに追加する")]
	public UnityEvent exitActions;

    // -----
    // 衝突時のイベント
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(_tag))
            collideAction(col.gameObject);
    }

    // すり抜け時のイベント
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(_tag))
            collideAction(col.gameObject);
    }

    // すり抜けから抜けるときのイベント
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag(_tag))
            exitAction(col.gameObject);
    }

    // CharacterControllerで衝突時のイベント
    // また、「物体が動いている間だけ」呼び出しが発生する模様 
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == _tag)
            collideAction(hit.gameObject);
    }

    // -----
    // 共通処理
    void collideAction(GameObject gameObject)
    {
        // prefabが指定されているなら生成
        if (createPrefab != null)
            Instantiate(createPrefab, transform.position, createPrefab.transform.rotation);

        // 削除する指定があるなら、削除
        if (destroy)
            Destroy(gameObject);

        // 他に処理が登録されているなら実行
        enterActions.Invoke();
    }

    void exitAction(GameObject gameObject)
    {
        // 処理が登録されているなら実行
        exitActions.Invoke();
    }

}
