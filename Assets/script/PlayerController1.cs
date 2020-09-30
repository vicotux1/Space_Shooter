using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{public float speed ,tilt;
	public string moveX="Horizontal", MoveY="Vertical";
	public Vector2 boundaryMin,boundaryMax;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private Rigidbody rb;
	private AudioSource audioSource;
	private float nextFire;
	
	void Awake(){
		Cursor.visible = false;
		rb=GetComponent<Rigidbody>();
		audioSource=GetComponent<AudioSource>();
	}
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position,transform.rotation);
			audioSource.Play ();
		}
	}

	void FixedUpdate (){
	float AxisX = Input.GetAxis(moveX);
	float AxisY = Input.GetAxis (MoveY);
	movement(AxisX,AxisY);
		
	}
	void movement(float X, float Y){
	Vector3 movement = new Vector3 (X,0, Y);
		rb.velocity = movement * speed;
		float LimiteX=Mathf.Clamp (rb.position.x, boundaryMin.x, boundaryMax.x);
		float LimiteY=Mathf.Clamp (rb.position.y, boundaryMin.y, boundaryMax.y);
		//rb.position = new Vector3(LimiteX,0,LimiteY);
		
		rb.rotation =Quaternion.Euler (rb.velocity.x * -tilt,0,0);
	}
}
