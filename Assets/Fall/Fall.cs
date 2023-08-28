using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField] 
    private float destroyDelay = 3.0f; // �I�u�W�F�N�g�������܂ł̑ҋ@����

    bool flag = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (flag == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(DestroyAfterDelay()); // �v���C���[�ƏՓˌ�A��莞�ԑ҂��Ă���I�u�W�F�N�g��j������
            }

            flag = false;
        }
    }

    // ��莞�ԑ҂��Ă���I�u�W�F�N�g��j������R���[�`��
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay); // �w�肵���ҋ@���Ԃ����R���[�`�����ꎞ��~
        Rigidbody rb = gameObject.AddComponent<Rigidbody>(); //Rigidbody�������A�d�͂�^����
    }
}
