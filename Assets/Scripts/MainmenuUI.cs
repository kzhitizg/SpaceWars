using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuUI : MonoBehaviour
{
    public GameObject credits, main;
    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string level){
        
        SceneManager.LoadSceneAsync(level);
    }

    public void ShowCredits(){
        credits.SetActive(true);
        main.SetActive(false);
    }

    public void HideCredits(){
        credits.SetActive(false);
        main.SetActive(true);
    }
}
