using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rotating, shooting turret
/// </summary>
public class Turret : MonoBehaviour
{
    [SerializeField]
    GameObject prefabShot;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
        // get mouse world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // calculate angle between turret and mouse position
        float deltaX = mousePosition.x - transform.position.x;
        float deltaY = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;

        // reset turret to no rotation, then rotate by angle
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward, angle);

        // fire shot toward mouse position if left mouse down
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate<GameObject>(prefabShot,
                transform.position,
                Quaternion.identity);
            Shot shotScript = shot.GetComponent<Shot>();
            angle *= Mathf.PI / 180;
            const float forceMagnitude = 10.0f;
            Vector2 forceVector = new Vector2(
                Mathf.Cos(angle) * forceMagnitude,
                Mathf.Sin(angle) * forceMagnitude);
            shotScript.ApplyImpulseForce(forceVector);
        }
    }
}
