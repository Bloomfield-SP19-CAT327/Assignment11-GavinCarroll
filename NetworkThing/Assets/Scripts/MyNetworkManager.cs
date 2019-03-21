using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerToSpawn.GetComponent<Player>().color = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        NetworkServer.AddPlayerForConnection(conn, playerToSpawn, playerControllerId);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
