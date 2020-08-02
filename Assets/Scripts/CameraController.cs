using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool camMoving;
    Vector3 EndPos;
    float endSize;
    Camera cam;
    Sling sling;
    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<Camera>();
        sling= FindObjectOfType<Sling> ();
        StartCoroutine("startWait");
    }
    IEnumerator startWait(){
        yield return new WaitForSeconds(2f);
        setToSling();
    }
    public void setToSling(){
        EndPos=  new Vector3(sling.transform.position.x+1f, sling.transform.position.y, -10);
        endSize= 4.5f;
        camMoving=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (camMoving){
            transform.position= Vector3.Lerp(transform.position, EndPos, Time.deltaTime*5);
            cam.orthographicSize= Mathf.Lerp(cam.orthographicSize, endSize, Time.deltaTime*5);
            if (transform.position== EndPos){
                camMoving= false;
            }
        }
    }

    public void moveToCenter(){
        EndPos=new Vector3(0, 0, -10);
        camMoving= true;
        endSize= 16f;
    }
}
