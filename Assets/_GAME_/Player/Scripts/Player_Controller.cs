using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase] //Selects game objects that has this script on it when clicking any of the subobjects in the scene

//Use #region (press tab) to act as dividers to keep your code neat

public class Player_Controller : MonoBehaviour
{
    #region Enums (to assign words affectively to represent numbers
    private enum Directions {UP, DOWN, LEFT, RIGHT }
    #endregion

    #region EditorData
    [Header("Movement Attributes")]      
    [SerializeField] float _moveSpeed = 5f;  //High because multiplying by time.DeltaTime to accomodate for multiplayer diff fps

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] float sprintMultiplier = 2f;
 


    #endregion


    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    private Directions _facingDirection = Directions.RIGHT;

    private readonly int _animMoveRight = Animator.StringToHash("Anim_Player_Move_Right");
    private readonly int _animIdleRight = Animator.StringToHash("Anim_Player_Idle_Right");
    private readonly int _animMoveUp = Animator.StringToHash("Anim_Player_Move_Up");
    private readonly int _animMoveDown = Animator.StringToHash("Anim_Player_Move_Down");
    private bool _isSprinting;
    private float finalMoveSpeed;
     

    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
    }

    private void FixedUpdate() //For Physics System
    {
        finalMoveSpeed = _moveSpeed;
        if(_isSprinting) {
            finalMoveSpeed = _moveSpeed * sprintMultiplier;
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
        //.normalized normalizes for diagnoals so its smooth and even
        //Time.fixedDeltaTime insures player speed is consistant regardless of FPS
        //multiplying by 50 speeds up the movement so it is equal to what it would be without Time.fixedDeltaTime
        _rb.velocity = _moveDir.normalized * finalMoveSpeed * (Time.fixedDeltaTime * 50); 
    }
    #endregion

    #region Animation Logic
    private void CalculateFacingDirection()
    {
        if (_moveDir.y != 0)
        {
            if (_moveDir.y > 0)
            {
                _facingDirection = Directions.UP;
            }
            if (_moveDir.y < 0)
            {
                _facingDirection = Directions.DOWN;
            }
        }
        if (_moveDir.x != 0)
        {
            if (_moveDir.x >0) //Moving Right
            {
                _facingDirection = Directions.RIGHT;
            }
            else if  (_moveDir.x < 0) //Moving Left
            {
                _facingDirection = Directions.LEFT;
            }
        }
       // Debug.Log(_facingDirection); To see if we are facing the right way
    }

    private void UpdateAnimation()
    {
        if (_facingDirection == Directions.LEFT)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_facingDirection == Directions.RIGHT)
        {
            _spriteRenderer.flipX = false;
        }

        if(_moveDir == Vector2.zero){
            _animator.speed = 0;
        } else {
            _animator.speed = 1;
        }


        if(_moveDir.x != 0) // If we're Moving horizontally
        {
            _animator.CrossFade(_animMoveRight, 0);
        }
        else if (_moveDir.y > 0) // If we're Moving up
        {
            _animator.CrossFade(_animMoveUp, 0);
        }
        else if (_moveDir.y < 0) // If we're Moving down
        {
            _animator.CrossFade(_animMoveDown, 0);
        }
    }

    #endregion


}