using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear
/// </summary>
public class TeddyBear : MonoBehaviour
{
    /// <summary>
    /// Use this for initialization 
    /// </summary>
    void Start()
    {
        // apply impulse force to get teddy bear moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
	}

    /// <summary>
    /// Handles a collision with another object
    /// </summary>
    /// <param name="collision">collision information</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // on collision with a shot, destroy both 
        // colliding game objects
        if (collision.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
        }
    }
}
