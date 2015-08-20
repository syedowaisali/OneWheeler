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
using Assets.Scripts.States.Dust;
using Assets.Scripts.Misc;
using Assets.Scripts.Managers;


namespace Assets.Scripts.States
{
	public class MenuState : StateBase
	{
		public MenuState (StateManager sm) : base(sm){

		}

		public override void Init (){
			base.Init ();
			if (! SceneManager.IsSceneLoaded (SceneManager.MENU)) {
				SceneManager.LoadScene (SceneManager.MENU);
			}
		}

		public override void StateUpdate (){
			base.StateUpdate ();
			if (Input.GetKeyUp (KeyCode.Escape)) {
				Application.Quit ();
			}
		}

		public override void MouseDown (GameObject gameObj){
			base.MouseDown (gameObj);

			// play game
			if (gameObj.name.Equals (GameCenter.PLAY)) {
				manager.SetState(new DustLevel1 (manager));
				manager.SwitchState (new SceneCloseState (manager));
			}

			// goto setting scene
			else if (gameObj.name.Equals (GameCenter.SETTING)) {
				manager.SetState(new SettingState (manager));
				manager.SwitchState (new SceneCloseState (manager));
			}

			// quit game
			else if(gameObj.name.Equals(GameCenter.EXIT)){
				Application.Quit ();
			}
		}
	}
}

