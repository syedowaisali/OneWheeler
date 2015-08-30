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

namespace Assets.Scripts.States.Dust{
	
	public class DustLevel7 : DustPlay{

		private GameObject circleBridg;
		private Transform bridg3;
		private Transform bridg4;

		public DustLevel7 (StateManager sm) : base(sm) {

		}

		public override void Init (){
			base.Init ();

			// set next state
			manager.SetState (new DustLevel7 (manager));

			if (! SceneManager.IsSceneLoaded (SceneManager.Dust.LEVEL7)) {
				SceneManager.LoadScene (SceneManager.Dust.LEVEL7);
			}
		}

		public override void StateUpdate (){
			base.StateUpdate ();

			if (circleBridg != null) {

				bridg3.rotation = Quaternion.Euler(
					bridg3.rotation.x,
					bridg3.localRotation.y,
					bridg3.rotation.z );

				bridg4.rotation = Quaternion.Euler(
					bridg4.rotation.x,
					bridg4.localRotation.y,
					bridg4.rotation.z );
			}
		}

		public override void FinishLevel (){
			base.FinishLevel ();
			
			// set net level unlock
			unlockNextLevel = "dustlevel7lock";
		}

		public override void SetNextState (){
			base.SetNextState ();

			// set next state
			manager.SetState (new DustLevel8 (manager));
		}

		public override void SceneLoaded (int level){
			base.SceneLoaded (level);
			initObj ();
		}

		public override void Restart (){
			base.ResetCycle ();
			initObj ();
		}

		public override void Resume (){
			base.Resume ();
			initObj ();
		}

		private void initObj (){
			circleBridg = GameObject.Find (GameCenter.Dust.CIRCLE_BRIDG);
			bridg3 = circleBridg.transform.Find (GameCenter.Dust.BRIDG3);
			bridg4 = circleBridg.transform.Find (GameCenter.Dust.BRIDG4);
		}
	}
}

