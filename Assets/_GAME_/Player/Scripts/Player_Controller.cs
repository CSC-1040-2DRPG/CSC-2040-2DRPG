using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase] //Selects game objects that has this script on it when clicking any of the subobjects in the scene

//Use #region (press tab) to act as dividers to keep your code neat

public class Player_Controller : MonoBehaviour
{
    #region EditorData
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;  //High because multiplying by time.DeltaTime to accomodate for multiplayer diff fps

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;    

    #endregion


    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate() //For Physics System
    {
        MovementUpdate(); //In Physics System
    }

    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

        //print(_moveDir);   --> for testing purposes to make sure game is intaking the Inputs correctly
    }

    #endregion

    #region Movement Logic
        private void MovementUpdate()
    {
        _rb.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime; 
    }
    #endregion


}
