using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet : NetworkBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    [SyncVar]
    public Color color;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
