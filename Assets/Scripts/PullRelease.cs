using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRelease : MonoBehaviour
{
    Vector2 startPos;
    private Sling sl;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        startPos= transform.position;
        sl= FindObjectOfType<Sling>();
        force= FindObjectOfType<Planet>().force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp() {
        // Disable isKinematic
        Rigidbody2D bird=  GetComponent<Rigidbody2D>();
        bird.isKinematic = false;
        bird.gravityScale=0;
        // Add the Force
        Vector2 dir = startPos - (Vector2)transform.position;
        Vector2 p= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mag_vec = p - startPos;
        float mag= mag_vec.sqrMagnitude;
        if (mag > 4f){
            mag= 4f;
        }
        GetComponent<Rigidbody2D>().AddForce(dir * force * mag);
        // Remove the Script (not the gameObject)
        // sl.spawnWithGap(3f);
        FindObjectOfType<CameraController>().moveToCenter();
        Destroy(this);

    }

    void OnMouseDrag() {
        Vector2 p= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Keep it in a certain radius
        float radius = 1.2f;
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
            dir = dir.normalized * radius;

        // Set the Position
        transform.position = startPos + dir;
    }
}
