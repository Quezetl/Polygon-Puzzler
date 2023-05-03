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

    private void Start()
    {
        // Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Vector2 startPosition = new Vector2(-10, -4); // Temporarily hard-coding this for testing
        PhotonNetwork.Instantiate(playerPrefab.name, startPosition, Quaternion.identity);
    }


}
