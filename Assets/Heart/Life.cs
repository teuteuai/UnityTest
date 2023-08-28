using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Life : MonoBehaviour
{
    private PlayerInfo playerInfo;

    public bool rotate; // ��]�̗L��

    public float rotationSpeed; // ��]���x

    public AudioClip collectSound; // �R���N�g���̉�

    public GameObject collectEffect; // �R���N�g���̃G�t�F�N�g

    // �t���[�����Ƃ̍X�V�̂��߂̃��\�b�h
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    // ���̃R���C�_�[���g���K�[�ɓ������Ƃ��ɌĂ΂�郁�\�b�h
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect(); // �R���N�g�������Ăяo��
        }

        GameObject obj = GameObject.FindWithTag("Player");
        playerInfo = obj.GetComponent<PlayerInfo>();
        playerInfo.life++;

        UnityEngine.Debug.Log(playerInfo.life);
    }

    // �R���N�g�������s�����\�b�h
    private void Collect()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        Destroy(gameObject); // �Q�[���I�u�W�F�N�g���폜
    }
}
