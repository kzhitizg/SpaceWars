using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem prt;
    public Sling sling;
    public bool move= false;
    float angle=0f, max, mean;
    public float speed= 0.1f;
    // public AudioSource backgroundMusic;
    public bool blinkEffect=false;
    // Start is called before the first frame update
    void Start()
    {
        max= 10f;
        mean= transform.position.y;
        // backgroundMusic= GetComponent<AudioSource>();
        // backgroundMusic.Play();
        InvokeRepeating("Blink", .0f, 1f);
    }

    private void Blink() {
        // Debug.Log(gameObject.activeSelf);
        if (blinkEffect){
            if(gameObject.activeSelf==true)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move){
            transform.position= new Vector3(transform.position.x, mean+max*Mathf.Sin(angle), transform.position.z);
            angle+=speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
        Vector3 pos= new Vector3(transform.position.x, transform.position.y, -5);
        Instantiate(prt, pos, Quaternion.identity);
        sling.CompletedWithGap();
    }
}
