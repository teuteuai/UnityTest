using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField] 
    private float destroyDelay = 3.0f; // オブジェクトを消すまでの待機時間

    bool flag = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (flag == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(DestroyAfterDelay()); // プレイヤーと衝突後、一定時間待ってからオブジェクトを破棄する
            }

            flag = false;
        }
    }

    // 一定時間待ってからオブジェクトを破棄するコルーチン
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay); // 指定した待機時間だけコルーチンが一時停止
        Rigidbody rb = gameObject.AddComponent<Rigidbody>(); //Rigidbodyを加え、重力を与える
    }
}
