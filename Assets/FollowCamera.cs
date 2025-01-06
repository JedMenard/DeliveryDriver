using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject targetToFollow;

    /// <summary>
    /// Sets the possition of this object to that of the followed object,
    /// minus a bit in the Z direction.
    /// </summary>
    void LateUpdate() => this.transform.position = targetToFollow.transform.position - new Vector3(0, 0, 10);
}
