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
using Assets.Scripts.States.Dust;

namespace Assets.Scripts.States{

	public class LevelFinishState : StateBase{

		private GameObject pause;
		private GameObject gotoMenu;
		private GameObject reloadLevel;
		private GameObject playNextLevel;
		private GameObject leftControl;
		private GameObject rightControl;

		public LevelFinishState (StateManager sm) : base(sm){

		}

		public override void Init (){
			base.Init ();

			pause = GameObject.Find (GameCenter.PAUSE);
			gotoMenu = GameObject.Find (GameCenter.GOTO_MENU);
			reloadLevel = GameObject.Find (GameCenter.RELOADE_LEVEL);
			playNextLevel = GameObject.Find (GameCenter.PLAY_NEXT_LEVEL);
			leftControl = GameObject.Find (GameCenter.LEFT_CONTROL);
			rightControl = GameObject.Find (GameCenter.RIGHT_CONTROL);
							
			HideControl ();
			HidePauseButton ();
			ShowPlayAndMenuButton ();
		}

		public override void MouseDown (GameObject gameObj){
			base.MouseDown (gameObj);

			// restart current level
			if (gameObj.name.Equals (GameCenter.RELOADE_LEVEL)) {
				manager.SwitchState (manager.GetState());
				if(manager.activeState is PlayState){
					HidePlayAndMenuButton ();
					ShowPauseButton ();
					ShowControl ();
					((PlayState) manager.activeState).Restart();
				}
			} 

			// load next level
			else if (gameObj.name.Equals (GameCenter.PLAY_NEXT_LEVEL)) {
				((PlayState) manager.GetState()).SetNextState ();
				manager.SwitchState(new SceneCloseState(manager));
			}
		}

		private void HidePauseButton (){
			pause.GetComponent<Animator> ().SetBool("Start", true);
		}

		private void ShowPauseButton (){
			pause.GetComponent<Animator> ().SetBool("Start", false);
		}

		private void HidePlayAndMenuButton (){
		
			gotoMenu.GetComponent<Animator> ().SetBool ("Start", false);
			reloadLevel.GetComponent<Animator> ().SetBool ("Start", false);
			playNextLevel.GetComponent<Animator> ().SetBool ("Start", false);
		}

		private void ShowPlayAndMenuButton (){
			
			gotoMenu.GetComponent<Animator> ().SetBool ("Start", true);
			reloadLevel.GetComponent<Animator> ().SetBool ("Start", true);
			playNextLevel.GetComponent<Animator> ().SetBool ("Start", true);
		}

		private void HideControl (){
			leftControl.GetComponent<Animator> ().SetBool ("Start", true);
			rightControl.GetComponent<Animator> ().SetBool ("Start", true);
		}

		private void ShowControl (){
			leftControl.GetComponent<Animator> ().SetBool ("Start", false);
			rightControl.GetComponent<Animator> ().SetBool ("Start", false);
		}
	}
}

