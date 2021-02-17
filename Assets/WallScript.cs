using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

        transform.localScale = new Vector3(0.4f, 5.8f, 1f);
        transform.position = new Vector3(0, -2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Main Camera").GetComponent<GeneralScript>().score > 5 && !GameObject.Find("Main Camera").GetComponent<GeneralScript>().youwin && !GameObject.Find("Main Camera").GetComponent<GeneralScript>().gameover)
        {
            transform.Rotate(new Vector3(0, 0, 0.5f));
        }
    }
}
