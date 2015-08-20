using UnityEngine;
using System.Collections;
using Assets.Scripts.Misc;

public class EventBus : MonoBehaviour {

	private StateManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find (GameCenter.GAME_MANAGER).GetComponent<StateManager> ();
	}

	void OnCollisionEnter2D(Collision2D collider){
		manager.DetectCollision2D (collider, gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		manager.TriggerEnter2D (collider, gameObject);
	}

	void OnMouseDown (){
		manager.MouseDown (gameObject);
		Debug.Log (gameObject);
	}

	void OnMouseUp (){
		manager.MouseUp (gameObject);
	}

	void LoadingWheelHide(){
		manager.LoaderWheelHide ();
	}
}
