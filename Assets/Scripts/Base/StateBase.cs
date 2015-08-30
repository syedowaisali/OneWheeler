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
using Assets.Scripts.Interfaces;
using Assets.Scripts.States;
using Assets.Scripts.Misc;
using System.Collections;


namespace Assets.Scripts.Base
{
	public abstract class StateBase : IStateBase
	{
		public StateManager manager;

		public StateBase (StateManager sm){
			manager = sm;
		}

		public virtual void Init(){}
		public virtual void StateUpdate (){}
		public virtual void StateFixedUpdate (){}
		public virtual void StateGUI (){}
		public virtual void DetectCollision2D (Collision2D collider, GameObject sender){}
		public virtual void MouseUp (GameObject gameObj){}
		public virtual void TriggerEnter2D (Collider2D collider, GameObject sender){}
		public virtual void Restart (){}

		public virtual void MouseDown (GameObject gameObj){
			if (gameObj.transform.tag.Equals (Tags.BACK_TO_MENU)) {
				BackToMenu ();
			}
		}

		public virtual void SceneLoaded(int level){
			manager.StartCoroutine (ResetPhysicsTime ());
		}

		public virtual void BackToMenu (){
			manager.SetState(new MenuState (manager));
			manager.SwitchState (new SceneCloseState (manager));
		}

		public virtual void LoadingWheelHide (){
			GameObject.Find (GameCenter.SHUTTER_SLIDE).GetComponent<Animator> ().SetBool ("Hiding", true);
		}

		IEnumerator ResetPhysicsTime (){
			Time.timeScale = 0.1f;
			float pauseEndTime = Time.realtimeSinceStartup + 2;
			while (Time.realtimeSinceStartup < pauseEndTime)
			{
				yield return 0;
			}
			Time.timeScale = 1;
		}
	}
}

