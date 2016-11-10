using UnityEngine;
using System.Collections;

public class fishMovement : MonoBehaviour {
	
	public float speed = 6f;

	Vector3 posi;
	Animator anim;
	Rigidbody fishRigid;

	void Start()
	{
		anim = GetComponent<Animator> ();
		fishRigid = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()//call on every physics update
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		posi.Set(h, 0f, v);
		posi = posi.normalized * speed * Time.deltaTime;

		fishRigid.MovePosition (transform.position+posi);
	}

	void Animating(float h, float v) 
	{
		//bool isHit = h != 0f || v != 0f;
		bool isHit = false;
		anim.SetBool ("isHit", isHit);
	}


}
