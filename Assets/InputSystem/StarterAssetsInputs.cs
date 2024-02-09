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
        /// 移動値
        /// </summary>
        public Vector2 move; //Vector2型でmove変数宣言。moveのXY値

        /// <summary>
        /// 向いている方向
        /// </summary>
        public Vector2 look; //Vector2型でlook変数宣言。lookのXY値

        /// <summary>
        /// ジャンプしているかのフラグ
        /// </summary>
        public bool jump;

        /// <summary>
        ///  //走っているかのフラグ
        /// </summary>
        public bool sprint;

        /// <summary>
        /// Fireのフラグ（攻撃しているか）
        /// </summary>
        public bool fire;

        /// <summary>
        /// Crouchのフラグ（しゃがんでいるか）
        /// </summary>
        public bool crouch;


        [Header("Movement Settings")]//移動についての設定

        /// <summary>
        /// アナログスティックを使用しているかのフラグ
        /// </summary>
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]//カーソルについての設定

        /// <summary>
        /// カーソルがロックされているか。==再生したらカーソルが見えなくなる状態。
        /// </summary>
        public bool cursorLocked = true;

        /// <summary>
        /// カーソルが向く方向となっているかのフラグ
        /// </summary>
        public bool cursorInputForLook = true; //


        /// <summary>
        /// ThirdPersonControllerを参照する
        /// </summary>
        private ThirdPersonController thirdPersonController
            => GetComponent<ThirdPersonController>();


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        /// <summary>
        /// 引数のInputValueを読み取って
        /// MoveInputに値を渡す
        /// </summary>
        /// <param name="value"></param>

        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        /// <summary>
        /// 引数のInputValueを読み取って
        /// カーソル入力がカメラの向く方向の場合は
        /// LookInputに値を渡す
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
        /// 引数のInputValueを読み取って
        /// JumpInputに値を渡す
        /// </summary>
        /// <param name="value"></param>
        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }


        /// <summary>
        /// 引数のInputValueを読み取って
        /// FireInputに値を渡す
        /// </summary>
        /// <param name="value"></param>
        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        /// <summary>
        /// 引数のInputValueを読み取って
        /// FireInputに値を渡す
        /// </summary>
        /// <param name="value"></param>
        public void OnFire(InputValue value)
        {
            FireInput(value.isPressed);
        }

        /// <summary>
        /// 引数のInputCrouchを読み取って
        /// CrouchInputに値を渡す
        /// </summary>
        /// <param name="value"></param>
        public void OnCrouch(InputValue value)
        {
            CrouchInput(value.isPressed);
        }


#endif

        /// <summary>
        /// 引数のvector2(ｘ、ｙ)をmoveに代入する
        /// </summary>
        /// <param name="newMoveDirection"></param>
        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        /// <summary>
        /// 引数のvector2(ｘ、ｙ)をlookに代入する
        /// </summary>
        /// <param name="newLookDirection"></param>
        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        /// <summary>
        /// 引数のnewJumpStateの判定をjumpに代入する
        /// </summary>
        /// <param name="newJumpState"></param>
        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        /// <summary>
        /// 引数のnewSprintStateの判定をsprintに代入する
        /// </summary>
        /// <param name="newSprintState"></param>
        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        /// <summary>
        /// 引数のnewFireStateの判定をfireに代入する
        /// </summary>
        /// <param name="newFireState"></param>
        public void FireInput(bool newFireState)
        {
            // thirdPersonControllerで再生中のアニメーションがFireだったら
            // フラグを折る
            if (thirdPersonController.IsPlayingAnimation("Fire"))
            {
                fire = false;
                Debug.Log("フラグ折られてる");
                return;
            }
            fire = newFireState;
        }

        /// <summary>
        /// 引数のnewCrouchStateの判定をCrouchに代入する
        /// </summary>
        /// <param name="newCrouchState"></param>
        public void CrouchInput(bool newCrouchState)
        {
            crouch = newCrouchState;
        }



        /// <summary>
        /// アプリケーションが実行されている場合
        /// </summary>
        /// <param name="hasFocus"></param>
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        /// <summary>
        /// カーソルの状態を設定する
        /// </summary>
        /// <param name="newState"></param>
        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}