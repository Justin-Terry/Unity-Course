using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
 
    private int score = 0;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Hit") {
            GetComponent<MeshRenderer>().material.color = Color.red;
            score++;
            Debug.LogFormat("Score: {0}", score);
        }
    }
}
