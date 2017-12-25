﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    public Transform ROOT_TRANSFORM;
    public float FORCE;

    private Rigidbody[] _rigidBodies;

	// Use this for initialization
	void Start () {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && _rigidBodies != null && _rigidBodies.Length != 0)
        {
            RaycastHit hit;
            Ray ray = new Ray(ROOT_TRANSFORM.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 1f))
            {
                /* Bounce direction should be part normal to surface below,
                 *  part player input. Currently using 2/3 : 1/3 ratio */

                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                Vector3 bounceVec = 0.666f * hit.normal + 0.333f * mouseRay.direction;

                foreach (Rigidbody rb in _rigidBodies)
                {
                    rb.AddForce(bounceVec.normalized * FORCE, ForceMode.Impulse);
                }
            }
        }
	}
}