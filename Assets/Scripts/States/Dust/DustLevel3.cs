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

	public class DustLevel3 : DustPlay{

		public DustLevel3 (StateManager sm) : base(sm) {

		}

		public override void Init (){

			// set next state
			manager.SetState (new DustLevel3 (manager));

			base.Init ();

			if (! SceneManager.IsSceneLoaded (SceneManager.Dust.LEVEL3)) {
				SceneManager.LoadScene (SceneManager.Dust.LEVEL3);
			}
		}

		public override void FinishLevel (){
			base.FinishLevel ();
			
			// set net level unlock
			unlockNextLevel = "dustlevel3lock";
		}

		public override void SetNextState (){
			base.SetNextState ();
			
			// set next state
			manager.SetState (new DustLevel4 (manager));
		}
	}
}

