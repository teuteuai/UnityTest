using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floortoggle : MonoBehaviour
{
    public GameObject floor1; // 1�Ԃ̏��I�u�W�F�N�g
    public GameObject floor2; // 2�Ԃ̏��I�u�W�F�N�g

    private bool isFloor1Active = true; // 1�Ԃ̏����A�N�e�B�u���ǂ���
    private float toggleInterval = 1f; // �؂�ւ��Ԋu�i�b�j

    private void Start()
    {
        // ������Ԃ�1�Ԃ̏���\���A2�Ԃ̏����\���ɂ���
        floor1.SetActive(true);
        floor2.SetActive(false);

        // 1�b���Ƃ� ToggleFloor ���\�b�h���Ăяo���R���[�`�����J�n
        StartCoroutine(ToggleFloor());
    }

    // 1�b���Ƃɏ���؂�ւ���R���[�`��
    private IEnumerator ToggleFloor()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);

            // 1�Ԃ̏���2�Ԃ̏��̕\����؂�ւ���
            floor1.SetActive(!isFloor1Active);
            floor2.SetActive(isFloor1Active);

            isFloor1Active = !isFloor1Active;
        }
    }
}
