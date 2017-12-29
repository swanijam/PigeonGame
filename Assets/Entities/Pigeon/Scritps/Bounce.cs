using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Corwin Belser
/// <summary>
/// Attach to a GameObject to cause i
/// </summary>
public class Bounce : MonoBehaviour {

    public Transform ROOT_TRANSFORM;
    public float FORCE;
    public float BOUNCE_TRAUMA = 0.2f;

    private Rigidbody[] _rigidBodies;
    private Camera _mainCamera; /* CB: Changed from Camera.main to storing a reference, because the main camera is now disabled when the effectCamera is enabled */

	// Use this for initialization
	void Start () {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
        _mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.GetInstance().INPUTHANDLER.GetJumpInput() && _rigidBodies != null && _rigidBodies.Length != 0)
        {
            RaycastHit hit;
            Ray ray = new Ray(ROOT_TRANSFORM.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 1f))
            {
                /* Bounce direction should be part normal to surface below,
                 *  part player input. Currently using 2/3 : 1/3 ratio
                 */
                
                Ray mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

                Vector3 bounceVec = 0.666f * hit.normal + 0.333f * mouseRay.direction;

                foreach (Rigidbody rb in _rigidBodies)
                {
                    rb.AddForce(bounceVec.normalized * FORCE, ForceMode.Impulse);
                }

                /* Apply some camera shake trauma */
                GameManager.GetInstance().AddCameraTrauma(BOUNCE_TRAUMA);
            }
        }
	}
}
