using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBoardInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    void Update()
    {
        playerMovement.MoveTo(Wii.GetCenterOfBalance(0));
    }
}
