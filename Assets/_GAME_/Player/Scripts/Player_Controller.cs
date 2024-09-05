using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase] //Selects game objects that has this script on it when clicking any of the subobjects in the scene

//Use #region (press tab) to act as dividers to keep your code neat

public class Player_Controller : MonoBehaviour
{
    #region EditorData
    [Header("Movement Attributes")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintMultiplier = 2f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rb;    

    #endregion


    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    private bool _isSprinting;
    private float finalMoveSpeed;
    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate() //For Physics System
    {
        finalMoveSpeed = moveSpeed;
        if(_isSprinting) {
            finalMoveSpeed = moveSpeed * sprintMultiplier;
        }
        MovementUpdate(); //In Physics System
    }

    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);


        //print(_moveDir);   --> for testing purposes to make sure game is intaking the Inputs correctly
    }

    #endregion

    #region Movement Logic
        private void MovementUpdate()
    {
        // multiplied by fixedDeltaTime to get consistant speed regardless of framerate.
        //fixedDeltaTime multiplied to average out to ~1 
        rb.velocity = _moveDir * finalMoveSpeed * (Time.fixedDeltaTime * 50);
    }
    #endregion


}