using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    public float speed = 5.0f;
   public enum DriftDirection
    {
       LEFT = -1,

        RIGHT = 1
    }

    public DriftDirection driftDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime * (int)driftDirection); //

        if (transform.position.x < -7 || transform.position.x > 34)   //
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(transform);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(null);
        }
    }
}
