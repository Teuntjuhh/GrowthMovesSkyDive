using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovementFactor = 9f;
    private float verticalMovementFactor = 7;
    private Vector2 horizontalBounds = new Vector2(-9, 9);
    private Vector2 verticalBounds = new Vector2(-5, 5);

    private Ring currentRing;

    //Move the player to a position on the horizontal plane
    public void MoveTo(Vector2 input)
    {
        transform.position = new Vector3(input.x * horizontalMovementFactor, 0, input.y * verticalMovementFactor);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, horizontalBounds.x, horizontalBounds.y), 0, Mathf.Clamp(transform.position.z, verticalBounds.x, verticalBounds.y));
    }

    private void OnTriggerEnter(Collider other)
    {
        Ring ring = other.GetComponent<Ring>();
        if (ring)
        {
            if(currentRing != null)
            {
                currentRing.Deselect();
            }

            currentRing = ring;
        }
    }

}
