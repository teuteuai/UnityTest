using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floortoggle : MonoBehaviour
{
    public GameObject floor1; // 1番の床オブジェクト
    public GameObject floor2; // 2番の床オブジェクト

    private bool isFloor1Active = true; // 1番の床がアクティブかどうか
    private float toggleInterval = 1f; // 切り替え間隔（秒）

    private void Start()
    {
        // 初期状態で1番の床を表示、2番の床を非表示にする
        floor1.SetActive(true);
        floor2.SetActive(false);

        // 1秒ごとに ToggleFloor メソッドを呼び出すコルーチンを開始
        StartCoroutine(ToggleFloor());
    }

    // 1秒ごとに床を切り替えるコルーチン
    private IEnumerator ToggleFloor()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);

            // 1番の床と2番の床の表示を切り替える
            floor1.SetActive(!isFloor1Active);
            floor2.SetActive(isFloor1Active);

            isFloor1Active = !isFloor1Active;
        }
    }
}
