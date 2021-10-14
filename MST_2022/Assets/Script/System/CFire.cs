using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFire : MonoBehaviour
{
    public GameObject[] _gFire;              // �ŏ�����z�u���Ă�������
    public static bool[] _bIsFire = new bool[3];    // �R�₷����true�������A�ő吔��_gFire�Ɠ����ɂ��邱��

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < 3; index++)
        {
            _bIsFire[index] = false;
            _gFire[index].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < 3; index++)
        {
            if (_bIsFire[index])
            {
                if (!_gFire[index].activeSelf)
                {
                    _gFire[index].SetActive(true);
                }
            }
        }
    }

    // �΂�����Ƃ��Ɏg���A�z��Ɠ����Ȃ̂�0����ԍ��[�̃C���[�W�ŁB
    public static void SetFire(int index)
    {
        _bIsFire[index] = true;
    }
}
