using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Corwin Belser
/// <summary>
/// This script is used to apply camera effects.
/// Effects are done to a second camera, using it to render when an effect is desired
/// </summary>
/// <remarks>https://youtu.be/tu-Qe66AvtY</remarks>
public class CameraShake : MonoBehaviour {

    public static string ATTATCHED_TAG = "EffectCamera";

    public float TRAUMA_DRECREASE_RATE = 0.5f;
    public float MAX_YAW = 10f;
    public float MAX_PITCH = 10f;
    public float MAX_ROLL = 10f;
    public float MAX_OFFSET = 0.5f;

    private Camera _mainCamera;
    private Camera _effectCamera;
    private float _trauma;
    private float _seed;
    

	void Start () {
        _mainCamera = Camera.main;
        _effectCamera = this.GetComponent<Camera>();
        _trauma = 0f;
        _seed = Random.value;
	}
	
	void LateUpdate () {
        /* If the camera is under the influence of trauma, process camera shake */
        if (_trauma > 0f)
        {
            /* Move the effect camera to the main camera's position and rotation */
            _effectCamera.transform.SetPositionAndRotation(_mainCamera.transform.position, _mainCamera.transform.rotation);

            /* Generate shakyCamera positions using _trauma^2 */
            float shake = Mathf.Pow(_trauma, 2);
            float yaw = MAX_YAW * shake * Mathf.PerlinNoise(_seed, Time.time);
            float pitch = MAX_PITCH * shake * Mathf.PerlinNoise(_seed+1, Time.time);
            float roll = MAX_ROLL * shake * Mathf.PerlinNoise(_seed+2, Time.time);
            float offsetX = MAX_OFFSET * shake * Mathf.PerlinNoise(_seed+3, Time.time);
            float offsetY = MAX_OFFSET * shake * Mathf.PerlinNoise(_seed+4, Time.time);
            float offsetZ = MAX_OFFSET * shake * Mathf.PerlinNoise(_seed+5, Time.time);

            /* Move shakyCamera by the generated offsets */
            _effectCamera.transform.Rotate(pitch, yaw, roll);
            _effectCamera.transform.position += new Vector3(offsetX, offsetY, offsetZ);

            /* Render using the effect camera for this frame */
            _mainCamera.enabled = false;
            _effectCamera.enabled = true;

            /* Reduce trauma linearly */
            _trauma -= TRAUMA_DRECREASE_RATE * Time.deltaTime;
            _trauma = _trauma < 0f ? 0f : _trauma;
        }
        else
        {
            _mainCamera.enabled = true;
            _effectCamera.enabled = false;
        }
        
	}

    /// <summary>
    /// Increase the trauma being applied to the effect camera, causing shaking
    /// </summary>
    /// <param name="amount"> float [0,1] representing amount of trauma to add
    /// 0.2 is "small trauma"
    /// 0.5 is "medium trauma"
    /// 1.0 is "large trauma"
    /// </param>
    /// <remarks>This should be a static method or otherwise easily reachable by any GameObject</remarks>
    public void AddTrauma(float amount)
    {
        _trauma += amount;
        _trauma = _trauma > 1f ? 1f : _trauma;
    }
}
