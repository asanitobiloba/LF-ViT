using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public static GameController control;

	void Awake(){

		control = this;
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(LoadLevel ("MainMenu"));
		
	}
	
	public IEnumerator LoadLevel(string sceneName){
		yield return new WaitForEndOfFrame ();
		SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
		StartCoroutine (UnloadLevels (sceneName));

			
}
	private IEnumerator UnloadLevels (string exception)
	{
		yield return new WaitForEndOfFrame ();
		for (int i = 0; i < SceneManager.sceneCount; i++) {
			if (SceneManager.GetSceneAt (i).name != exception && SceneManager.GetSceneAt (i).name != "VrMain") {
				SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt (i).name);


			}
		}

	}
}