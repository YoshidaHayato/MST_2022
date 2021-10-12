/*==============================================================================
    [CTargetFollowCamera.cs]
    �E�^�[�Q�b�g������Ԋu�����ĒǏ]����J����
--------------------------------------------------------------------------------
    2021.10.11 @Fujiwara Aiko
================================================================================
    History
        2021.10.11 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/


using UnityEngine;

public class CTargetFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _tTarget = null;    // �ǂ�������Ώ�

    [SerializeField] private bool _isApplyCurrentOffset = false;
    [SerializeField] private Vector3 _vOffsetPosition = new Vector3(0.0f, 0.0f, 0.0f);  // �^�[�Q�b�g�Ƃǂꂭ�炢����Ă��邩
    private Quaternion _vOffsetRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);  // �p�x

    // Start is called before the first frame update
    void Start()
    {
        if(_tTarget == null)
        {
            Debug.LogWarning("�J�����̒Ǐ]�Ώۂ����܂���B");
            Destroy(this);
        }

        // ���݂̃^�[�Q�b�g�Ƃ̊֌W���I�t�Z�b�g�ɐݒ�
        if(_isApplyCurrentOffset)
        {
            _vOffsetPosition = transform.position - _tTarget.position;
            _vOffsetRotation = transform.rotation;
        }
    }
    

    void LateUpdate()
    {
        transform.position = _tTarget.position + _vOffsetPosition;
        //transform.position = Vector3.Lerp(transform.position, _tTarget.position + _vOffsetPosition, Time.deltaTime * 2.0f);
    }
}
