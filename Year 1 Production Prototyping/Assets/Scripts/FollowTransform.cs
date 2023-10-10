using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float lerpRate;
    [SerializeField] private float slerpRate;

    [Header("Follow Parameters")]
    [SerializeField] private bool isFollowingPosition;
    [SerializeField] private bool isFollowingRotation;

    [Header("Lerp Parameters")]
    [SerializeField] private bool isLerpingPosition;
    [SerializeField] private bool isSlerpingRotation;

    void Update()
    {
        if (isFollowingPosition)
        {
            if (!isLerpingPosition)
            {
                FollowPosition();
            }
            
            else
            {
                FollowPositionLerp();
            }
        }

        if (isFollowingRotation)
        {
            FollowRotation();
        }
    }

    private void FollowPosition()
    {
        transform.position = targetTransform.position;
    }

    private void FollowPositionLerp()
    {
        Vector3 lerpPosition = targetTransform.position;
        lerpPosition.y = Mathf.Lerp(transform.position.y, targetTransform.position.y, lerpRate * Time.deltaTime);
        transform.position = lerpPosition;
    }

    private void FollowRotation()
    {
        transform.rotation = targetTransform.rotation;
    }

    private void FollowRotationSlerp()
    {

    }
}
