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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CPickedUpObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Collider _collider = null;

    private void Start()
    {
        

    }
    public void PickedUp(Transform parent, Vector3 position)
    {
        
        _rb.isKinematic = true;
        _collider.enabled = false;

        transform.parent = parent;
        transform.position = position;
    }

    public void Put()
    {
        _rb.isKinematic = false;
        _collider.enabled = true;
    }
}
