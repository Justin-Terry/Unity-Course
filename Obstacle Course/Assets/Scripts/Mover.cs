using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start() {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
    }

    private void OnCollisionExit(Collision other) {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    void PrintInstructions() {
        Debug.Log("Instructions");
    }

    void MovePlayer() {
        // GetAxis() returns +1 for right and -1 for left
        float xChange = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zChange = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xChange, 0, zChange);
    }
}
