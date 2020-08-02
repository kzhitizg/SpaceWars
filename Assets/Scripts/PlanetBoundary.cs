using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBoundary : MonoBehaviour
{
    public Bird bd;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // bd= FindObjectOfType<Bird>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (bd)
            bd.InPlanet= false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (bd)
            bd.InPlanet= true;
    }
}
