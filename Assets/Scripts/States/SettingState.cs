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
using Assets.Scripts.Misc;
using Assets.Scripts.Managers;

namespace Assets.Scripts.States{

	public class SettingState : StateBase{

		private GameObject sound;
		private GameObject soundMute;

		public SettingState (StateManager sm) : base(sm){
			if (! SceneManager.IsSceneLoaded (SceneManager.SETTING)) {
				SceneManager.LoadScene (SceneManager.SETTING);
			}
		}

		public override void SceneLoaded (int level){
			base.SceneLoaded (level);

			sound = GameObject.Find (GameCenter.SOUND);
			soundMute = GameObject.Find (GameCenter.SOUND_MUTE);
			
			if (StorageManager.IsSoundOn ()) {
				ShowSoundButton ();
			} else {
				ShowSoundMuteButton ();
			}
		}

		public override void MouseDown (GameObject gameObj){
			base.MouseDown (gameObj);

			// mute sound
			if (gameObj.name.Equals (GameCenter.SOUND)) {
				StorageManager.SetSound (false);
				ShowSoundMuteButton ();
			}

			// unmute sound
			else if (gameObj.name.Equals (GameCenter.SOUND_MUTE)) {
				StorageManager.SetSound (true);
				ShowSoundButton ();
			}

			// back to menu
			else if (gameObj.name.Equals (GameCenter.BACK_TO_MENU)) {
				manager.SwitchState (new MenuState (manager));
			}
		}

		private void ShowSoundButton () {
			soundMute.GetComponent<SpriteRenderer> ().enabled = false;
			soundMute.GetComponent<CircleCollider2D> ().enabled = false;

			sound.GetComponent<SpriteRenderer> ().enabled = true;
			sound.GetComponent<CircleCollider2D> ().enabled = true;
		}

		private void ShowSoundMuteButton () {
			sound.GetComponent<SpriteRenderer> ().enabled = false;
			sound.GetComponent<CircleCollider2D> ().enabled = false;

			soundMute.GetComponent<SpriteRenderer> ().enabled = true;
			soundMute.GetComponent<CircleCollider2D> ().enabled = true;
		}
	}
}

