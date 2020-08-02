using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public GameObject AvailLife1, AvailLife2, AvailLife3, NoLife1, NoLife2, NoLife3;
    // Start is called before the first frame update
    void Start()
    {
        AvailLife1.gameObject.SetActive(true);
        AvailLife2.gameObject.SetActive(true);
        AvailLife3.gameObject.SetActive(true);
        NoLife1.gameObject.SetActive(false);
        NoLife2.gameObject.SetActive(false);
        NoLife3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeUpdated(int life){
        switch (life) {
            case 3:
                AvailLife1.gameObject.SetActive(true);
                AvailLife2.gameObject.SetActive(true);
                AvailLife3.gameObject.SetActive(true);
                NoLife1.gameObject.SetActive(false);
                NoLife2.gameObject.SetActive(false);
                NoLife3.gameObject.SetActive(false);
                break;
            case 2:
                AvailLife1.gameObject.SetActive(true);
                AvailLife2.gameObject.SetActive(true);
                AvailLife3.gameObject.SetActive(false);
                NoLife1.gameObject.SetActive(false);
                NoLife2.gameObject.SetActive(false);
                NoLife3.gameObject.SetActive(true);
                break;
            case 1:
                AvailLife1.gameObject.SetActive(true);
                AvailLife2.gameObject.SetActive(false);
                AvailLife3.gameObject.SetActive(false);
                NoLife1.gameObject.SetActive(false);
                NoLife2.gameObject.SetActive(true);
                NoLife3.gameObject.SetActive(true);
                break;
            case 0:
                AvailLife1.gameObject.SetActive(false);
                AvailLife2.gameObject.SetActive(false);
                AvailLife3.gameObject.SetActive(false);
                NoLife1.gameObject.SetActive(true);
                NoLife2.gameObject.SetActive(true);
                NoLife3.gameObject.SetActive(true);
                break;
        }
    }
}
