using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Material spr;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        spr= GetComponent<Renderer>().material;
        color= spr.color;
    }

    // Update is called once per frame
    void Update()
    {
        color.a-=0.0008f;
        if (color.r<1f)
            color.r+=0.005f;
        spr.color=color;
        if (color.a<0f)
            Destroy(this);
    }
}
