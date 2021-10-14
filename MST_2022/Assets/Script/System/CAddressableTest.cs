/*==============================================================================
    [CAddressableTest.cs]
    �EAddressable��EZAddresser�̃e�X�g�p�X�N���v�g
    ��ŏ���
--------------------------------------------------------------------------------
    2021.10.12 @Fujiwara Aiko
================================================================================
    History
        2021.10.12 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/

using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CAddressableTest : MonoBehaviour
{

    private AsyncOperationHandle<GameObject> _handle;
    private GameObject _prefab;     // ���[�h���ꂽ�v���n�u
    

    void Start()
    {
        // �A�Z�b�g�ǂݍ���
        StartCoroutine(Load());
    }
    

    void Update()
    {
        // Q�L�[�Ő���
        if (CInputManager.GetButtonDown(INPUT_CODE.CANCEL))
        {
            if (_prefab != null)
            {
                Instantiate(_prefab, transform);
            }
        }
    }

    // �A�Z�b�g�����[�h����
    private IEnumerator Load()
    {
        var _handle = Addressables.LoadAssetAsync<GameObject>("SphereObj");
        yield return _handle;
        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            _prefab = _handle.Result;
        }
    }

}
