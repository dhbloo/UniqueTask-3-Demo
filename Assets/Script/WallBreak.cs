using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour {

    public Vector3 MaxSpeed;
    Transform[] pieces;

	// Use this for initialization
	void Start () {
        pieces = GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
            breakWall();
    }

    void breakWall() {
        foreach (Transform piece in pieces) {
            if (piece == transform) continue;
            Rigidbody rb = piece.GetComponent<Rigidbody>();
            Vector3 v = new Vector3(MaxSpeed.x * Random.Range(-1.0f, 1.0f), 
                MaxSpeed.y * Random.Range(-1.0f, 1.0f), 
                MaxSpeed.z * Random.Range(-1.0f, 1.0f));
            rb.AddForce(v, ForceMode.Impulse);
        }
    }
}
