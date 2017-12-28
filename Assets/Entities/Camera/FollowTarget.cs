using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to make a camera follow and rotate around a target
/// </summary>
/// <remarks>https://answers.unity.com/answers/600774/view.html</remarks>
public class FollowTarget : MonoBehaviour {

    public float TURN_SPEED = 2.0f;
    public Transform TARGET;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(TARGET.position.x, TARGET.position.y + 0.25f, TARGET.position.z + 0.75f);
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(GameManager.GetInstance().INPUTHANDLER.GetHorizontalCameraInput() * TURN_SPEED, Vector3.up) * offset;
        transform.position = TARGET.position + offset;
        transform.LookAt(TARGET.position);
    }
}
