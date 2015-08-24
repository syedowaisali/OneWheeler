//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using Assets.Scripts.Base;
using Assets.Scripts.Managers;
using Assets.Scripts.Misc;

namespace Assets.Scripts.States
{
	public class PlayState : StateBase
	{
		private GameObject cycle;
		private Transform pipe;
		private Rigidbody2D rb;
		private SmoothCamera2D cameraScript;
		private GameObject leftControl;
		private GameObject rightControl;
		private WheelController wheelController;
		private float axis = 0f;
		private bool finish = true;
		protected static string unlockNextLevel;
		private static Vector3 cyclePos;

		public PlayState (StateManager sm) : base(sm){
		}

		public override void Init (){
			base.Init ();
			finish = false;
		}

		public override void SceneLoaded (int level){
			base.SceneLoaded (level);

			// initiate cycle
			cycle = GameObject.FindWithTag (Tags.CYCLE);
			
			// save position
			cyclePos = cycle.transform.position;

			InitComponenets ();
		}

		private void InitComponenets () {

			// initiate cycle
			if(cycle == null)
				cycle = GameObject.FindWithTag (Tags.CYCLE);
			
			// get cycle pipe
			pipe = cycle.transform.Find (GameCenter.PIPE);
			
			// get rigidbody from cycle
			rb = cycle.GetComponent<Rigidbody2D> ();
			
			// get wheel controller script from cycle
			wheelController = cycle.GetComponent<WheelController> ();
			
			// set cycle initial position x,y,z
			//cycle.transform.position = new Vector3 (0f, 0.89f, 0f);
			
			// get camera controller script from cycle
			if(cameraScript == null)
				cameraScript = manager.mainCamera.GetComponent<SmoothCamera2D> ();

			// set damp time to 0
			//cameraScript.dampTime = 0f;

			// set camera target to cycle
			cameraScript.target = cycle.gameObject.transform;
			
			// get left control button
			leftControl = GameObject.Find (GameCenter.LEFT_CONTROL);
			
			// get right control button
			rightControl = GameObject.Find (GameCenter.RIGHT_CONTROL);
			
			//Physics2D.IgnoreCollision (leftControl.GetComponent<CircleCollider2D> (), cycle.GetComponent<CircleCollider2D> ());
			//Physics2D.IgnoreCollision (rightControl.GetComponent<CircleCollider2D> (), cycle.GetComponent<CircleCollider2D> ());
			//Physics2D.IgnoreCollision (leftControl.GetComponent<CircleCollider2D> (), pipe.GetComponent<CircleCollider2D> ());
			//Physics2D.IgnoreCollision (rightControl.GetComponent<CircleCollider2D> (), pipe.GetComponent<CircleCollider2D> ());
		}

		public override void StateUpdate (){
			base.StateUpdate ();
			if (Input.GetAxis ("Horizontal") > 0) {
				axis = 1f;
			} else if (Input.GetAxis ("Horizontal") < 0) {
				axis = -1f;
			} else {
				#if UNITY_EDITOR
					axis = 0f;
				#endif
			}
		}
		
		public override void StateFixedUpdate (){
			base.StateFixedUpdate ();

			if (! finish) {
				if (rb != null) {
					if (rb.velocity.sqrMagnitude < wheelController.maxSpeed) {
						if (axis > 0) {
							rb.AddTorque (-1 * wheelController.force);
						}
						else if (axis < 0) {
							rb.AddTorque (1 * wheelController.force);
						}
					}
				}
			}
		}

		public override void DetectCollision2D (Collision2D collider, GameObject sender){

			if (
				(
					collider.transform.tag == Tags.DIE_BLOCK || 
					collider.transform.tag == Tags.ROLLER ||
					collider.transform.tag == Tags.THORN
				) 
				&&
				(
					sender.tag == Tags.PIPE ||
					sender.tag == Tags.SEAT
					
				)) {

				// play cycle break sound
				if(StorageManager.IsSoundOn())
					cycle.GetComponent<AudioSource>().Play ();

				// ingonre collisions
				Physics2D.IgnoreCollision (cycle.GetComponent<CircleCollider2D> (), pipe.GetComponent<BoxCollider2D> ());
				Physics2D.IgnoreCollision (cycle.GetComponent<CircleCollider2D> (), pipe.Find(GameCenter.SEAT).GetComponent<BoxCollider2D> ());

				// deatached pipe from seat
				pipe.Find(GameCenter.SEAT).transform.parent = null;

				// add rigidbody2d component to seat
				if(GameObject.Find(GameCenter.SEAT).GetComponent<Rigidbody2D> () == null)
					GameObject.Find(GameCenter.SEAT).AddComponent<Rigidbody2D> ();

				// add minor force to seat
				GameObject.Find(GameCenter.SEAT).GetComponent<Rigidbody2D> ().AddForce(Vector2.right * 1, ForceMode2D.Impulse);

				// remove force from wheel
				if (rb.angularVelocity > 0f){
					rb.angularVelocity = 300f;
				}
				else {
					rb.angularVelocity = -300f;
				}

				// remove force from wheel
				rb.velocity = Vector3.zero;


				// remove hing joint componenet from cycle
				if (cycle.GetComponent<HingeJoint2D> () != null)
					cycle.GetComponent<HingeJoint2D> ().enabled = false;

				// detached pipe to wheel
				pipe.parent = null;

				// remove pipe force
				if(pipe.GetComponent<Rigidbody2D> () != null)
					pipe.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;

				// switch play state to lost state
				manager.SwitchState(new LostState (manager));
			}
		}

		public override void MouseDown (GameObject gameObj){
			base.MouseDown (gameObj);

			if (! finish) {
				if (gameObj.name.Equals (GameCenter.LEFT_CONTROL)) {
					axis = -1f;
				}
				else if(gameObj.name.Equals (GameCenter.RIGHT_CONTROL)){
					axis = 1f;
				}
				else if(gameObj.name.Equals (GameCenter.PAUSE)){
					finish = true;
					((PlayState) manager.GetState ()).Pause ();
					manager.SwitchState(new PauseState (manager));
				}
			}
		}

		public override void MouseUp (GameObject gameObj){
			base.MouseUp (gameObj);

			if (! finish) {
				if (gameObj.name.Equals (GameCenter.LEFT_CONTROL)) {
					axis = 0f;
				}
				else if(gameObj.name.Equals (GameCenter.RIGHT_CONTROL)){
					axis = 0f;
				}
			}
		}

		public override void TriggerEnter2D (Collider2D collider, GameObject sender){
			base.TriggerEnter2D (collider, sender);

			if (! finish) {
				if (collider.name.Equals (GameCenter.FINISH_LINE)) {
					finish = true;
					rb.angularVelocity = -300f;
					rb.velocity = Vector2.zero;
					rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 360f - pipe.localEulerAngles.z));
					Object.Destroy(cycle.GetComponent<HingeJoint2D> ());
					Object.Destroy(pipe.GetComponent<Rigidbody2D> ());
					Object.Destroy(cycle.GetComponent<Rigidbody2D> ());
					((PlayState) manager.GetState ()).FinishLevel ();
					StorageManager.SetLevelLocked(unlockNextLevel, false);
					manager.SwitchState (new LevelFinishState (manager));
				}
			}

			// check is trigger is checkpoint
			if (collider.transform.tag.Equals (Tags.CHECKPOINT)) {
				cyclePos = new Vector3 (
					cycle.transform.position.x,
					cycle.transform.position.y,
					0.2300093f
					);


				collider.transform.Find( GameCenter.CHECKPOINT_FLAG).GetComponent<Animator> ().SetBool ("Show", true);
				Object.Destroy(collider.GetComponent<BoxCollider2D> ());
			}
		}

		public virtual void FinishLevel (){

		}

		public virtual void SetNextState (){
		}

		public override void Recycle (){
			base.Recycle ();
			InitComponenets ();
			((PlayState)manager.GetState ()).Resume ();
		}

		public virtual void Pause (){
		}

		public virtual void Resume (){
		}

		public virtual void ResetCycle() {
			Object.Destroy (GameObject.FindWithTag(Tags.CYCLE));
			Object.Destroy (GameObject.Find (GameCenter.PIPE));
			Object.Destroy (GameObject.Find (GameCenter.SEAT));
			GameObject newCycle = Object.Instantiate (manager.gameData.cycle) as GameObject;
			newCycle.transform.position = cyclePos;

			cameraScript = manager.mainCamera.GetComponent<SmoothCamera2D> ();
			cameraScript.dampTime = 0f;
			cameraScript.target = newCycle.gameObject.transform;

			manager.StartCoroutine (LateInit ());
		}

		IEnumerator LateInit (){
			yield return new WaitForSeconds (0.5f);
			InitComponenets ();
		}
	}
}

