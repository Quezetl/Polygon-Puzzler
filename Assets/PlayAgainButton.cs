using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public void OnButtonClick(){
        gameOverScreen.Reset();
    }
}
