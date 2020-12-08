using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// prefabから敵を一定間隔で生成する
// @解説: 授業2回目のP.12 〜
public class Spawner : MonoBehaviour
{
    [Tooltip("敵の生成間隔(秒)")] public float span = 1f;
    [Tooltip("敵のprefab")] public GameObject enemyPrefab;
    float delta = 0; // 間隔カウント用

    // ----------
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            // prefabをもとに敵を生成。(このSpawnerの座標に)
            Instantiate(enemyPrefab, this.transform);
        }
    }
}
