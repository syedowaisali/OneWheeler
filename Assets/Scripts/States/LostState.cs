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

namespace Assets.Scripts.States
{
	public class LostState : StateBase{

		private GameObject playAgain;
		private GameObject backToMenu;
		private GameObject pause;
		private GameObject leftControl;
		private GameObject rightControl;

		public LostState (StateManager sm) : base(sm){

		}

		public override void Init (){
			base.Init ();

			playAgain = GameObject.Find (GameCenter.PLAY_AGAIN);
			backToMenu = GameObject.Find (GameCenter.BACK_TO_MENU);
			pause = GameObject.Find (GameCenter.PAUSE);
			leftControl = GameObject.Find (GameCenter.LEFT_CONTROL);
			rightControl = GameObject.Find (GameCenter.RIGHT_CONTROL);

			// hide control buttons
			GameObject.Find (GameCenter.LEFT_CONTROL).GetComponent<Animator> ().SetBool ("Start", true);
			GameObject.Find (GameCenter.RIGHT_CONTROL).GetComponent<Animator> ().SetBool ("Start", true);

			// hide pause button
			HidePauseButton ();

			// show play again and menu button
			ShowPlayAgainAndMenuButton ();

			// remove cycle target from camera
			manager.mainCamera.GetComponent<SmoothCamera2D> ().target = null;
		}

		public override void MouseDown (GameObject gameObj){
			base.MouseDown (gameObj);

			// restart current level
			if (gameObj.name.Equals (GameCenter.PLAY_AGAIN)) {
				Debug.Log(manager.GetState());
				manager.SwitchState (manager.GetState());
				if(manager.activeState is PlayState){
					HidePlayAgainAndMenuButton ();
					ShowPauseButton ();
					ShowControl ();
					((PlayState) manager.activeState).Restart();
				}
			}
		}

		private void HidePauseButton (){
			pause.GetComponent<Animator> ().SetBool ("Start", true);
		}

		private void ShowPauseButton (){
			pause.GetComponent<Animator> ().SetBool ("Start", false);
		}

		private void ShowPlayAgainAndMenuButton (){
			playAgain.GetComponent<Animator> ().SetBool ("Start", true);
			backToMenu.GetComponent<Animator> ().SetBool ("Start", true);
		}

		private void HidePlayAgainAndMenuButton (){
			playAgain.GetComponent<Animator> ().SetBool ("Start", false);
			backToMenu.GetComponent<Animator> ().SetBool ("Start", false);
		}

		private void ShowControl (){
			leftControl.GetComponent<Animator> ().SetBool ("Start", false);
			rightControl.GetComponent<Animator> ().SetBool ("Start", false);
		}
	}
}

