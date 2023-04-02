using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // public Text pointsText;
    public CharacterController2D player;

    public void Setup(int score){
        gameObject.SetActive(true);
        // pointsText.Text = score.toString() + " points";
    }

    public void Reset(){
        gameObject.SetActive(false);
        player.transform.position = player.playerInitialPosition;
    }
}
