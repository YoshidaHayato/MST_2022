/*==============================================================================
    [CPickedUpObject.cs]
    �E�v���C���[���E����I�u�W�F�N�g
--------------------------------------------------------------------------------
    2021.10.11 @Fujiwara Aiko
================================================================================
    History
        2021.10.11 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/


using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CPickedUpObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb = null;          // ���g��Rigidbody
    [SerializeField] private Collider _collider = null;     // ���g��Collider  

    [SerializeField] private Vector3 _vSize = new Vector3(1.0f, 1.0f, 1.0f);    // �I�u�W�F�N�g�̑傫��

    // PickedUp �����グ����
    // �����F Parent �����グ��ꂽ���̐e�I�u�W�F�N�g�Aposition �����グ��ꂽ���̈ʒu
    public void PickedUp(Transform parent, Vector3 position)
    {
        _rb.isKinematic = true;     // �d�͂�������Ȃ�����
        _collider.enabled = false;  // ������ꎞ�I�ɃI�t�ɂ���

        // ���g���q�I�u�W�F�N�g�ɂ��A�ʒu��ύX
        transform.parent = parent;
        transform.localRotation = Quaternion.identity;
        transform.position = position + transform.forward * _vSize.x * 0.5f + transform.up * _vSize.y * 0.5f;

    }

    // Placed  �u�����
    public void Put()
    {
        // Rigidbody�Ɣ���̏�Ԃ����ɖ߂�
        _rb.isKinematic = false;
        _collider.enabled = true;
    }

}
