using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour{
	
	public float force;
	public float maxSpeed;

	private Rigidbody2D rb;

	void Awake (){
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedsUpdate () {
		//transform.Rotate (new Vector3(0,0, (Input.GetAxis("Horizontal") * -1) * spinSpeed * Time.deltaTime));
		//rb.AddForce (new Vector2 ((Input.GetAxis("Horizontal")) * force * Time.deltaTime, 0), ForceMode2D.Impulse);
		if (rb.velocity.sqrMagnitude < maxSpeed) {
			if (Input.GetAxis("Horizontal") > 0) {
				rb.AddTorque (-1 * force);
			}
			else if (Input.GetAxis("Horizontal") < 0) {
				rb.AddTorque (1 * force);
			}
			Debug.Log (rb.velocity.sqrMagnitude);
		}


		//rb.AddTorque ((Input.GetAxis ("Horizontal") * -1) * force);
	}
}
