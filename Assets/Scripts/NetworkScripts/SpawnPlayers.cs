using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    Vector2 randomPosition;
    GameObject player;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
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
        player.transform.position = randomPosition;
    }
}
