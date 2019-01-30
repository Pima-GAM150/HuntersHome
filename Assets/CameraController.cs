using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Camera;

    public float speed = -.1f;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) Camera.transform.position = new Vector3(Camera.transform.position.x  - speed, 0, -1);
        if (Input.GetKey(KeyCode.D)) Camera.transform.position = new Vector3(Camera.transform.position.x + speed, 0, -1);
    }
}
