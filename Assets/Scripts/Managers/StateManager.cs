using UnityEngine;
using System.Collections;
using Assets.Scripts.Base;
using Assets.Scripts.States;
using Assets.Scripts.Misc;
using Assets.Scripts.Managers;

public class StateManager : MonoBehaviour {

	[HideInInspector]
	public GameData gameData;
	public GameObject mainCamera;
	public StateBase activeState;

	private static StateManager instance;
	private StateBase currentState;

	void Awake (){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);

		} else {
			DestroyImmediate (gameObject);
		}
	}

	// Use this for initialization
	void Start () {

		gameData = GetComponent<GameData> ();

		activeState = new BeginState (this);
		activeState.Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activeState != null)
			activeState.StateUpdate ();
	}

	void FixedUpdate (){
		if (activeState != null)
			activeState.StateFixedUpdate ();
	}

	void OnGUI (){
		if (activeState != null)
			activeState.StateGUI ();
	}

	void OnLevelWasLoaded(int level) {
		mainCamera = GameObject.Find (GameCenter.MAIN_CAMERA);
		if (activeState != null)
			activeState.SceneLoaded (level);
	}

	public void DetectCollision2D(Collision2D collider, GameObject sender){
		if (activeState != null)
			activeState.DetectCollision2D (collider, sender);
	}

	public void TriggerEnter2D(Collider2D collider, GameObject sender){
		if (activeState != null)
			activeState.TriggerEnter2D (collider, sender);
	}

	public void MouseDown (GameObject gameObj){

		if (activeState != null)
			activeState.MouseDown (gameObj);
	}

	public void MouseUp (GameObject gameObj){
		if (activeState != null)
			activeState.MouseUp (gameObj);
	}

	public void SwitchState(StateBase newState){
		activeState = newState;
		activeState.Init ();
	}

	public GameObject BuildObject(GameObject obj){
		return Instantiate (obj);
	}

	public void Recycle() {
		if (activeState != null)
			activeState.Recycle ();
	}

	public void LoaderWheelHide (){
		if (activeState != null)
			activeState.LoadingWheelHide ();
	}

	public void SetState<T> (T level) where T : StateBase {
		currentState = level;
	}

	public StateBase GetState (){
		return currentState;
	}
}
