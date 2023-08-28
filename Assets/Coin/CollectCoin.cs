using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectCoin : MonoBehaviour
{
    public bool rotate; // 回転の有無

    public float rotationSpeed; // 回転速度

    public AudioClip collectSound; // コレクト時の音

    public GameObject collectEffect; // コレクト時のエフェクト

    // フレームごとの更新のためのメソッド
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    // 他のコライダーがトリガーに入ったときに呼ばれるメソッド
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect(); // コレクト処理を呼び出す
        }
    }

    // コレクト処理を行うメソッド
    public void Collect()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        Destroy(gameObject); // ゲームオブジェクトを削除
    }
}
