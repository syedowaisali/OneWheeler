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
using Assets.Scripts.Base;
using Assets.Scripts.Managers;
using Assets.Scripts.Misc;
using System.Collections;

namespace Assets.Scripts.States.Dust{
	
	public class DustLevel9 : DustPlay{

		public DustLevel9 (StateManager sm) : base(sm) {

		}

		public override void Init (){
			base.Init ();

			// set next state
			manager.SetState (new DustLevel9 (manager));

			if (! SceneManager.IsSceneLoaded (SceneManager.Dust.LEVEL9)) {
				SceneManager.LoadScene (SceneManager.Dust.LEVEL9);
			}
		}

		public override void FinishLevel (){
			base.FinishLevel ();
			
			// set net level unlock
			unlockNextLevel = "dustlevel9lock";
		}

		public override void SetNextState (){
			base.SetNextState ();

			// set next state
			manager.SetState (new DustLevel10 (manager));
		}

		public override void DetectCollision2D (Collision2D collider, GameObject sender){
			base.DetectCollision2D (collider, sender);
			
			if (collider.transform.tag == Tags.DIE_BLOCK && collider.transform.name.Equals(GameCenter.Dust.DROP_BLOCK) && sender.tag == Tags.CYCLE) {
				manager.StartCoroutine (Drop (collider.transform));
			}
		}

		public override void SceneLoaded (int level){
			base.SceneLoaded (level);
			GeneratDropBlock ();
		}

		public override void Restart (){
			base.Restart ();
			GeneratDropBlock ();
		}

		private void GeneratDropBlock (){

			float x = 70.5f;
			float dec = 0.8f;
			foreach (GameObject db in GameObject.FindGameObjectsWithTag(Tags.DIE_BLOCK)) {
				if(db.name.Equals(GameCenter.Dust.DROP_BLOCK)){
					db.GetComponent<Rigidbody2D> ().isKinematic = true;
					db.transform.localPosition = new Vector3 (x, 0f, 3.46f);
					db.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
					x -= dec;
				}
			}
		}

		IEnumerator Drop (Transform t){
			yield return new WaitForSeconds(0.5f);
			t.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}

