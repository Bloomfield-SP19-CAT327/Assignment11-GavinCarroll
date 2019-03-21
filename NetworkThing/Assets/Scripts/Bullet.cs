using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet : NetworkBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            Player player = ClientScene.FindLocalObject(parentNetId).GetComponent<Player>();
            player.score += 100;
            Destroy(other.gameObject);
        }
    }
    [SyncVar]
    public Color color;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    [SyncVar]
    public NetworkInstanceId parentNetId;
}
