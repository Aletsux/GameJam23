using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraController camController;
    private bool passed = false;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            passed = true;
        }
    }

    public bool getPassed() {
        return passed;
    }
}
