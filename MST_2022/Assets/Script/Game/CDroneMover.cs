/*==============================================================================
    [CDroneMove.cs]
    �E�h���[������
--------------------------------------------------------------------------------
    2021.09.13 @Fujiwara Aiko
================================================================================
    History
        2021.09.13 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CDroneMover : MonoBehaviour
{

    Rigidbody _rigidbody;   // ���g��RigidBody
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // �Q�Ƃ��擾
    }
    

    void Update()
    {
        // ���͂����m
        Vector2 dir = Vector2.zero; // �ړ�����

        if (Input.GetKey(KeyCode.D)) // �E
        {
            dir += new Vector2(1.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A)) // ��
        {
            dir += new Vector2(-1.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.W)) // �O
        {
            dir += new Vector2(0.0f, 1.0f);
        }

        if (Input.GetKey(KeyCode.S)) // ���
        {
            dir += new Vector2(0.0f, -1.0f);
        }

        // �ړ�
        Move(dir);

    }

    // dir�����Ɉړ�����
    // �����F dir �ړ�����
    public void Move(Vector2 dir)
    {
        Vector3 force = transform.right * dir.x + transform.forward * dir.y;
        _rigidbody.AddForce(force, ForceMode.Force);
    }

}
