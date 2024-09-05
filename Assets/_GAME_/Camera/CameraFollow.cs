using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region EditorData
    [Header("Camera Attributes")]
    [SerializeField] public float FollowSpeed = 5f;
    [SerializeField] public Transform target;
    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}