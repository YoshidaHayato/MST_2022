using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowSubCamera : MonoBehaviour
{
    private GameObject _gSubCamera;              // ���C���J�������i�[�p
    private GameObject _gPlayer;                  // �v���C���[���i�[�p
    public float _fCameraRotateSpeed = 2.0f;      // ��]�̑���

    void Start()
    {
        // �T�u�J�����̎擾
        _gSubCamera = GameObject.Find("SubCamera");

        // �v���C���[�̏����擾
        this._gPlayer = GameObject.Find("Player");
    }

    void Update()
    {
        // �V�������W�̒l��������
        transform.position = _gPlayer.transform.position;

        RotateCamera();
    }

    private void RotateCamera()
    {
        // Vector3��X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * _fCameraRotateSpeed,
                                    Input.GetAxis("Mouse Y") * _fCameraRotateSpeed, 0);

        // �T�u�J��������]������
        _gSubCamera.transform.RotateAround(_gPlayer.transform.position, Vector3.up, angle.x);
        _gSubCamera.transform.RotateAround(_gPlayer.transform.position, transform.right, angle.y);
    }
}