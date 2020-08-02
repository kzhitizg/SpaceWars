using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Vector3 directionOfBirdFromPlanet;
    private bool allowForce;
    public Rigidbody2D bird;
    public Planet planet;
    private float gravitationalForce = 5;
    public float sp_factor;
    public bool InPlanet;
    public Cloud cloud;
    public ParticleSystem trail;
    int countdown=0;
    Vector2 bird_dir;
    public BoostText txt;
    AudioSource boostEffect;
    public VelocityText velocityText;
    public PosText posText;
    public Text mytry;
    Vector3 pos;
    // public int boosts=8;
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        planet= FindObjectOfType<Planet>();
        // InvokeRepeating("IOcheck", 0f, 0.5f);
        InPlanet=true;
        FindObjectOfType<PlanetBoundary>().bd= this;
        InvokeRepeating("drawTrail", 0f, 0.2f);
        planet.updateBoosts();
        txt= FindObjectOfType<BoostText>();
        txt.GetComponent<Text>().text= "Boosts : " + planet.boosts.ToString();
        // Debug.Log("Boosts : " + planet.boosts.ToString());
        boostEffect= GetComponent<AudioSource>();
        velocityText= FindObjectOfType<VelocityText>();
        velocityText.GetComponent<Text>().text= "Velocity: 0";
        posText= FindObjectOfType<PosText>();
        posText.GetComponent<Text>().text= "Position: 0x + 0y";
        // backgroundMusic= GetComponent<AudioSource>();
        // backgroundMusic.Play();
    }

    private void FixedUpdate() {
        if (InPlanet){
            directionOfBirdFromPlanet = planet.transform.position-transform.position;
            Vector3 unitvector= directionOfBirdFromPlanet.normalized;
            float factor= directionOfBirdFromPlanet.magnitude;
            factor= factor*.2f;
            bird.AddForce(unitvector*gravitationalForce*factor);
        }
    }

    private void drawTrail(){
        if (bird.velocity.magnitude>0.2){
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    private void Update() {
        if (countdown>0){
            countdown--;
        }
        if (Input.GetKey(KeyCode.Space) && countdown==0 && planet.boosts>0){
            bird_dir= bird.velocity;
            // Debug.Log(bird.velocity);
            bird.AddForce(bird_dir*sp_factor);
            Vector3 pos= new Vector3(transform.position.x, transform.position.y, -5);
            Quaternion ang= new Quaternion();
            ang.eulerAngles= transform.eulerAngles;
            Instantiate(trail, pos, ang);
            countdown= 10;
            planet.boosts--;
            boostEffect.Play();
            txt.GetComponent<Text>().text= "Boosts : " + planet.boosts.ToString();
            Debug.Log(planet.boosts);
            if (planet.boosts==0 && InPlanet){
                Invoke("GameOverWithGap", 5f);
            }
        }
        velocityText.GetComponent<Text>().text= "Velocity: " + bird.velocity.magnitude.ToString("n3");
        pos= bird.transform.position- planet.transform.position;
        posText.GetComponent<Text>().text= "Position: " + pos.x.ToString("n1") + "x + " + pos.y.ToString("n1") + "y";
    }
    public void attract(Vector3 amount){
        bird.AddForce (amount);
    }

    private void OnDestroy() {
        FindObjectOfType<Sling> ().spawnWithGap(1f);
    }

    private void GameOverWithGap(){
        if (InPlanet)
            Destroy(gameObject);
    }
}
