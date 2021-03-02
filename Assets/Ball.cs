using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Endgame")
        {
            Destroy(gameObject);
            Debug.Log("Congratulations! You Win!!!");
        }
    }
}
