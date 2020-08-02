using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sling : MonoBehaviour
{
    public GameObject birdPrefab, ingame, gameover, completed;
    public float delx, dely;
    Canvas can;
    public int lives=3;
    public GameObject gameOverSound, SuccessSound;
    // Start is called before the first frame update
    void Start()
    {
        can= FindObjectOfType<Canvas>();
        ingame.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
        completed.gameObject.SetActive(false);
        spawnNext();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spawnWithGap(float t){
        lives--;
        can.LifeUpdated(lives);
        if (lives==0){
            Invoke("GameOver", 2f);
            // GameOver();
            return;
        }
        FindObjectOfType<CameraController> ().setToSling();
        StartCoroutine(timeGap(t));
    }

    IEnumerator timeGap(float t){
        yield return new WaitForSeconds(t);
        spawnNext();
    }

    void spawnNext() {
        // Spawn a Bird at current position with default rotation  
        Vector3 newpos = new Vector3(transform.position.x-delx, transform.position.y-dely, transform.position.z);
        Quaternion ang= new Quaternion();
        ang.eulerAngles= transform.eulerAngles;
        Instantiate(birdPrefab, newpos, ang);
    }

    public void GameOver(){
        Time.timeScale= 0;
        ingame.gameObject.SetActive(false);
        gameover.gameObject.SetActive(true);
        FindObjectOfType<CameraController>().GetComponent<AudioSource>().Pause();
        Instantiate(gameOverSound, transform.position, Quaternion.identity);
    }

    public void Completed(){
        Instantiate(SuccessSound, transform.position, Quaternion.identity);
        FindObjectOfType<CameraController>().GetComponent<AudioSource>().Pause();
        Time.timeScale= 0;
        ingame.gameObject.SetActive(false);
        completed.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    public void CompletedWithGap(){
        Invoke("Completed", 1f);
    }
}
