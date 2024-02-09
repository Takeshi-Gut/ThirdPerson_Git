using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]

        /// <summary>
        /// �ړ��l
        /// </summary>
        public Vector2 move; //Vector2�^��move�ϐ��錾�Bmove��XY�l

        /// <summary>
        /// �����Ă������
        /// </summary>
        public Vector2 look; //Vector2�^��look�ϐ��錾�Blook��XY�l

        /// <summary>
        /// �W�����v���Ă��邩�̃t���O
        /// </summary>
        public bool jump;

        /// <summary>
        ///  //�����Ă��邩�̃t���O
        /// </summary>
        public bool sprint;

        /// <summary>
        /// Fire�̃t���O�i�U�����Ă��邩�j
        /// </summary>
        public bool fire;

        /// <summary>
        /// Crouch�̃t���O�i���Ⴊ��ł��邩�j
        /// </summary>
        public bool crouch;


        [Header("Movement Settings")]//�ړ��ɂ��Ă̐ݒ�

        /// <summary>
        /// �A�i���O�X�e�B�b�N���g�p���Ă��邩�̃t���O
        /// </summary>
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]//�J�[�\���ɂ��Ă̐ݒ�

        /// <summary>
        /// �J�[�\�������b�N����Ă��邩�B==�Đ�������J�[�\���������Ȃ��Ȃ��ԁB
        /// </summary>
        public bool cursorLocked = true;

        /// <summary>
        /// �J�[�\�������������ƂȂ��Ă��邩�̃t���O
        /// </summary>
        public bool cursorInputForLook = true; //


        /// <summary>
        /// ThirdPersonController���Q�Ƃ���
        /// </summary>
        private ThirdPersonController thirdPersonController
            => GetComponent<ThirdPersonController>();


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        /// <summary>
        /// ������InputValue��ǂݎ����
        /// MoveInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>

        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        /// <summary>
        /// ������InputValue��ǂݎ����
        /// �J�[�\�����͂��J�����̌��������̏ꍇ��
        /// LookInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>
        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        /// <summary>
        /// ������InputValue��ǂݎ����
        /// JumpInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>
        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }


        /// <summary>
        /// ������InputValue��ǂݎ����
        /// FireInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>
        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        /// <summary>
        /// ������InputValue��ǂݎ����
        /// FireInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>
        public void OnFire(InputValue value)
        {
            FireInput(value.isPressed);
        }

        /// <summary>
        /// ������InputCrouch��ǂݎ����
        /// CrouchInput�ɒl��n��
        /// </summary>
        /// <param name="value"></param>
        public void OnCrouch(InputValue value)
        {
            CrouchInput(value.isPressed);
        }


#endif

        /// <summary>
        /// ������vector2(���A��)��move�ɑ������
        /// </summary>
        /// <param name="newMoveDirection"></param>
        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        /// <summary>
        /// ������vector2(���A��)��look�ɑ������
        /// </summary>
        /// <param name="newLookDirection"></param>
        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        /// <summary>
        /// ������newJumpState�̔����jump�ɑ������
        /// </summary>
        /// <param name="newJumpState"></param>
        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        /// <summary>
        /// ������newSprintState�̔����sprint�ɑ������
        /// </summary>
        /// <param name="newSprintState"></param>
        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        /// <summary>
        /// ������newFireState�̔����fire�ɑ������
        /// </summary>
        /// <param name="newFireState"></param>
        public void FireInput(bool newFireState)
        {
            // thirdPersonController�ōĐ����̃A�j���[�V������Fire��������
            // �t���O��܂�
            if (thirdPersonController.IsPlayingAnimation("Fire"))
            {
                fire = false;
                Debug.Log("�t���O�܂��Ă�");
                return;
            }
            fire = newFireState;
        }

        /// <summary>
        /// ������newCrouchState�̔����Crouch�ɑ������
        /// </summary>
        /// <param name="newCrouchState"></param>
        public void CrouchInput(bool newCrouchState)
        {
            crouch = newCrouchState;
        }



        /// <summary>
        /// �A�v���P�[�V���������s����Ă���ꍇ
        /// </summary>
        /// <param name="hasFocus"></param>
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        /// <summary>
        /// �J�[�\���̏�Ԃ�ݒ肷��
        /// </summary>
        /// <param name="newState"></param>
        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}