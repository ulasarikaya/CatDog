using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FelisEtCanisController : MonoBehaviour {
	public static float speed;
	public static float jumpSpeed;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	public GameObject rythmCube;

	private bool isGrounded;
	private bool isAlive;
	private float healthStatus;

	public Transform obstacleCheck;
	public LayerMask whatIsObstacle;

	private bool isCollided;

	public UnityEngine.UI.Text scoreLabel;
	private int score;
	private int scoreUpdateInterval;

	public Button switchButton;
	public Text switchButtonText;

	public Image healthBar;
	public float healthFull = 159.5f;
	private float healthFill;

	public static bool canisActive;

	private int canisSpeed = 15;
	private int canisJump = 35;

	private int felisSpeed = 10;
	private int felisJump = 45;

	private static float speedMultiplier = 1.00f;
	private static float speedIncreaseRate = 0.0003f;

	private RectTransform healthBarTransform;

	//GameObject healthBar = GameObject.FindGameObjectWithTag ("HealthBarFG");

	public static void pickBeast (bool beast) {
		canisActive = beast;
		if (canisActive) {
			speed = 30 * speedMultiplier;
			jumpSpeed = 35;
		} else {
			speed = -20 * speedMultiplier;
			jumpSpeed = 45;
		}
	}

	// Use this for initialization
	void Start () {
		healthStatus = 0.0f;
		isAlive = true;
		Time.timeScale = 1;
		score = 0;
		scoreUpdateInterval = 0;
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
		scoreLabel.text = "Score: " + score;
		switchButton.onClick.AddListener(TaskOnClick);
		healthBarTransform = healthBar.transform as RectTransform;
		healthFill = healthFull / healthStatus;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
			scoreUpdateInterval = scoreUpdateInterval + 1;
			if (scoreUpdateInterval % 30 == 0 && isAlive) {
				if (speed <= 70) {
					speedMultiplier = speedMultiplier + speedIncreaseRate;
					speed = speed * speedMultiplier;
				}
//				RotationSpeed = -RotationSpeed;
				if (canisActive) {
					score = score + 2;
				} else {
					score = score + 1;
				}
				scoreLabel.text = "Score: " + score;
			}
		}
		transform.Translate (Vector3.right * speed * Time.deltaTime);

		//isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		isGrounded = Physics2D.OverlapBox (groundCheck.position, groundCheck.localScale, 0f, whatIsGround);
		//isCollided = Physics2D.OverlapBox (obstacleCheck.position, obstacleCheck.localScale, 0f, whatIsObstacle);

//		if (Input.GetKeyDown("space")) {
//			Debug.Log ("Space is down");
//			Instantiate((Object)rythmCube, transform.position, Quaternion.Euler(0, 180, 0));
//		}

		if (Input.GetMouseButtonDown (0) && isGrounded) 
		{
			
			Debug.Log ("Bastik");
			if (EventSystem.current.IsPointerOverGameObject ()) {
//				System.Type selectedObject = 
//				if (selectedObject.FullName == "SwitchButton") {
//				}
				if (EventSystem.current.currentSelectedGameObject == null) {
					Debug.Log ("TRTRLOLO");
				}
				else if ((EventSystem.current.currentSelectedGameObject.CompareTag ("SwitchButton") && healthStatus >= 1f) || EventSystem.current.currentSelectedGameObject.CompareTag ("PauseButton")) {
					Debug.Log ("TROLOLO");
				} else {
					Debug.Log ("LOLO");
					transform.Translate (Vector3.up * jumpSpeed * Time.deltaTime);
					GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpSpeed;
				}
				 
			}
			else {
				transform.Translate (Vector3.up * jumpSpeed * Time.deltaTime);
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpSpeed;
			}
//			transform.Translate (Vector3.up * jumpSpeed * Time.deltaTime);
//			GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpSpeed;
			//velocity = new Vector3 (velocity.x, jumpSpeed, 0f);
		}

		/*if (isCollided) {
			speed = 0;
		}*/
		if (healthStatus >= 1f) {
			switchButtonText.text = "Switch";
		}

//		healthFill = healthFull / healthStatus;

		healthBarTransform.sizeDelta = new Vector2(healthFull * healthStatus, healthBarTransform.sizeDelta.y);
		//healthFull / healthStatus
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Obstacle") {
			if (healthStatus >= 1) {
				switchAction ();
			} else {
				SceneManager.LoadScene ("gameOverScene");

				Debug.Log ("Collision");
				isAlive = false;
				speed = 0;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Food") {
			GameObject food = GameObject.FindGameObjectWithTag("Food");
//			Debug.Log ("Food gathered +50 score");
			if (healthStatus < 1) {
				healthStatus = healthStatus + 0.15f;
			}
			score = score + 50;
			scoreLabel.text = "Score: " + score;
			food.transform.position = new Vector3 (food.transform.position.x + speed * 30, food.transform.position.y, food.transform.position.z);
//			healthBar.fillAmount = healthStatus;
		}
		else if (c.gameObject.tag == "SmallFood") {
			GameObject food = GameObject.FindGameObjectWithTag("SmallFood");
			//			Debug.Log ("Food gathered +50 score");
			if (healthStatus < 1) {
				healthStatus = healthStatus + 0.05f;
			}
			score = score + 15;
			scoreLabel.text = "Score: " + score;
			food.transform.position = new Vector3 (food.transform.position.x + speed * 30, food.transform.position.y, food.transform.position.z);
			//			healthBar.fillAmount = healthStatus;
		}
	}

	void switchAction()
	{
		if (healthStatus >= 1) {
			switchButtonText.text = "";
			canisActive = !canisActive;
			healthStatus = 0f;
//			healthBar.fillAmount = healthStatus;
			transform.Translate (Vector3.up * 0 * Time.deltaTime);
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * 0;
			if (canisActive) {
				speed = canisSpeed * speedMultiplier;
				jumpSpeed = canisJump;
			} else {
				speed = -felisSpeed * speedMultiplier;
				jumpSpeed = felisJump;
			}
		}
	}
	void TaskOnClick() {
		if (healthStatus >= 1) {
			switchButtonText.text = "";
			canisActive = !canisActive;
			healthStatus = 0f;
//			healthBar.fillAmount = healthStatus;
			transform.Translate (Vector3.up * 0 * Time.deltaTime);
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * 0;
			if (canisActive) {
				speed = canisSpeed;
				jumpSpeed = canisJump;
			} else {
				speed = -felisSpeed;
				jumpSpeed = felisJump;
			}
		}
	}
	void Awake()
	{
		SceneManager.activeSceneChanged += ScreenChanged;
	}
	void ScreenChanged(Scene previousScene, Scene newScene)
	{
		if (newScene.name == "gameOverScene") {
			GameObject scoreObject = GameObject.Find("ScoreObject");
			scoreObject.GetComponent<Text> ().text = score.ToString();
		}
	}
}
