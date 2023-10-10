using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

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
            FollowPosition();
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

    private void FollowRotation()
    {
        transform.rotation = targetTransform.rotation;
    }
}
