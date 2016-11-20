using UnityEngine;
using System.Collections;

public class fishMovement : MonoBehaviour {
	
	public float speed = 106f;

	Vector3 posi;
	Animator anim;
	Rigidbody fishRigid;

	public float minX = -3.0f;
	public float maxX = 3.0f;
	public float minY = -3.0f;
	public float maxY = 3.0f;

	bool moveFish = true;
	bool insideBounds = false;
	bool facingUp;

	void Start()
	{
		anim = GetComponent<Animator> ();
		fishRigid = GetComponent<Rigidbody> ();
		facingUp = true;
		StartCoroutine(moveFish2());
	}

	IEnumerator moveFish2() {
		while (transform.position.x > -2) {
			//Debug.Log("facingUp = " + facingUp);
			//Debug.Log("Y = " + transform.position.y);
			yield return new WaitForSeconds(0.1f);
			if (facingUp) {
				transform.Rotate(new Vector3(1,0,0), Space.Self);
				transform.Translate(new Vector3(-1,1,0) * Time.deltaTime * speed, Space.World);
				if (transform.position.y >= 1) {
					facingUp = false;
				}
			} else {
				transform.Rotate(new Vector3(-1,0,0), Space.Self);
				transform.Translate (new Vector3(-1,-1,0) * Time.deltaTime * speed, Space.World);
				if (transform.position.y <= -0.25) {
					facingUp = true;
				}
			}
		}
		//Destroy(this.gameObject);
	}

	void Update()
	{
		/*if(!IsInsideTheBounds()){
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
		}*/
	}

	void ChangeDirection(){
		if(IsInsideTheBounds())
		{
			Debug.Log("IsInsideTheBounds true");
			insideBounds = true;
			transform.Rotate(new Vector3(10,0,0), Space.Self);

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
