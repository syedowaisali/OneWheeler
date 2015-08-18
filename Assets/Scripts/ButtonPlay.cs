using UnityEngine;
using System.Collections;
using Assets.Scripts.States;
using Assets.Scripts.Misc;

public class ButtonPlay : MonoBehaviour {

	private StateManager manager;

	void Awake (){
		manager = GameObject.Find (GameCenter.GAME_MANAGER).GetComponent<StateManager> ();
	}

	void OnMouseDown (){
		if (manager != null)
			manager.SwitchState (new PlayState (manager));
	}
}
