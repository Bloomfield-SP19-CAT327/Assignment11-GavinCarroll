using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player : NetworkBehaviour
{
    public GameObject bulletPrefab;
    float moveSpeed = 1.875f;

    [SyncVar]
    public Color color;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    void Update()
    {
        if (isLocalPlayer && hasAuthority)
            {
            GetInput();
        }
    }
    void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonUp("Fire1"))
        {
            CmdDoFire();
        }
        if (isServer)
        {
            RpcMoveIt(x, y);
        }
        else
        {
            CmdMoveIt(x, y);
        }
    }

    [ClientRpc]
    void RpcMoveIt(float x, float y)
    {
        transform.Translate(x, y, 0);
    }

    [Command]
    public void CmdMoveIt(float x, float y)
    {
        RpcMoveIt(x, y);
    }

    [Command]
    public void CmdDoFire()
    {
        GameObject Bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + this.transform.right, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 17.5f;
        Bullet.GetComponent<Bullet>().color = color;
        Destroy(Bullet, 0.875f);
        NetworkServer.Spawn(Bullet);
    }
}
