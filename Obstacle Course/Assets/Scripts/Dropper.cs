using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] float timeToWait = 5f;
    private MeshRenderer mMeshRenderer;
    private Rigidbody mRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        mMeshRenderer = GetComponent<MeshRenderer>();
        mRigidbody = GetComponent<Rigidbody>();
        mMeshRenderer.enabled = false;
        mRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait) {
            mMeshRenderer.enabled = true;
            mRigidbody.useGravity = true;
        }
    }
}
