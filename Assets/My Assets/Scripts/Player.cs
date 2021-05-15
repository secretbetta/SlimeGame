using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Player Class. Used as main player controller.</summary>
public class Player : MonoBehaviour {
	private Rigidbody2D myrigidbody;
	[SerializeField]
	private float movementspeed = 10f;
	[SerializeField]
	private float jumpheigt = 10f;
	private bool isGround;
	private bool facing = true;
	private float horizontal;
	private Vector3 spawnPos;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public GameObject PanelLose;
	public GameObject PanelWin;
	public AudioSource sound;
	
	void Start ()
	{
		myrigidbody = GetComponent<Rigidbody2D> ();
		spawnPos = gameObject.transform.position;
	}
	void FixedUpdate ()
	{
		horizontal = Input.GetAxis ("Horizontal");
		isGround = Physics2D.OverlapCircle (groundCheck.position, 0.3f, whatIsGround);
		myrigidbody.velocity = new Vector2 (horizontal * movementspeed, myrigidbody.velocity.y);
		print("Ground: " + isGround);
		if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
		{
			sound.Play();
			myrigidbody.AddForce (transform.up * jumpheigt, ForceMode2D.Impulse);
		}
		if (horizontal > 0 && !facing) 
		{
			Flip ();
		}
		else if (horizontal < 0 && facing) 
		{
			Flip ();
		}
	}

	///<summary>Flips sprite around on the Z axis</summary>
	private void Flip ()
	{
		facing = !facing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	///<summary>Finish level function, activates win panel</summary>
	void Finish ()
	{
		myrigidbody.bodyType = RigidbodyType2D.Static;
		PanelWin.SetActive (true);
		Destroy (gameObject);
	}
	void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Saw")
		{
			gameObject.SetActive(false);
			// gameObject.GetComponent<SpriteRenderer>().enabled = false;
			Invoke("Death", 2.5f);
		}
		if(col.tag == "Death")
		{
			gameObject.SetActive(false);
			Death();
		}
		if (col.tag == "Portal")
		{
			Finish ();
		}
	}

	void OnDestroy() {
		print("Spawning");
		Invoke("Death", 2.5f);
		print("Spawned");
	}

	private void Death()
	{
		// What happens when player dies
		gameObject.transform.position = new Vector3(spawnPos.x, spawnPos.y);
		gameObject.SetActive(true);
		// gameObject.GetComponent<SpriteRenderer>().enabled = true;
		// ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
		// em.enabled = true;
	}
}
