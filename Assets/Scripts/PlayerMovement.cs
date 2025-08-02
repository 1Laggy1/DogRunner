using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : Unit
{
	private float speedPC = 10f;
	public float normalSpeed;
	private float ChangeSpeed = 8f;
	public Rigidbody2D rb;
	private SpriteRenderer sprite;
	//private Slider SliderGet;
	float horizontalInput;
	float verticalInput;
	float verticalspeed = 15f;
	float jumpForce = 10f;
	public bool isGrounded;
	readonly Vector2 force = new Vector2(50, 50);
	public GameObject CheckGround1;
	public Zone z;
	public GameTime t;
	public bool start = true;
	public bool soar = false;
	public bool left = false;
	public bool right = false;
	public bool jump = false;
	public bool isLeft;
	public bool isRight;
	public float rightspeed = 0;
	public float leftspeed = 0;
	public MovingObstacle mo;
	public MovingObstacle mo2;
	public MovingObstacle mo3;
	public MovingObstacle mo4;
	public MovingObstacle mo5;
	public Text speedText;
	public Animator anim;
	public RuntimeAnimatorController dog2;
	public RuntimeAnimatorController dog3;
	public NavigationRestart jumpButton;
	//public SliderSpeed sliderSpeed;
	UnityEngine.UI.Slider SpeedSlider;
	//float Velocity = ConvertToInt;
	private string lvl;
	public SaveGame sg;
	public GameMusic gm;
	public bool MusicStart = false;
	private float velocityWithJumpObject;
	public GameObject SliderTutorialText;
	public GameObject Xrestik;
	public bool SpawnedXrestik;
	//var obj;
	List<GameObject> generatedObjects = new List<GameObject>();
	float gravityScale = 2.5f;

	public static PlayerMovement Instance { get; set; }

	void Start()
    {
		anim = GetComponent<Animator>();
		if (PlayerPrefs.GetFloat("DogSkin") == 2)
        {
			anim.runtimeAnimatorController = dog2 as RuntimeAnimatorController;

		}
		else if (PlayerPrefs.GetFloat("DogSkin") == 3)
		{
			anim.runtimeAnimatorController = dog3 as RuntimeAnimatorController;

		}
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		//SliderGet = GameObject.Find("Slider").GetComponent<Slider>().value;
		//sliderSpeed = GetComponent<Slider>();
		//SpeedSlider = GameObject.Find("Slider").GetComponent<Slider>();
		
		if (SceneManager.GetActiveScene().name == "Level3")
		{
			lvl = "Level3";
		}
		else if (SceneManager.GetActiveScene().name == "Level1 (2)")
		{
			lvl = "Level1 (2)";
		}
		else if (SceneManager.GetActiveScene().name == "Level2")
		{
			lvl = "Level2";
		}
		else if (SceneManager.GetActiveScene().name == "Level1(1)")
		{
			lvl = "Level1(1)";
		}
		else if (SceneManager.GetActiveScene().name == "Level2(1)")
		{
			lvl = "Level2(1)";
		}
		else if (SceneManager.GetActiveScene().name == "Level3(1)")
		{
			lvl = "Level3(1)";
		}
	}

	// Update is called once per frame
	private void Update()
	{
		//normalSpeed = SpeedSlider.value;
		//speedText.text = SpeedSlider.value.ToString("F2");
		if (start && (jump || left || right))
		{
			start = false;
			t.GetComponent<GameTime>().enabled = true;
			z.GetComponent<Zone>().enabled = true;
			if (mo != null)
			{
				mo.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo2 != null)
			{
				mo2.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo3 != null)
			{
				mo3.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo4 != null)
			{
				mo4.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo5 != null)
			{
				mo5.GetComponent<MovingObstacle>().enabled = true;
			}
			//GetComponent<PlayerMovement>().enabled = true;
			if (MusicStart == false)
            {
				MusicStart = true;
			}
		}
		if (start && (Input.GetButtonDown("Jump") || Input.GetButton("Horizontal")))
		{
			start = false;
			t.GetComponent<GameTime>().enabled = true;
			z.GetComponent<Zone>().enabled = true;
			if (mo != null)
			{
				mo.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo2 != null)
			{
				mo2.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo3 != null)
			{
				mo3.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo4 != null)
			{
				mo4.GetComponent<MovingObstacle>().enabled = true;
			}
			if (mo5 != null)
			{
				mo5.GetComponent<MovingObstacle>().enabled = true;
			}
			//GetComponent<PlayerMovement>().enabled = true;
			if (MusicStart == false)
			{
				//gm.GetComponent<AudioSource>().enabled = true;
				MusicStart = true;
			}
		}
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			Jump();
			anim.SetBool("TakeOff", true);
			soar = true;
			//anim.SetTrigger("Jump");
		}
		else if (Input.GetButton("Jump"))
		{
			soar = true;
		}
		else if (Input.GetButtonUp("Jump"))
		{
			soar = false;
		}
		Run();
		RunPC();
		Fly();
		//FlyPC();

		if (Input.GetKey("escape"))  // ���� ������ ������� Esc (Escape)
		{
			Application.Quit();    // ������� ����������
		}


		
		


		if (isGrounded == true)
		{
			anim.SetBool("isJumping", false);
		}
		else
		{
			anim.SetBool("isJumping", true);
			Debug.Log("isJumping");
		}

		if (jump == true)
		{
			anim.SetTrigger("TakeOff");
        }
		jump = false;

		if (lvl == "Level3(1)")
        {
			if (normalSpeed != 10f)
            {
				if (SliderTutorialText != null)
				SliderTutorialText.SetActive(false);

			}
        }


		////////Fly for pc
		//if (Input.GetButton("Jump"))
		//{
		//	SoarButtonDown();
		//}
		//else
		//{
		//	SoarButtonNotDown();
		//}
		//if (isGrounded == false)
		//{
		//	anim.SetBool("isRunning", false);
		//	anim.SetBool("isJump", true);
		//}
		//else
		//{
		//	anim.SetBool("isJump", false);
		//}
	}

	public void JumpButton()
    {
		if (isGrounded)
		{
			Jump();
			jump = true;
		}
		
	}

	public void SoarButtonDown()
    {
		soar = true;
    }

	public void SoarButtonNotDown()
	{
		soar = false;
		//anim.SetBool("TakeOff", false);
		//anim.SetBool("TakeOff", false);
	}

	public void LeftButtonDown()
    {
		//if (isLeft == false)
		//{
			leftspeed = -normalSpeed;
			sprite.flipX = true;
			left = true;
		anim.SetBool("isRunning", true);
		//}
	}

	public void RightButtonDown()
	{
		//if (isRight == false)
		//{
			rightspeed = normalSpeed;
			sprite.flipX = false;
			right = true;
			Debug.Log("Go Right");
		anim.SetBool("isRunning", true);
		//}
		//else
		//{
		//rightspeed = 0f;
		//}
	}

	public void ButtonNotDown()
    {
		rightspeed = 0f;
		leftspeed = 0f;
		left = false;
		right = false;
		jumpButton.ButtonsDown = false;
		anim.SetBool("isRunning", false);
	}

	private void Fly()
	{
		if (soar == true && (rb.velocity.y <= -0.1))
		{
			if (rb.velocity.y > -2)
			{
				rb.gravityScale = 5f;
			}
			else if (rb.velocity.y < -2)
			{
				rb.gravityScale = 0.1f;
				rb.velocity = new Vector2(0, -2);
			}

			//rb.gravityScale = 0.1f;
		}
		else
		{
			rb.gravityScale = 2.5f;
		}
	}

	//private void FlyPC()
	//{
	//	if (Input.GetButton("Space") && (rb.velocity.y <= -0.1))
	//	{
	//		if (rb.velocity.y > -2)
	//		{
	//			rb.gravityScale = 5f;
	//		}
	//		else if (rb.velocity.y < -2)
	//		{
	//			rb.gravityScale = 0.1f;
	//			rb.velocity = new Vector2(0, -2);
	//		}

			//rb.gravityScale = 0.1f;
	//	}
	//	else
	//	{
	//		rb.gravityScale = 2.5f;
	//	}
	//}


	//private void CheckGround()
	//{
	//	Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
	//
	//	isGrounded = colliders.Length > 1;
	//}

	//void OnCollisionStay2D(Collision2D collision)
	//{
	//	isGrounded = true;
	//}

	private void Run()
	{
		Vector3 direction = transform.right * 1;

		if (isRight == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, rightspeed * Time.deltaTime);
        }
		
		if (isLeft == false)
        {
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, leftspeed * Time.deltaTime);
		}

		//sprite.flipX = direction.x > 0.0F;
		//if (isGrounded) State = CharState.Run;
	}

	private void RunPC()
	{
		Vector3 direction = transform.right * 1;
		if (isRight == false && Input.GetButton("D"))
        {
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, normalSpeed * Time.deltaTime);
			sprite.flipX = false;
			anim.SetBool("isRunning", true);
		}
		else if (isLeft == false && Input.GetButton("A"))
        {
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, (-normalSpeed) * Time.deltaTime);
			sprite.flipX = true;
			anim.SetBool("isRunning", true);
		}
		//else
        //{
			//anim.SetBool("isRunning", false);
		//}
		//transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speedPC * Time.deltaTime);
		//sprite.flipX = direction.x > 0.0F;
		//if (isGrounded) State = CharState.Run;
	}

	private void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
	}

	public void Restart()
    {
		var objects = Instantiate(Xrestik, transform.position, Quaternion.identity);
		foreach (var obj in generatedObjects)
		{
			Destroy(obj);
		}
		generatedObjects.Add(objects);
		
		SpawnedXrestik = true;
		if (lvl == "Level3(1)")
        {
			transform.position = new Vector2(16, (float)3.5);
		}
        else
        {
			transform.position = new Vector2(-8, (float)0.5);
		}
		
		if (lvl == "Level3")
		{
			sg.Attemptslvl3 = PlayerPrefs.GetFloat("Attemptslvl3") + 1;
			PlayerPrefs.SetFloat("Attemptslvl3", sg.Attemptslvl3);
		}
		else if (lvl == "Level1 (2)")
		{
			sg.Attemptslvl1 = PlayerPrefs.GetFloat("Attemptslvl1") + 1;
			PlayerPrefs.SetFloat("Attemptslvl1", sg.Attemptslvl1);
		}
		else if (lvl == "Level2")
		{
			sg.Attemptslvl2 = PlayerPrefs.GetFloat("Attemptslvl2") + 1;
			PlayerPrefs.SetFloat("Attemptslvl2", sg.Attemptslvl2);
			Debug.Log("Xudga");
		}
		else if (lvl == "Level1(1)")
		{
			sg.Attemptslvl4 = PlayerPrefs.GetFloat("Attemptslvl4") + 1;
			PlayerPrefs.SetFloat("Attemptslvl4", sg.Attemptslvl4);
			Debug.Log("Xudga");
		}
		else if (lvl == "Level2(1)")
		{
			sg.Attemptslvl5 = PlayerPrefs.GetFloat("Attemptslvl5") + 1;
			PlayerPrefs.SetFloat("Attemptslvl5", sg.Attemptslvl5);
			Debug.Log("Xudga");
		}
		else if (lvl == "Level3(1)")
		{
			sg.Attemptslvl6 = PlayerPrefs.GetFloat("Attemptslvl6") + 1;
			PlayerPrefs.SetFloat("Attemptslvl6", sg.Attemptslvl6);
			Debug.Log("Xudga");
		}
		else
		{
		}
		rb.velocity = new Vector2(0, 0);
	}

	public void JumpWithJumpObject(float JumpForceWO)
    {
		velocityWithJumpObject = rb.velocity.y;
		if (velocityWithJumpObject < 0)
        {
			JumpForceWO = JumpForceWO - velocityWithJumpObject/10;
		}
		else if (velocityWithJumpObject > 0)
		{
			JumpForceWO = JumpForceWO + velocityWithJumpObject / 10;
		}
		rb.velocity = new Vector2(0, 0);
		GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForceWO, ForceMode2D.Impulse);
	}

	


}
