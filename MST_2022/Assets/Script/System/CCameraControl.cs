using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraControl : MonoBehaviour
{
    private GameObject _gMainCamera;      // ���C���J�����i�[�p
    private GameObject _gSubCamera;       // �T�u�J�����i�[�p 

    void Start()
    {
        // ���C���J�����ƃT�u�J���������ꂼ��擾
        _gMainCamera = GameObject.Find("MainCamera");
        _gSubCamera = GameObject.Find("SubCamera");

        // �T�u�J�������A�N�e�B�u�ɂ���
        _gSubCamera.SetActive(false);
    }

    void Update()
    {
        // �X�y�[�X�L�[��������Ă���ԃT�u�J�������A�N�e�B�u�ɂ���i�b��j
        if (Input.GetKey("space"))
        {
            // �T�u�J�������A�N�e�B�u�ɐݒ�
            _gMainCamera.SetActive(false);
            _gSubCamera.SetActive(true);
        }
        else
        {
            // ���C���J�������A�N�e�B�u�ɐݒ�
            _gSubCamera.SetActive(false);
            _gMainCamera.SetActive(true);
        }
    }
}
