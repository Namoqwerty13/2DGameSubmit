using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    float ballSpeed = 5;
    bool needRight;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(-3.27f, 3.7f, 0);
        needRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xtrans = Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime;

        if (!GameObject.Find("Main Camera").GetComponent<GeneralScript>().youwin && !GameObject.Find("Main Camera").GetComponent<GeneralScript>().gameover)
        {
            if (transform.position.x < -GeneralScript.halfWidth)
            {
                transform.position = new Vector3(-GeneralScript.halfWidth, transform.position.y, 0);
            }
            else if (transform.position.x > GeneralScript.halfWidth)
            {
                transform.position = new Vector3(GeneralScript.halfWidth, transform.position.y, 0);
            }
            else
                transform.Translate(xtrans, 0, 0);
        }

        if (GameObject.Find("Main Camera").GetComponent<GeneralScript>().youwin)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (transform.position.x > 0)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
        }
        else
        {
            transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        
        //print("OnTriggerEnter");
        if (other.tag.Equals("Floor"))
        {
            if (needRight == true && transform.position.x < 0)
            {
                GameObject.Find("Main Camera").GetComponent<GeneralScript>().GameOver();
                rb.useGravity = false;
                rb.velocity = new Vector3(0, 0, 0);
            }
            else if (needRight == false && transform.position.x > 0)
            {
                GameObject.Find("Main Camera").GetComponent<GeneralScript>().GameOver();
                rb.useGravity = false;
                rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                rb.velocity = -rb.velocity;
                GameObject.Find("Main Camera").GetComponent<GeneralScript>().score++;
                needRight = !needRight;
            }
            

            

        }
        if (other.tag.Equals("Respawn"))
        {
            GameObject.Find("Main Camera").GetComponent<GeneralScript>().GameOver();
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
