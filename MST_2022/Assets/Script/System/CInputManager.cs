/*==============================================================================
    [CInputManager.cs]
    �E�e�f�o�C�X����̓��͂𓝈ꉻ������
--------------------------------------------------------------------------------
    2021.10.11 @Fujiwara Aiko
================================================================================
    History
        2021.10.11 Fujiwara Aiko
            �X�N���v�g�ǉ�
            
/*============================================================================*/

/* -------------�g�p���@--------------------

�O��ނ�static�֐����g�������ӏ��Ŏg�p�B

�EGetButtonDown(INPUT_CODE)
    �Ώۂ̃{�^���������ꂽ�Ƃ�true�iTrigger�j
�EGetButton(INPUT_CODE)
    �Ώۂ̃{�^����������Ă����true�iPress�j 

���g�p�ၖ
// ����{�^���������ꂽ��iTrigger�j
if (CInputManager.GetButtonDown(INPUT_CODE.SELECT))
{
    // ���炩�̏����`
}

--------------------------------------------*/


using UnityEngine;


/*
������INPUT_CODE�ɂ��ā�����

���GamePad��̈ȉ��̃L�[�����蓖�Ă�C���[�W�Ŗ������Ă��܂��B

    SELECT  :   A�{�^��
    CANCEL  :   B�{�^��
    X       :   X�{�^��
    Y       :   Y�{�^��

    PAUSE   :   ���j���[�{�^��

    L�X�e�B�b�N OR �\���L�[����
    LEFT
    RIGHT
    UP
    DOWN
*/

public enum INPUT_CODE
{
    SELECT,    // ����
    CANCEL,    // �L�����Z��
    X,         // X�{�^��
    Y,         // Y�{�^��

    PAUSE,     // �|�[�Y
    
    LEFT,      // ������
    RIGHT,     // �E����
    UP,        // �����
    DOWN,      // ������
}

public class CInputManager
{

    // Trigger
    public static bool GetButtonDown(INPUT_CODE code)
    {
        switch (code)
        {
            case INPUT_CODE.SELECT:
                return Input.GetKeyDown(KeyCode.E) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.A);

            case INPUT_CODE.CANCEL:
                return Input.GetKeyDown(KeyCode.Q) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.B);

            case INPUT_CODE.X:
                return Input.GetKeyDown(KeyCode.Tab) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.X);

            case INPUT_CODE.Y:
                return Input.GetKeyDown(KeyCode.F) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.Y);


            case INPUT_CODE.PAUSE:
                return Input.GetKeyDown(KeyCode.Escape) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.MENU);


            case INPUT_CODE.LEFT:
                return Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.A) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.DPAD_LEFT) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.LSTICK_LEFT);

            case INPUT_CODE.RIGHT:
                return Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.D) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.DPAD_RIGHT) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.LSTICK_RIGHT);

            case INPUT_CODE.UP:
                return Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.W) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.DPAD_UP) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.LSTICK_UP);

            case INPUT_CODE.DOWN:
                return Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.S) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.DPAD_DOWN) ||
                    CGamePadInputManager.GetButtonDown(CGamePadInputManager.GAME_PAD_CODE.LSTICK_DOWN);

            default:
                return false;
        }
    }

    // Release
    public static bool GetButtonUp(INPUT_CODE code)
    {
        switch (code)
        {
            case INPUT_CODE.SELECT:
                return Input.GetKeyUp(KeyCode.E) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.A);

            case INPUT_CODE.CANCEL:
                return Input.GetKeyUp(KeyCode.Q) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.B);

            case INPUT_CODE.X:
                return Input.GetKeyUp(KeyCode.Tab) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.X);

            case INPUT_CODE.Y:
                return Input.GetKeyUp(KeyCode.F) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.Y);


            case INPUT_CODE.PAUSE:
                return Input.GetKeyUp(KeyCode.Escape) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.MENU);


            case INPUT_CODE.LEFT:
                return Input.GetKeyUp(KeyCode.LeftArrow) ||
                    Input.GetKeyUp(KeyCode.A) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_LEFT) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_LEFT);

            case INPUT_CODE.RIGHT:
                return Input.GetKeyUp(KeyCode.RightArrow) ||
                    Input.GetKeyUp(KeyCode.D) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_RIGHT) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_RIGHT);

            case INPUT_CODE.UP:
                return Input.GetKeyUp(KeyCode.UpArrow) ||
                    Input.GetKeyUp(KeyCode.W) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_UP) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_UP);

            case INPUT_CODE.DOWN:
                return Input.GetKeyUp(KeyCode.DownArrow) ||
                    Input.GetKeyUp(KeyCode.S) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_DOWN) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_DOWN);

            default:
                return false;
        }
    }

    // Press
    public static bool GetButton(INPUT_CODE code)
    {
        switch (code)
        {
            case INPUT_CODE.SELECT:
                return Input.GetKey(KeyCode.E) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.A);

            case INPUT_CODE.CANCEL:
                return Input.GetKey(KeyCode.Q) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.B);

            case INPUT_CODE.X:
                return Input.GetKey(KeyCode.Tab) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.X);

            case INPUT_CODE.Y:
                return Input.GetKey(KeyCode.F) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.Y);


            case INPUT_CODE.PAUSE:
                return Input.GetKey(KeyCode.Escape) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.MENU);


            case INPUT_CODE.LEFT:
                return Input.GetKey(KeyCode.LeftArrow) ||
                    Input.GetKey(KeyCode.A) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_LEFT) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_LEFT);

            case INPUT_CODE.RIGHT:
                return Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetKey(KeyCode.D) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_RIGHT) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_RIGHT);

            case INPUT_CODE.UP:
                return Input.GetKey(KeyCode.UpArrow) ||
                    Input.GetKey(KeyCode.W) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_UP) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_UP);

            case INPUT_CODE.DOWN:
                return Input.GetKey(KeyCode.DownArrow) ||
                    Input.GetKey(KeyCode.S) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.DPAD_DOWN) ||
                    CGamePadInputManager.GetButton(CGamePadInputManager.GAME_PAD_CODE.LSTICK_DOWN);
                
            default:
                return false;
        }
    }

}