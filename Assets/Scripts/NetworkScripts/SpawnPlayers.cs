using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawn;
    GameObject player;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        player = PhotonNetwork.Instantiate(playerPrefab.name, spawn.position, Quaternion.identity);
    }

    private void Update()
    {
        if (GetComponent<BoxCollider2D>().CompareTag("Player"))
        {
            spawnPlayers();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawnPlayers();
        }
    }
    void spawnPlayers()
    {
        player.transform.position = spawn.position;
    }
}
