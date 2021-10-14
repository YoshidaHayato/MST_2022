/*==============================================================================
    [CPlayerPickUpState.cs]
    �E�����グ����u������ł���v���C���[���
--------------------------------------------------------------------------------
    2021.10.11 @Fujiwara Aiko
================================================================================
    History
        2021.10.11 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/


using UnityEngine;

public class CPlayerPickUpState : MonoBehaviour, IPlayerState
{
    [SerializeField] CPlayerMover _cPlayerMover = null;     // �v���C���[�𓮂����p

    private CPickedUpObject _gPickUpObject;   // �����グ�Ă���I�u�W�F�N�g

    private CPickedUpObject _gForwardObject;    // �ڂ̑O�ɂ���I�u�W�F�N�g


    // Move ����
    // �����F direction ����
    public void Move(Vector2 direction)
    {
        _cPlayerMover.Walk(direction);
    }
    
    // Action �A�N�V���� �`�����グ��u���`
    public void Action()
    {
        // ���݂̏�Ԃɂ���Ď����グ��or�u��or�������Ȃ�

        if(_gForwardObject != null &&
            _gPickUpObject == null)
        {// �����グ��
            _gPickUpObject = _gForwardObject;
            _gPickUpObject.PickedUp(transform.parent, transform.position);
        }
        else if (_gPickUpObject != null)
        {// �u��
            _gPickUpObject.transform.parent = null;
            _gPickUpObject.Put();
            _gPickUpObject = null;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CPickedUpObject obj = other.GetComponent<CPickedUpObject>();
        if(obj != null)
        {
            _gForwardObject = obj;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CPickedUpObject obj = other.GetComponent<CPickedUpObject>();
        if (obj == _gForwardObject)
        {
            _gForwardObject = null;
        }
    }

}
