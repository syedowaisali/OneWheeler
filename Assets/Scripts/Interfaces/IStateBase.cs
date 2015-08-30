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
namespace Assets.Scripts.Interfaces
{
	public interface IStateBase
	{
		void Init ();
		void StateUpdate ();
		void StateFixedUpdate ();
		void StateGUI ();
		void SceneLoaded(int level);
		void DetectCollision2D (Collision2D collider, GameObject sender);
		void TriggerEnter2D (Collider2D collider, GameObject sender);
		void MouseDown (GameObject gameObj);
		void MouseUp (GameObject gameObj);
		void Restart ();
		void BackToMenu ();
		void LoadingWheelHide ();
	}
}

