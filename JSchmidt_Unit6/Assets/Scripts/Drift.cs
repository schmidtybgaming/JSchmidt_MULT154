using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Drift : NetworkBehaviour
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
        if(!IsServer)
        {
            return;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime * (int)driftDirection); //

        if (transform.position.x < -7 || transform.position.x > 34)   //
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                NetworkObject player = transform.GetChild(i).GetComponent<NetworkObject>();
                player.TryRemoveParent();
            }
            
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (!IsServer)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            NetworkObject player = collision.gameObject.GetComponent<NetworkObject>();
            player.TrySetParent(transform);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (!IsServer)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            NetworkObject player = collision.gameObject.GetComponent<NetworkObject>();
            player.TryRemoveParent();
        }
    }

   
}
