using UnityEngine;


public class CPutSpace : MonoBehaviour
{
    [SerializeField] private Transform[] _tPutSpaces = null;

    private CPickedUpObject[] _cPickedUpObjectSpaces;
    // private CPickedUpObject _cPutObject; // �u���ꂽ�I�u�W�F�N�g
    

    void Start()
    {
        _cPickedUpObjectSpaces = new CPickedUpObject[_tPutSpaces.Length];
    }

    // PlacedObject �X�y�[�X�ɃI�u�W�F�N�g��z�u����
    // �����F�u���I�u�W�F�N�g
    // �߂�l�F�u�����ꏊ�i�u���̂Ɏ��s�����ꍇnull�j
    public Transform PlacedObject(CPickedUpObject obj)
    {

        // �󂢂Ă�X�y�[�X��T��
        for(int i = 0; i < _cPickedUpObjectSpaces.Length; i++)
        {
            if(_cPickedUpObjectSpaces[i] == null)
            {
                // �󂢂Ă�X�y�[�X�ɕ���u��
                _cPickedUpObjectSpaces[i] = obj;

                if (obj.Get_isCorrect())
                {
                    // ������I�u�W�F�N�g��u�����Ƃ��̏���
                    
                }

                return _tPutSpaces[i];
            }
        }
        
        // �󂢂Ă�X�y�[�X����
        return null;
    }


    // RemoveObject �X�y�[�X�ɒu����Ă���I�u�W�F�N�g����菜��
    // �����F��菜���I�u�W�F�N�g
    public void RemoveObject(CPickedUpObject obj)
    {

        // �ǂ̃X�y�[�X�ɒu����Ă��邩
        for (int i = 0; i < _cPickedUpObjectSpaces.Length; i++)
        {
            if (_cPickedUpObjectSpaces[i] == obj)
            {
                // ������菜��
                _cPickedUpObjectSpaces[i] = null;

                if (obj.Get_isCorrect())
                {
                    // ������I�u�W�F�N�g����菜�����̏���

                }
            }
        }

    }
}
