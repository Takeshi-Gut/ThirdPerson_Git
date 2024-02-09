using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

/* Note:アニメーションは、アニメーターのnullチェックを使用して、
 * キャラクターとカプセルの両方のコントローラー経由で呼び出されます
 */

namespace StarterAssets
{
    /// <summary>
    /// RequireComponentは自動的にコンポーネントを追加する属性
    /// このThirdPersonControllerを使うにあたってCharacterControllerとPlayerInputは
    /// ThirdPersonControllerをAddされた瞬間に追加される
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("キャラクターの移動速度（m/s）")]
        public float MoveSpeed = 2.0f;

        [Tooltip("キャラクターのスプリント速度（m/s）")]
        public float SprintSpeed = 5.335f;

        [Tooltip("キャラクターが顔の移動方向に向く速度")]
        [Range(0.0f, 0.3f)]
        public float RotationSmoothTime = 0.12f;

        [Tooltip("加速と減速")]
        public float SpeedChangeRate = 10.0f;

        /// <summary>
        /// 着地時の音源
        /// </summary>
        public AudioClip LandingAudioClip;

        /// <summary>
        /// 歩いた時の音源
        /// </summary>
        public AudioClip[] FootstepAudioClips;

        /// <summary>
        /// 歩いた時の音源のボリューム
        /// </summary>
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

        [Space(10)]
        [Tooltip("プレイヤーがジャンプできる高さ")]
        public float JumpHeight = 1.2f;

        [Tooltip("キャラクターは独自の重力値を使用します。エンジンのデフォルトは -9.81fです")]
        public float Gravity = -15.0f;

        [Space(10)]
        [Tooltip("再度ジャンプできるまでの時間。0fに設定するとすぐに再度ジャンプできます")]
        public float JumpTimeout = 0.50f;

        [Tooltip("フォール状態に入るまでの経過時間。階段を下りるときに便利です")]
        public float FallTimeout = 0.15f;

        [Header("Player Grounded")]
        [Tooltip("キャラクターが接地しているかどうか。CharacterControllerの組み込み接地チェックの一部ではありません")]
        public bool Grounded = true;

        [Tooltip("荒れた地面に便利。凹の箇所")]
        public float GroundedOffset = -0.14f;

        [Tooltip("接地チェックの半径。CharacterControllerの半径と一致する必要があります")]
        public float GroundedRadius = 0.28f;

        [Tooltip("キャラクターがグラウンドとして使用するレイヤー")]
        public LayerMask GroundLayers;

        [Header("Cinemachine")]
        [Tooltip("Cinemachine Virtual Cameraで設定されたカメラが追従するフォローターゲット")]
        public GameObject CinemachineCameraTarget;

        [Tooltip("カメラを上にどれくらい動かすことができるかの閾値（しきいち、いきち）")]
        public float TopClamp = 70.0f;

        [Tooltip("カメラを下にどれくらい動かすことができるかの閾値")]
        public float BottomClamp = -30.0f;

        [Tooltip("カメラをオーバーライドするための追加のデグレス（角度）。ロック時にカメラの位置を微調整するのに役立ちます")]
        public float CameraAngleOverride = 0.0f;

        [Tooltip("全軸のカメラ位置をロックするか")]
        public bool LockCameraPosition = false;

        // cinemachine
        /// <summary>
        /// カメラのY軸に対しての回転値
        /// </summary>
        private float _cinemachineTargetYaw;

        /// <summary>
        /// カメラのX軸に対しての回転値
        /// </summary>
        private float _cinemachineTargetPitch;

        // player
        /// <summary>
        /// 最終的なプレイヤーの移動スピード
        /// </summary>
        private float _speed;

        /// <summary>
        /// 最終的なアニメーションのブレンド値
        /// </summary>
        private float _animationBlend;

        /// <summary>
        /// 最終的なプレイヤーの回転値
        /// </summary>
        private float _targetRotation = 0.0f;

        /// <summary>
        /// 最終的なプレイヤーの回転加速度
        /// </summary>
        private float _rotationVelocity;

        /// <summary>
        /// 希望の高さに到達するために必要な速度
        /// </summary>
        private float _verticalVelocity;

        /// <summary>
        /// ターミナルの下にある場合の重力加速度
        /// </summary>
        private float _terminalVelocity = 53.0f;

        // timeout deltatime
        /// <summary>
        /// 再度ジャンプできるようになるまでの時間
        /// </summary>
        private float _jumpTimeoutDelta;

        /// <summary>
        /// フォール状態に入るまでの経過時間
        /// </summary>
        private float _fallTimeoutDelta;

        // animation IDs
        /// <summary>
        /// ここはアニメーションに割り振られているIDを取得して適用している
        /// </summary>
        private int _animIDSpeed;
        private int _animIDGrounded;
        private int _animIDJump;
        private int _animIDFreeFall;
        private int _animIDMotionSpeed;
        // Fire用のIDを設定する
        private int _animIDFire;
        // Crouch用のIDを設定する
        private int _animIDCrouch;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

        /// <summary>
        /// InputManagerではなく、InputSystemを使う場合に使用するコンポーネント
        /// </summary>
        private PlayerInput _playerInput;
#endif
        /// <summary>
        /// Animationを制御するアニメーター
        /// </summary>
        private Animator _animator;

        /// <summary>
        /// 物理演算を利用しない移動などのコンポーネント
        /// </summary>
        private CharacterController _controller;

        /// <summary>
        /// 入力をつかさコンポーネントどる
        /// </summary>
        private StarterAssetsInputs _input;

        /// <summary>
        /// カメラのGameObject
        /// </summary>
        private GameObject _mainCamera;

        /// <summary>
        /// カメラを回転させる時の入力の閾値
        /// </summary>
        private const float _threshold = 0.01f;

        /// <summary>
        /// アニメーターを持っているかどうかのフラグ
        /// </summary>
        private bool _hasAnimator;

        /// <summary>
        /// マウスを使って操作しているかどうか
        /// </summary>
        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
                //キーボードとマウスを使って操作している場合はtrueが返る
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }

        /// <summary>
        /// ThirdPersonControllerが引数の名前のアニメーションを再生中かを返す
        /// </summary>
        /// <param name="animName"></param>
        /// <returns></returns>
        public bool IsPlayingAnimation(string animName)
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(animName);
        }

        /// <summary>
        /// Unityのイベントの一番最初に一度だけ実行されます
        /// </summary>
        private void Awake()
        {
            // メインカメラをシーン上から取得してきます
            if (_mainCamera == null)
            {
                _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }

        private void Start()
        {
            //カメラのY軸の回転をPlayerArmatureの階層下にあるPlayerCameraRootに合わせる
            _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

            //_animatorが設定されているかを取得し、bool値で保存する
            _hasAnimator = TryGetComponent(out _animator);

            //CharacterControllerを取得し、_controllerに代入する
            _controller = GetComponent<CharacterController>();

            //StarterAssetsInputsを取得し、_inputに代入する
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

            //PlayerInputを取得し、_playerInputに代入する
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
            //AssignAnimationIDsを実行する
            AssignAnimationIDs();

            // _jumpTimeoutDeltaをUnity上で設定されたJumpTimeoutの値に初期化します
            _jumpTimeoutDelta = JumpTimeout;

            // _fallTimeoutDeltaをUnity上で設定されたFallTimeoutの値に初期化します
            _fallTimeoutDelta = FallTimeout;
        }

        //毎フレーム実行されます
        private void Update()
        {
            // Animatorを持っているかどうかをチェックし続けます
            _hasAnimator = TryGetComponent(out _animator);

            // しゃがむかどうか
            Crouch();


            //攻撃をしているか
            Fire();

            // ジャンプに必要な値の準備や、降下中に必要な値の準備をする
            JumpAndGravity();

            // プレイヤーが接地しているかをチェックする
            GroundedCheck();

            // 実際に移動する
            Move();
        }

        //Updateの後に、毎フレーム実行されます
        private void LateUpdate()
        {
            // カメラの回転を実行します
            CameraRotation();
        }

        /// <summary>
        /// AnimationのパラメーターをAnimatorから読み取りIDとして保存する
        /// </summary>
        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDGrounded = Animator.StringToHash("Grounded");
            _animIDJump = Animator.StringToHash("Jump");
            _animIDFreeFall = Animator.StringToHash("FreeFall");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");

            _animIDFire = Animator.StringToHash("Fire");

            _animIDCrouch = Animator.StringToHash("Crouch");
        }

        private void Fire()
        {
            //着地していない場合は行わない
            if (!Grounded)
            {
                return;
            }
            //_inputのfireが有効になっている場合
            if (_input.fire)
            {
                //Animatorをもっていれば、
                if (_hasAnimator)
                {
                    _animator.SetTrigger(_animIDFire);
                }
            }
        }


        private void Crouch()
        {
            //着地していない場合は行わない
            if (!Grounded)
            {
                return;
            }


            //Animatorをもっていれば、
            if (_hasAnimator)
            {
                // AnimatorのCrouchにInputのCrouchの状態をセットする
                _animator.SetBool(_animIDCrouch, _input.crouch);
            }

        }


        /// <summary>
        /// 接地しているかのチェック
        /// </summary>
        private void GroundedCheck()
        {
            // 生成する球状の当たり判定を発生させる位置を設定する
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);

            // spherePositionに球状の当たり判定を発生させ、地面として設定されたレイヤーと当たっているかをチェックする
            Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
                QueryTriggerInteraction.Ignore);

            // Animatorを持っている場合
            if (_hasAnimator)
            {
                // 接地中のアニメーションのフラグをOnにしたりOffにしたりする
                _animator.SetBool(_animIDGrounded, Grounded);
            }
        }

        /// <summary>
        /// カメラを回転させる
        /// </summary>
        private void CameraRotation()
        {
            // 入力があり、カメラの位置が固定されていない場合
            if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                // マウス入力だった場合はTime.deltaTimeを掛けず、1.0fをそのまま使う。三項演算子
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                // カメラのY軸の回転にインプットが向いている方向のXを加算する
                _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;

                // カメラのX軸の回転にインプットが向いている方向のYを加算する
                _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
            }

            // 回転をクランプ（制限、固定）して、カメラのY軸の値を３６０度に制限します
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);

            // 回転をクランプ（制限、固定）して、カメラのX軸の値を指定した値に制限します
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // PlayerArmatureの階層下にあるPlayerCameraRootの回転を、今回の計算結果の回転に変更します
            // カメラはPlayerCameraRootの回転と同期するので、カメラが回転してマウスと同じ方向を向く
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            //もし再生中のアニメーションの名前がFireだったら
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
            {
                //帰る（ここから下の移動の処理を行わない）
                return;
            }

            //もし再生中のアニメーションの名前がCrouchだったら
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch"))
            {
                //帰る（ここから下の移動の処理を行わない）
                return;
            }


            // 移動速度、スプリント速度、およびスプリントが押されたかどうかに基づいて目標速度を設定します
            float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

            // 簡単に削除、交換、または反復できるように設計された単純化された加速と減速

            // note: Vector2の == 演算子は近似を使用するため、浮動小数点エラーが発生しにくく、大きさよりもコストがかかりません
            // 入力が無い場合は、目標速度を0に設定します
            if (_input.move == Vector2.zero) targetSpeed = 0.0f;

            // プレイヤーの現在の水平方向の速度を取得する
            float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

            // スピードの計算の時に使う差分を設定
            float speedOffset = 0.1f;

            // アナログスティックを使う場合はアナログスティックの値を、そうじゃない場合は1を代入する
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // 目標速度まで加速、または減速する
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // 直線的な結果ではなく曲線的な結果を作成し、より有機的な速度変化を与えます
                // Lerpはクランプされているので、速度をクランプする必要がないことに注意してください。
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * SpeedChangeRate);

                // トップスピードになるまではこの_speedを使用する
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                // スピードは目標速度なのでtargetSpeedを維持する
                _speed = targetSpeed;
            }

            // アニメーションの閾値は目標速度に対してのSpeedChangeRateをTime.DeltaTimeで掛けた値
            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);

            // アニメーションのブレンドの閾値がほぼ0と変わらなければ0で代入する
            if (_animationBlend < 0.01f) _animationBlend = 0f;

            // 0～1の値で入力方向を正規化する
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            // note:移動入力がある場合、プレーヤーが移動しているときにプレーヤーを回転させます
            if (_input.move != Vector2.zero)
            {
                // 目標とすべき回転は二点間からなる角度をラジアンで返します。
                // そのラジアン（弧度法）の角度から度（度数法）に変換して、カメラの角度を足す
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;

                // 目標とする角度に向けて徐々に時間をかけて角度を変更します。度単位で指定します。
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // カメラ位置を基準にして入力方向を向くように回転します
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

            // 向くべき方向
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            // プレイヤーを移動させる
            _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

            // Animatorを持っていれば、
            if (_hasAnimator)
            {
                // _animationBlendの値をAnimatorのスピードのパラメーターに代入
                _animator.SetFloat(_animIDSpeed, _animationBlend);

                // アナログスティックを使う場合はアナログスティックの値を、そうじゃない場合は1を代入する
                _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
            }
        }

        /// <summary>
        /// ジャンプと落ちる力の設定
        /// </summary>
        private void JumpAndGravity()
        {
            // もし接地している場合は
            if (Grounded)
            {
                // _fallTimeoutDeltaをUnityで設定されたFallTimeoutでリセットする
                _fallTimeoutDelta = FallTimeout;

                // Animatorがあった場合はJumpとFallに対してfalseを代入する
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, false);
                    _animator.SetBool(_animIDFreeFall, false);
                }

                // 接地時に垂直方向の速度が無限に低下するのを阻止する
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // ジャンプを設定する
                if (_input.jump && _jumpTimeoutDelta <= 0.0f)
                {
                    // 希望の高さに到達するために必要な速度をJumpHeightの平方根 * -2 * Gravityで求める
                    _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

                    // アニメーターがあればジャンプのフラグを立てる
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDJump, true);
                    }
                }

                // ジャンプのタイムアウトを設定する
                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else // 接地していない場合
            {
                // _jumpTimeoutDeltaをUnityで設定されたJumpTimeoutでリセットする
                _jumpTimeoutDelta = JumpTimeout;

                // 落下のタイムアウトを設定する
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
                else
                {
                    // アニメーターがあれば落下中のフラグを立てる
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDFreeFall, true);
                    }
                }

                // 接地していない場合は、ジャンプしないようにして二段ジャンプの阻止をする
                _input.jump = false;
            }

            // ターミナルの下にある場合は、時間の経過とともに重力を適用します
            // （時間の経過とともに直線的に速度を上げるには、デルタ時間を２回乗算します）
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * Time.deltaTime;
            }
        }

        /// <summary>
        /// 角度を制限します
        /// </summary>
        /// <param name="lfAngle">対象となる角度</param>
        /// <param name="lfMin">制限したい最小角度</param>
        /// <param name="lfMax">制限したい最大角度</param>
        /// <returns></returns>
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            // 360度以内に制限をする
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;

            // クランプで360度以内に収まったアングルを最小値と最大値の間に収める
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        private void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (Grounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
                GroundedRadius);
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
                }
            }
        }

        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
    }
}