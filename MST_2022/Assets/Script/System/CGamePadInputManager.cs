/*==============================================================================
    [CGamePadInputManager.cs]
    �E�Q�[���p�b�h�̓��͂��Ǘ�����
--------------------------------------------------------------------------------
    2021.09.13 @Fujiwara Aiko
================================================================================
    History
        2021.09.13 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/


/* -------------�g�p���@--------------------

�O��ނ�static�֐����g�������ӏ��Ŏg�p�B

�EGetButtonDown(�Q�[���p�b�h�R�[�h)
    �Q�[���p�b�h�R�[�h�̃{�^���������ꂽ�Ƃ�true�iTrigger�j
�EGetButton(�Q�[���p�b�h�R�[�h)
    �Q�[���p�b�h�R�[�h�̃{�^����������Ă����true�iPress�j 
 �Epublic static Vector2 GetStickStatus(�Q�[���p�b�h�̃X�e�B�b�N�R�[�h)
    �Q�[���p�b�h�̃X�e�B�b�N�̏�Ԃ��擾�iVector2�j

���g�p�ၖ
// �Q�[���p�b�h��R�X�e�B�b�N�������ɓ|���ꂽ��iTrigger�j
if (CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.RSTICK_LEFT))
{
    // ���炩�̏����`
}

--------------------------------------------*/


// ���̃X�N���v�g����ꂽ�Ƃ�
// ���e���̂�Unity��InputManager�Ŋe�v���p�e�B�[�Ɋ��蓖�Ă�

//  D-PAD-H     6th-Axis
//  D-PAD-V     7th-Axis
//  L-Stick-H   X-Axis
//  L-Stick-V   Y-Axis
//  R-Stick-H   4th-Axis
//  R-Stick-V   5th-Axis


using UnityEngine;

public class CGamePadInputManager : MonoBehaviour
{

    // �Q�[���p�b�h�̃{�^���R�[�h
    public enum GAME_PAD_CODE
    {
        A,              // A�{�^��
        B,              // B�{�^��
        X,              // X�{�^��
        Y,              // Y�{�^��
        LB,             // LB�{�^��
        RB,             // RB�{�^��
        LT,             // LT�{�^��
        RT,             // RT�{�^��
        BACK,           // Back�{�^��
        START,          // Start�{�^��
        SELECT,         // Select�{�^��
        OPTION,         // Option�{�^��
        VIEW,           // View�{�^��
        MENU,           // Menu�{�^��
        LSTICK_PUSH,     // LStick�������݃{�^��
        RSTICK_PUSH,     // RStick�������݃{�^��

        DPAD_LEFT,      // DPad ���{�^��
        DPAD_RIGHT,     // DPad �E�{�^��
        DPAD_UP,        // DPad ��{�^��
        DPAD_DOWN,      // DPad ���{�^��
        RSTICK_LEFT,    // RStick ���ɓ|��
        RSTICK_RIGHT,   // RStick �E�ɓ|��
        RSTICK_UP,      // RStick ��ɓ|��
        RSTICK_DOWN,    // RStick ���ɓ|��
        LSTICK_LEFT,    // LStick ���ɓ|��
        LSTICK_RIGHT,   // LStick �E�ɓ|��
        LSTICK_UP,      // LStick ��ɓ|��
        LSTICK_DOWN,    // LStick ���ɓ|��

    }

    // �Q�[���p�b�h�̃X�e�B�b�N�n�̎�ނ̃R�[�h
    public enum GAME_PAD_STICK_CODE
    {
        DPAD,      // DPad
        RSTICK,    // RStick
        LSTICK,    // LStick
    }

    private const float _fDead = 0.5f;   // 臒l


    // ����p�ϐ�

    // *Trigger*
    // D-PAD
    private bool _bDPadLeftStay     = false;
    private bool _bDPadRightStay    = false;
    private bool _bDPadUpStay       = false;
    private bool _bDPadDownStay     = false;
    // R-Stick
    private bool _bRStickLeftStay   = false;
    private bool _bRStickRightStay  = false;
    private bool _bRStickUpStay     = false;
    private bool _bRStickDownStay   = false;     
    // L-Stick
    private bool _bLStickLeftStay   = false;
    private bool _bLStickRightStay  = false;
    private bool _bLStickUpStay     = false;
    private bool _bLStickDownStay   = false;

    // *Press*
    // D-PAD
    private bool _bDPadLeftDown     = false;
    private bool _bDPadRightDown    = false;
    private bool _bDPadUpDown       = false;
    private bool _bDPadDownDown     = false;
    // R-Stick
    private bool _bRStickLeftDown   = false;
    private bool _bRStickRightDown  = false;
    private bool _bRStickUpDown     = false;
    private bool _bRStickDownDown   = false;
    // L-Stick
    private bool _bLStickLeftDown   = false;
    private bool _bLStickRightDown  = false;
    private bool _bLStickUpDown     = false;
    private bool _bLStickDownDown   = false;

    // Singleton
    private static CGamePadInputManager _instance;
    public static CGamePadInputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CGamePadInputManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("CGamePadInputManager");
                    _instance = obj.AddComponent<CGamePadInputManager>();
                }
            }
            return _instance;
        }
    }

    // ���݂̃Q�[���p�b�h�̏�Ԃ��X�V����
    void Update()
    {
        // DPAD�ƃX�e�B�b�N�̏�Ԃ��擾
        float dph = Input.GetAxis("D-PAD-H");
        float dpv = Input.GetAxis("D-PAD-V");
        float lsh = Input.GetAxis("L-Stick-H");
        float lsv = Input.GetAxis("L-Stick-V");
        float rsh = Input.GetAxis("R-Stick-H");
        float rsv = Input.GetAxis("R-Stick-V");

        // ��ԏ�����
        _bDPadLeftDown = false;
        _bDPadRightDown = false;
        _bDPadUpDown = false;
        _bDPadDownDown = false;
        _bRStickLeftDown = false;
        _bRStickRightDown = false;
        _bRStickUpDown = false;
        _bRStickDownDown = false;
        _bLStickLeftDown = false;
        _bLStickRightDown = false;
        _bLStickUpDown = false;
        _bLStickDownDown = false;


        // DPAD�̏�Ԃ��X�V
        if (dph > _fDead)   // �E
        {
            if (!_bDPadRightStay)
            {
                _bDPadRightDown = true;
            }
            _bDPadRightStay = true;
        }
        else
        {
            _bDPadRightStay = false;
        }

        if (dph < -_fDead)  // ��
        {
            if (!_bDPadLeftStay)
            {
                _bDPadLeftDown = true;
            }
            _bDPadLeftStay = true;
        }
        else
        {
            _bDPadLeftStay = false;
        }

        if (dpv > _fDead)   // ��
        {
            if (!_bDPadUpStay)
            {
                _bDPadUpDown = true;
            }
            _bDPadUpStay = true;
        }
        else
        {
            _bDPadUpStay = false;
        }

        if (dpv < -_fDead)  // ��
        {
            if (!_bDPadDownStay)
            {
                _bDPadDownDown = true;
            }
            _bDPadDownStay = true;
        }
        else
        {
            _bDPadDownStay = false;
        }
        

        // LStick�̏�Ԃ��X�V
        if (lsh > _fDead)   // �E
        {
            if (!_bLStickRightStay)
            {
                _bLStickRightDown = true;
            }
            _bLStickRightStay = true;
        }
        else
        {
            _bLStickRightStay = false;
        }

        if (lsh < -_fDead)  // ��
        {
            if (!_bLStickLeftStay)
            {
                _bLStickLeftDown = true;
            }
            _bLStickLeftStay = true;
        }
        else
        {
            _bLStickLeftStay = false;
        }

        if (lsv > _fDead)   // ��
        {
            if (!_bLStickUpStay)
            {
                _bLStickUpDown = true;
            }
            _bLStickUpStay = true;
        }
        else
        {
            _bLStickUpStay = false;
        }

        if (lsv < -_fDead)  // ��
        {
            if (!_bLStickDownStay)
            {
                _bLStickDownDown = true;
            }
            _bLStickDownStay = true;
        }
        else
        {
            _bLStickDownStay = false;
        }
        

        // RStick�̏�Ԃ��X�V
        if (rsh > _fDead)   // �E
        {
            if (!_bRStickRightStay)
            {
                _bRStickRightDown = true;
            }
            _bRStickRightStay = true;
        }
        else
        {
            _bRStickRightStay = false;
        }

        if (rsh < -_fDead)  // ��
        {
            if (!_bRStickLeftStay)
            {
                _bRStickLeftDown = true;
            }
            _bRStickLeftStay = true;
        }
        else
        {
            _bRStickLeftStay = false;
        }

        if (rsv > _fDead)   // ��
        {
            if (!_bRStickUpStay)
            {
                _bRStickUpDown = true;
            }
            _bRStickUpStay = true;
        }
        else
        {
            _bRStickUpStay = false;
        }

        if (rsv < -_fDead)  // ��
        {
            if (!_bRStickDownStay)
            {
                _bRStickDownDown = true;
            }
            _bRStickDownStay = true;
        }
        else
        {
            _bRStickDownStay = false;
        }

    }


    // Trigger �Q�[���p�b�h�̃{�^���������ꂽ���ǂ����擾�i�������u�Ԃ̂݌��m�j
    // �����F code �ǂ̃{�^����
    // �߂�l�Ftrue �����ꂽ
    public static bool GetButtonDown(GAME_PAD_CODE code)
    {
        switch (code)
        {
            case GAME_PAD_CODE.A:
                return Input.GetKeyDown("joystick button 0");

            case GAME_PAD_CODE.B:
                return Input.GetKeyDown("joystick button 1");

            case GAME_PAD_CODE.X:
                return Input.GetKeyDown("joystick button 2");

            case GAME_PAD_CODE.Y:
                return Input.GetKeyDown("joystick button 3");

            case GAME_PAD_CODE.LB:
                return Input.GetKeyDown("joystick button 4");

            case GAME_PAD_CODE.RB:
                return Input.GetKeyDown("joystick button 5");

            case GAME_PAD_CODE.BACK:
            case GAME_PAD_CODE.SELECT:
            case GAME_PAD_CODE.VIEW:
                return Input.GetKeyDown("joystick button 6");

            case GAME_PAD_CODE.START:
            case GAME_PAD_CODE.OPTION:
            case GAME_PAD_CODE.MENU:
                return Input.GetKeyDown("joystick button 7");

            case GAME_PAD_CODE.LSTICK_PUSH:
                return Input.GetKeyDown("joystick button 8");

            case GAME_PAD_CODE.RSTICK_PUSH:
                return Input.GetKeyDown("joystick button 9");

            // D-Pad
            case GAME_PAD_CODE.DPAD_LEFT:
                return Instance._bDPadLeftDown;
            case GAME_PAD_CODE.DPAD_RIGHT:
                return Instance._bDPadRightDown;
            case GAME_PAD_CODE.DPAD_UP:
                return Instance._bDPadUpDown;
            case GAME_PAD_CODE.DPAD_DOWN:
                return Instance._bDPadDownDown;

            // R-Stick
            case GAME_PAD_CODE.RSTICK_LEFT:
                return Instance._bRStickLeftDown;
            case GAME_PAD_CODE.RSTICK_RIGHT:
                return Instance._bRStickRightDown;
            case GAME_PAD_CODE.RSTICK_UP:
                return Instance._bRStickUpDown;
            case GAME_PAD_CODE.RSTICK_DOWN:
                return Instance._bRStickDownDown;
                
            // L-Stick
            case GAME_PAD_CODE.LSTICK_LEFT:
                return Instance._bLStickLeftDown;
            case GAME_PAD_CODE.LSTICK_RIGHT:
                return Instance._bLStickRightDown;
            case GAME_PAD_CODE.LSTICK_UP:
                return Instance._bLStickUpDown;
            case GAME_PAD_CODE.LSTICK_DOWN:
                return Instance._bLStickDownDown;

            default:
                return false;
        }
    }

    // Press �Q�[���p�b�h�̃{�^����������Ă邩�ǂ����擾�i�����Ă����true�j
    // �����F code �ǂ̃{�^����
    // �߂�l�Ftrue ������Ă���@false ������ĂȂ�
    public static bool GetButton(GAME_PAD_CODE code)
    {
        switch (code)
        {
            case GAME_PAD_CODE.A:
                return Input.GetKey("joystick button 0");

            case GAME_PAD_CODE.B:
                return Input.GetKey("joystick button 1");

            case GAME_PAD_CODE.X:
                return Input.GetKey("joystick button 2");

            case GAME_PAD_CODE.Y:
                return Input.GetKey("joystick button 3");

            case GAME_PAD_CODE.LB:
                return Input.GetKey("joystick button 4");

            case GAME_PAD_CODE.RB:
                return Input.GetKey("joystick button 5");

            case GAME_PAD_CODE.BACK:
            case GAME_PAD_CODE.SELECT:
            case GAME_PAD_CODE.VIEW:
                return Input.GetKey("joystick button 6");

            case GAME_PAD_CODE.START:
            case GAME_PAD_CODE.OPTION:
            case GAME_PAD_CODE.MENU:
                return Input.GetKey("joystick button 7");

            case GAME_PAD_CODE.LSTICK_PUSH:
                return Input.GetKey("joystick button 8");

            case GAME_PAD_CODE.RSTICK_PUSH:
                return Input.GetKey("joystick button 9");

            // D-Pad
            case GAME_PAD_CODE.DPAD_LEFT:
                return Instance._bDPadLeftStay;
            case GAME_PAD_CODE.DPAD_RIGHT:
                return Instance._bDPadRightStay;
            case GAME_PAD_CODE.DPAD_UP:
                return Instance._bDPadUpStay;
            case GAME_PAD_CODE.DPAD_DOWN:
                return Instance._bDPadDownStay;

            // R-Stick
            case GAME_PAD_CODE.RSTICK_LEFT:
                return Instance._bRStickLeftStay;
            case GAME_PAD_CODE.RSTICK_RIGHT:
                return Instance._bRStickRightStay;
            case GAME_PAD_CODE.RSTICK_UP:
                return Instance._bRStickUpStay;
            case GAME_PAD_CODE.RSTICK_DOWN:
                return Instance._bRStickDownStay;
                
            // L-Stick
            case GAME_PAD_CODE.LSTICK_LEFT:
                return Instance._bLStickLeftStay;
            case GAME_PAD_CODE.LSTICK_RIGHT:
                return Instance._bLStickRightStay;
            case GAME_PAD_CODE.LSTICK_UP:
                return Instance._bLStickUpStay;
            case GAME_PAD_CODE.LSTICK_DOWN:
                return Instance._bLStickDownStay;

            default:
                return false;
        }
    }

    // ���݂̃X�e�B�b�N�̏�Ԃ��擾
    // �����F code �ǂ̃X�e�B�b�N��
    // �߂�l�F �|���Ă������
    public static Vector2 GetStickStatus(GAME_PAD_STICK_CODE code)
    {
        switch (code)
        {
            // D-Pad
            case GAME_PAD_STICK_CODE.DPAD:
                return new Vector2(Input.GetAxis("D-PAD-H"), Input.GetAxis("D-PAD-V"));

            case GAME_PAD_STICK_CODE.RSTICK:
                return new Vector2(Input.GetAxis("L-Stick-H"), Input.GetAxis("L-Stick-V"));

            // L-Stick
            case GAME_PAD_STICK_CODE.LSTICK:
                return new Vector2(Input.GetAxis("R-Stick-H"), Input.GetAxis("R-Stick-V"));

            default:
                return Vector2.zero;
        }
    }

}
