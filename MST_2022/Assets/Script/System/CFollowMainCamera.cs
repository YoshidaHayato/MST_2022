using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowMainCamera : MonoBehaviour
{
    private GameObject _gMainCamera;              // ���C���J�������i�[�p
    private GameObject _gPlayer;                  // �v���C���[���i�[�p
    private Vector3 _vOffset;                     // ���΋����擾�p
    public float _fCameraRotateSpeed = 2.0f;      // ��]�̑���

    void Start()
    {
        // ���C���J�����̎擾
        _gMainCamera = GameObject.Find("MainCamera");

        // �v���C���[�̏����擾
        this._gPlayer = GameObject.Find("Player");

        // MainCamera(�������g)��Player�Ƃ̑��΋��������߂�
        _vOffset = transform.position - _gPlayer.transform.position;

    }

    void Update()
    {
        // �V�������W�̒l��������
        transform.position = _gPlayer.transform.position + _vOffset;

        RotateCamera();
    }

    private void RotateCamera()
    {
        // Vector3��X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * _fCameraRotateSpeed, 
                                    Input.GetAxis("Mouse Y") * _fCameraRotateSpeed, 0);

        // ���C���J��������]������
        _gMainCamera.transform.RotateAround(_gPlayer.transform.position, Vector3.up, angle.x);
        _gMainCamera.transform.RotateAround(_gPlayer.transform.position, transform.right, angle.y);
    }
}
