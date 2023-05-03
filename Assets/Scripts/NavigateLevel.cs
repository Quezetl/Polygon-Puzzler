using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Navigate()
    {
        Application.LoadLevel("Loading");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
