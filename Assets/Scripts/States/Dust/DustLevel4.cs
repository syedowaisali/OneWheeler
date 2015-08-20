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

	public class DustLevel4 : PlayState{

		public DustLevel4 (StateManager sm) : base(sm) {
			if (! SceneManager.IsSceneLoaded (SceneManager.Dust.LEVEL4)) {
				SceneManager.LoadScene (SceneManager.Dust.LEVEL4);
			}
		}

		public override void SceneLoaded (int level){
			base.SceneLoaded (level);
			if (StorageManager.IsSoundOn ()) {
				GameObject.Find (GameCenter.Dust.HAMMER_CLIP).GetComponent<AudioSource> ().Play ();
			}
		}

		public override void FinishLevel (){
			manager.SetState (new DustLevel4(manager));
			base.FinishLevel ();
		}
	}
}

