using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    
    public bool isalive=false;
    public int numneighbors=0;
    public void SetAlive(bool alive)
    {
        isalive=alive;
        if (alive)
        {
            GetComponent<SpriteRenderer>().enabled=true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled=false;
        }
    }
}
