using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpData : MonoBehaviour
{
    [Header("JumpInfo")]
    //Scale affects how long player stays airborne when they hit jump
    public float jumpHeightScale = 1.0f;

    //How much can the player be pushed forward when they hit jump
    public float jumpPushScale = 1.0f;
}
