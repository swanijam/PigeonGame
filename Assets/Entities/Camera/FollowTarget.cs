using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
/// </summary>
public class FollowTarget : MonoBehaviour {

    public Transform TARGET;
    private Vector3 _distance;

    private void Start()
    {
        _distance = TARGET.position - this.transform.position;
    }

    // Update is called once per frame
    void Update () {
		if (TARGET != null)
        {
            this.transform.position = TARGET.position - _distance;
        }
	}
}
