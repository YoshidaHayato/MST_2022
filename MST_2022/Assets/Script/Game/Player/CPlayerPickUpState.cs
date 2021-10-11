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

    CPickedUpObject _gPickUpObject;   // �����グ��

    CPickedUpObject _gForwardObject;    // �ڂ̑O�ɂ���I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        _cPlayerMover.Walk(direction);
    }

    public void Action()
    {
        Debug.Log(_gForwardObject);
        Debug.Log(_gPickUpObject);
        if (_gPickUpObject != null)
        {
            _gPickUpObject.transform.parent = null;
            _gPickUpObject.Put();
            _gPickUpObject = null;

        }
        else if(_gForwardObject != null &&
            _gPickUpObject == null)
        {
            _gPickUpObject = _gForwardObject;
            _gPickUpObject.PickedUp(transform.parent, transform.position + Vector3.up);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        CPickedUpObject obj = other.GetComponent<CPickedUpObject>();
        if(obj != null)
        {
            _gForwardObject = obj;
        }
        Debug.Log(other + "enter");
    }

    void OnTriggerExit(Collider other)
    {
        CPickedUpObject obj = other.GetComponent<CPickedUpObject>();
        if (obj == _gForwardObject)
        {
            _gForwardObject = null;
        }
        Debug.Log(other + "exit");
    }


}
