using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject Play= null, Pause=null, pauseObject;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
        // pauseObjects= GameObject.FindGameObjectsWithTag("ShowOnPaused");
        // Debug.Log(pauseObjects);
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
    }

    // public void GameOver(){
    //     hidePaused();
    //     Time.timeScale= 0;
    //     foreach (var item in ingame)
    //     {
    //         item.gameObject.SetActive(false);
    //     }
    //     foreach (var item in gameover)
    //     {
    //         item.gameObject.SetActive(true);
    //     }
    // }
    public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

    public void showPaused(){
        Play.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
		// foreach(GameObject g in pauseObjects){
		pauseObject.gameObject.SetActive(true);
		// }
	}

    public void hidePaused(){
        Play.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
		// foreach(GameObject g in pauseObjects){
		pauseObject.gameObject.SetActive(false);
		// }
	}

    public void LoadLevel(string level){
        /*Debug.Log(SceneManager.sceneCount);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Debug.Log(SceneManager.GetSceneAt(i));
        }*/
        // Debug.Log("LoadLevel Called");
        SceneManager.LoadSceneAsync(level);
		// Application.LoadLevel(level);
	}

    public void Reload(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
