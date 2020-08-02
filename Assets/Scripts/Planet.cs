using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int boosts;
    public float force;
    int maxBoosts;
    public GameObject smash;

    // Start is called before the first frame update
    void Start()
    {
        maxBoosts= boosts;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBoosts(){
        boosts= maxBoosts;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag=="Player" && !other.gameObject.GetComponent<Rigidbody2D>().isKinematic){
            Instantiate(smash, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
        }
    }
}
