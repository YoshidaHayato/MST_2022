/*==============================================================================
    [CSoundSetting.cs]
    �����ʒ��������鎞�ɕK�v�ȂȂ�₩�������܂����B
--------------------------------------------------------------------------------
    2021.10.11 @Author MISAKI SASAKI
================================================================================
    History
        2021.10.11 MISAKI SASAKI
            ���܂����B
        
/*============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CSoundSetting : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer = default;
    public static int _iMasterVol = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ����UP�i�{�^���Ƃ��ǂ����̃X�N���v�g�ŌĂԗp�j
    public void OnVolUp()
    {
        if (_iMasterVol == 1)
        {
            Debug.Log("���ʂQ��");
            _audioMixer.SetFloat("SE", 0.0f);
            _audioMixer.SetFloat("BGM", 0.0f);

            //vol1.SetActive(true);
            //vol2.SetActive(true);
            //vol3.SetActive(false);

            _iMasterVol++;
        }
        else if (_iMasterVol == 2)
        {
            Debug.Log("���ʂR��");
            _audioMixer.SetFloat("SE", 15.0f);
            _audioMixer.SetFloat("BGM", 15.0f);

            //vol1.SetActive(true);
            //vol2.SetActive(true);
            //vol3.SetActive(true);

            _iMasterVol++;
        }
    }
    // ����DOWN�i�{�^���Ƃ��ǂ����̃X�N���v�g�ŌĂԗp�j
    public void OnVolDown()
    {
        if (_iMasterVol == 2)
        {
            Debug.Log("���ʂP��");
            _audioMixer.SetFloat("SE", -15.0f);
            _audioMixer.SetFloat("BGM", -15.0f);

            //vol1.SetActive(true);
            //vol2.SetActive(false);
            //vol3.SetActive(false);

            _iMasterVol--;
        }
        else if (_iMasterVol == 3)
        {
            Debug.Log("���ʂQ��");
            _audioMixer.SetFloat("SE", 0.0f);
            _audioMixer.SetFloat("BGM", 0.0f);

            //vol1.SetActive(true);
            //vol2.SetActive(true);
            //vol3.SetActive(false);

            _iMasterVol--;
        }
    }
}
