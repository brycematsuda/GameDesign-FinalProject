﻿//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

// 必要なコンポーネントの列記
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class UnityChan2D : MonoBehaviour
{

	public float animSpeed = 1.5f;				// アニメーション再生速度設定
	public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
	public bool useCurves = true;				// Mecanimでカーブ調整を使うか設定する
	// このスイッチが入っていないとカーブは使われない
	public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

	// 以下キャラクターコントローラ用パラメタ
	// 前進速度
	public float forwardSpeed = 7.0f;
	// 後退速度
	public float backwardSpeed = 2.0f;
	// 旋回速度
	public float rotateSpeed = 2.0f;
	// ジャンプ威力
	public float jumpPower = 3.0f; 
	// キャラクターコントローラ（カプセルコライダ）の参照
	private CapsuleCollider col;
	private Rigidbody rb;
	// キャラクターコントローラ（カプセルコライダ）の移動量
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;

	private Animator anim;							// キャラにアタッチされるアニメーターへの参照
	private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照

	private GameObject cameraObject;	// メインカメラへの参照

	// アニメーター各ステートへの参照
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int restState = Animator.StringToHash("Base Layer.Rest");

	private float origSpeed;

	public bool controlsEnabled = true;
	private float origZ;
	private float origX;

	public string flavor = "None";
	private int direction = 0;
	private const int forward = 0, backward = 1, up = 2, down = 3;

	// 初期化
	void Start ()
	{
		// Animatorコンポーネントを取得する
		anim = GetComponent<Animator>();
		// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		//メインカメラを取得する
		cameraObject = GameObject.FindWithTag("MainCamera");
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		orgColHight = col.height;
		orgVectColCenter = col.center;
		origSpeed = forwardSpeed;
	}

	void Update(){
		if (controlsEnabled) {
			if (Input.GetKeyDown (KeyCode.E)) {
				anim.SetBool ("ActivateSwitch", true);
			}
			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).
			nameHash == Animator.StringToHash ("Base Layer.ActivateSwitch")) {
				anim.SetBool ("ActivateSwitch", false);
			}
		}
	}


	// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
	void FixedUpdate ()
	{
		if (controlsEnabled) {
			
			float h = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
			float v = Input.GetAxis ("Vertical");	
			// 入力デバイスの垂直軸をvで定義
			anim.SetFloat ("Speed", Mathf.Abs (h));							// Animator側で設定している"Speed"パラメタにvを渡す
			if (h == 0) {
				anim.SetFloat ("Speed", Mathf.Abs (v));
			}
			anim.SetFloat ("Direction", h); 						// Animator側で設定している"Direction"パラメタにhを渡す
			anim.speed = animSpeed;								// Animatorのモーション再生速度に animSpeedを設定する
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する
			rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする


			// 以下、キャラクターの移動処理
			velocity = new Vector3 (0, 0, 0);		// 上下のキー入力からZ軸方向の移動量を取得
			// キャラクターのローカル空間での方向に変換
			//velocity = transform.TransformDirection(velocity);
			//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
			if (v > 0.1) {
				velocity *= forwardSpeed;		// 移動速度を掛ける
			} else if (v < -0.1) {
				velocity *= backwardSpeed;	// 移動速度を掛ける
			}

			/**
		if (Input.GetButtonDown("Jump")) {	// スペースキーを入力したら
			//アニメーションのステートがLocomotionの最中のみジャンプできる
			if (currentBaseState.nameHash == locoState){
				//ステート遷移中でなかったらジャンプできる
				if(!anim.IsInTransition(0))
				{
					rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
					anim.SetBool("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
				}
			}
		}
		*/
			if (Input.GetKeyDown (KeyCode.E)) {
				anim.SetBool ("ActivateSwitch", true);
			}
			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).
			nameHash == Animator.StringToHash ("Base Layer.ActivateSwitch")) {
				anim.SetBool ("ActivateSwitch", false);
			}


			// 上下のキー入力でキャラクターを移動させる
			//transform.localPosition += velocity * Time.fixedDeltaTime;

			// 左右のキー入力でキャラクタをY軸で旋回させる
			//transform.Rotate(0, h * rotateSpeed, 0);
			//8 directional movement edit
			if (Input.GetKey (KeyCode.A)) {
				velocity += new Vector3 (0, 0, forwardSpeed);
				transform.rotation = Quaternion.Euler (0, 180, 0);
				direction = backward;
			} else if (Input.GetKey (KeyCode.D)) {
				velocity += new Vector3 (0, 0, forwardSpeed);
				//animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				transform.rotation = Quaternion.Euler (0, 0, 0);
				direction = forward;
			} else if (Input.GetKey (KeyCode.W)) {
				//animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				velocity += new Vector3 (0, 0, forwardSpeed * 2);
				transform.rotation = Quaternion.Euler (0, 270, 0);
				direction = up;
			} else if (Input.GetKey (KeyCode.S)) {
				//animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				velocity += new Vector3 (0, 0, forwardSpeed * 2);
				transform.rotation = Quaternion.Euler (0, 90, 0);
				direction = down;
			} 
			//allow movement using side keys, rather than having to wait for slow rotation
			if (Input.GetKey (KeyCode.D)) {
				velocity *= forwardSpeed;
				Vector3 velocity2 = new Vector3 (0, 0, forwardSpeed);
				transform.localPosition += velocity2 * Time.fixedDeltaTime;
			} else if (Input.GetKey (KeyCode.A)) {
				velocity *= forwardSpeed;
				Vector3 velocity2 = new Vector3 (0, 0, -forwardSpeed);
				transform.localPosition += velocity2 * Time.fixedDeltaTime;
			}
			velocity = transform.TransformDirection (velocity);
			transform.localPosition += velocity * Time.fixedDeltaTime;



			// 以下、Animatorの各ステート中での処理
			// Locomotion中
			// 現在のベースレイヤーがlocoStateの時
			if (currentBaseState.nameHash == locoState) {
				//カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves) {
					resetCollider ();
				}
			}
		// JUMP中の処理
		// 現在のベースレイヤーがjumpStateの時
		else if (currentBaseState.nameHash == jumpState) {
				//cameraObject.SendMessage("setCameraPositionJumpView");	// ジャンプ中のカメラに変更
				// ステートがトランジション中でない場合
				if (!anim.IsInTransition (0)) {

					// 以下、カーブ調整をする場合の処理
					if (useCurves) {
						// 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
						// JumpHeight:JUMP00でのジャンプの高さ（0〜1）
						// GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
						float jumpHeight = anim.GetFloat ("JumpHeight");
						float gravityControl = anim.GetFloat ("GravityControl"); 
						if (gravityControl > 0)
							rb.useGravity = false;	//ジャンプ中の重力の影響を切る

						// レイキャストをキャラクターのセンターから落とす
						Ray ray = new Ray (transform.position + Vector3.up, -Vector3.up);
						RaycastHit hitInfo = new RaycastHit ();
						// 高さが useCurvesHeight 以上ある時のみ、コライダーの高さと中心をJUMP00アニメーションについているカーブで調整する
						if (Physics.Raycast (ray, out hitInfo)) {
							if (hitInfo.distance > useCurvesHeight) {
								col.height = orgColHight - jumpHeight;			// 調整されたコライダーの高さ
								float adjCenterY = orgVectColCenter.y + jumpHeight;
								col.center = new Vector3 (0, adjCenterY, 0);	// 調整されたコライダーのセンター
							} else {
								// 閾値よりも低い時には初期値に戻す（念のため）					
								resetCollider ();
							}
						}
					}
					// Jump bool値をリセットする（ループしないようにする）
					anim.SetBool ("Jump", false);
				}
			}
		// IDLE中の処理
		// 現在のベースレイヤーがidleStateの時
		else if (currentBaseState.nameHash == idleState) {
				//カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves) {
					resetCollider ();
				}
				// スペースキーを入力したらRest状態になる
				if (Input.GetButtonDown ("Jump")) {
					anim.SetBool ("Rest", true);
				}
			}
		// REST中の処理
		// 現在のベースレイヤーがrestStateの時
		else if (currentBaseState.nameHash == restState) {
				//cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
				// ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
				if (!anim.IsInTransition (0)) {
					anim.SetBool ("Rest", false);
				}
			}
		}
	}

	/**
	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width -260, 10 ,250 ,150), "Interaction");
		GUI.Label(new Rect(Screen.width -245,30,250,30),"Up/Down Arrow : Go Forwald/Go Back");
		GUI.Label(new Rect(Screen.width -245,50,250,30),"Left/Right Arrow : Turn Left/Turn Right");
		GUI.Label(new Rect(Screen.width -245,70,250,30),"Hit Space key while Running : Jump");
		GUI.Label(new Rect(Screen.width -245,90,250,30),"Hit Spase key while Stopping : Rest");
		GUI.Label(new Rect(Screen.width -245,110,250,30),"Left Control : Front Camera");
		GUI.Label(new Rect(Screen.width -245,130,250,30),"Alt : LookAt Camera");
	}
	*/


	// キャラクターのコライダーサイズのリセット関数
	void resetCollider()
	{
		// コンポーネントのHeight、Centerの初期値を戻す
		col.height = orgColHight;
		col.center = orgVectColCenter;
	}

	public void electrocute(){
		
		anim.SetBool ("Shocked", true);
		origZ = transform.position.z;
		origX = transform.position.x;
		controlsEnabled = false;
		StartCoroutine (electrocuteAnimation ());
	}

	IEnumerator electrocuteAnimation(){
		float yMovement = 0, zMovement = 0;
		bool stopper = false;
		switch (direction) {
		case forward://send them backward
			zMovement = -0.15f;
			yMovement = 0;
			break;
		case backward:
			zMovement = 0.15f;
			yMovement = 0;
			break;
		case up:
			zMovement = 0f;
			yMovement = 0.15f;
			break;
		case down:
			zMovement = 0f;
			yMovement = -0.15f;
			break;
		}

		for (int i = 0; i < 12; i++) {
			float diff = Mathf.Abs (transform.position.z) - Mathf.Abs (origZ);
			float diff2 = Mathf.Abs (transform.position.x) - Mathf.Abs (origX);
			if (Mathf.Abs(diff)<1.5f && Mathf.Abs(diff2)<1.5f) {
				transform.position = new Vector3 (transform.position.x + yMovement, transform.position.y, transform.position.z + zMovement);
			}
			yield return new WaitForSeconds (0.1f);
		}
		controlsEnabled = true;
		anim.SetBool ("Shocked", false);
	}

	public void forcePush(){
		anim.SetBool ("Shocked", true);
		origZ = transform.position.z;
		origX = transform.position.x;
		controlsEnabled = false;
		origZ = transform.position.z;
		StartCoroutine (pushedAnimation ());
	}

	IEnumerator pushedAnimation(){
		float yMovement = 0, zMovement = 0;
		switch (direction) {
		case forward://send them backward
			zMovement = 0.3f;
			yMovement = 0;
			break;
		case backward:
			zMovement = -0.3f;
			yMovement = 0;
			break;
		case up:
			zMovement = 0f;
			yMovement = -0.3f;
			break;
		case down:
			zMovement = 0f;
			yMovement = 0.3f;
			break;
		}

		for (int i = 0; i < 12; i++) {
			float diff = Mathf.Abs (transform.position.z) - Mathf.Abs (origZ);
			float diff2 = Mathf.Abs (transform.position.x) - Mathf.Abs (origX);
			if (Mathf.Abs (diff) < 2f && Mathf.Abs (diff2) < 2f) {
				transform.position = new Vector3 (transform.position.x + yMovement, transform.position.y, transform.position.z + zMovement);
			} else {
				Debug.Log ("EXCEEDED");
			}


			yield return new WaitForSeconds (0.1f);
		}
		controlsEnabled = true;
		anim.SetBool ("Shocked", false);
	}

	public void getEaten(){

		anim.SetBool ("Eaten", true);
		origZ = transform.position.z;
		origX = transform.position.x;
		controlsEnabled = false;
		StartCoroutine (eatenAnimation ());
	}

	IEnumerator eatenAnimation(){
		float yMovement = 0, zMovement = 0;
		bool stopper = false;
		switch (direction) {
		case forward://send them backward
			zMovement = -0.2f;
			yMovement = 0;
			break;
		case backward:
			zMovement = 0.2f;
			yMovement = 0;
			break;
		case up:
			zMovement = 0f;
			yMovement = 0.2f;
			break;
		case down:
			zMovement = 0f;
			yMovement = -0.2f;
			break;
		}

		for (int i = 0; i < 18; i++) {
			float diff = Mathf.Abs (transform.position.z) - Mathf.Abs (origZ);
			float diff2 = Mathf.Abs (transform.position.x) - Mathf.Abs (origX);
			if (Mathf.Abs(diff)<1.5f && Mathf.Abs(diff2)<1.5f) {
				transform.position = new Vector3 (transform.position.x + yMovement, transform.position.y, transform.position.z + zMovement);
			}
			yield return new WaitForSeconds (0.1f);
		}
		controlsEnabled = true;
		anim.SetBool ("Eaten", false);
	}
		
}
