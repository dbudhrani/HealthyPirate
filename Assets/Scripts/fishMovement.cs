using UnityEngine;
using System.Collections;

public class fishMovement : MonoBehaviour {
	
	public float speed = .6f;

	Vector3 posi;
	Animator anim;
	Rigidbody fishRigid;

	public float minX = -3.0f;
	public float maxX = 3.0f;
	public float minY = -3.0f;
	public float maxY = 3.0f;

	bool moveFish = true;
	bool insideBounds = false;

	void Update()
	{
		if(!IsInsideTheBounds()){
			if(insideBounds){
				insideBounds = false;
				transform.Rotate(new Vector3(0,0,-150));
				Invoke("MakeReady",10f);
				return;
			}
		}

		if (moveFish) {
			//Vector3 vec = new Vector3 (Random.Range (minX, maxX), Random.Range (-2.0f, 3.0f), 0.0f);
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
			ChangeDirection ();
		}
	}

	void ChangeDirection(){
		if(IsInsideTheBounds())
		{
			Debug.Log("IsInsideTheBounds true");
			insideBounds = true;
			transform.Rotate(new Vector3(10,10,10), Space.World);

		}
		Invoke("ChangeDirection",10f);
	}

	bool IsInsideTheBounds(){
		bool overlap = false;
		if(transform.position.x > minX &&
			transform.position.x < maxX &&
			transform.position.y > minY &&
			transform.position.y < maxY ){
			overlap = true;
		}
		return overlap;
	}

	void MakeReady(){
		insideBounds = true;
	}

	void Start()
	{
		anim = GetComponent<Animator> ();
		fishRigid = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()//call on every physics update
	{
	//	randomY  = Random.Range(-15, 15);
	//	Vector3 vector = new Vector3 (0f, randomY, 0f);
//
	//	Move (vector);
		Animating ();
	}

	void Move(Vector3 vector)
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);
		//fishRigid.MovePosition (vector);
	}

	void Animating() 
	{
		//bool isHit = h != 0f || v != 0f;
		bool isHit = false;
		anim.SetBool ("isHit", isHit);
	}


}
