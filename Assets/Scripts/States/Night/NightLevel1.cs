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

namespace Assets.Scripts.States.Night{

	public class NightLevel1 : NightPlay{

		public NightLevel1 (StateManager sm) : base(sm) {

		}

		public override void Init (){
			base.Init ();

			// set next state
			manager.SetState (new NightLevel1 (manager));

			if (! SceneManager.IsSceneLoaded (SceneManager.Night.LEVEL1)) {
				SceneManager.LoadScene (SceneManager.Night.LEVEL1);
			}
		}

		public override void FinishLevel (){
			base.FinishLevel ();

			// set net level unlock
			unlockNextLevel = "nightlevel1lock";
		}

		public override void SetNextState (){
			base.SetNextState ();

			// set next state
			manager.SetState (new NightLevel2 (manager));
		}
	}
}
