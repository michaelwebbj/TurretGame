using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A shot
/// </summary>
public class Shot : MonoBehaviour
{
    /// <summary>
    /// Applies the given force vector to the shot
    /// </summary>
    /// <param name="forceVector">force vector to apply</param>
    public void ApplyImpulseForce(Vector2 forceVector)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(forceVector, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Called on a collision
    /// </summary>
    /// <param name="collision">collision info</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
