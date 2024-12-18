using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[SelectionBase] //Selects game objects that has this script on it when clicking any of the subobjects in the scene

//Use #region (press tab) to act as dividers to keep your code neat

public class Player_Controller : MonoBehaviour, IDataPersistence
{
    private Rigidbody2D MyRigidbody2D;

    #region Enums (to assign words affectively to represent numbers
    private enum Directions {UP, DOWN, LEFT, RIGHT }
    #endregion

    #region EditorData
    [Header("Movement Attributes")]      
    [SerializeField] float _moveSpeed;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] float sprintMultiplier = 2f;

    public float dodgeDistance = 2.0f; // How far the player dodges
    public float doubleTapTime = 0.3f; // Time allowed between taps

    private float lastTapTime = -1f; // Tracks when the Shift key was last tapped


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
    private bool playerStop;

    public GameObject spellPrefab;
    public Transform spellSpawnPoint;

    public Transform lastBonfire;

    public void SetLastBonfire(Transform bonfire)
    {
        lastBonfire = bonfire;

        Debug.Log("Updated last bonfire to: " + bonfire.position);
    }




    #endregion

    #region Tick




    private void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
        DetectDoubleTap();


        // play death animation when health = 0
        if
           ( playerDataHandler.instance.GetComponentInChildren<Player_health>().isDead == true && playerDataHandler.instance.GetComponentInChildren<Player_health>().health == 0f )
        {
    
            _animator.CrossFade(Animator.StringToHash("player_death"), 1);

           
            Debug.Log("player died");
           
            //disable player controller after death 
            GetComponent<Player_Controller>().enabled = false;


        }



        // activate spell by pressing F
        if (Input.GetKeyDown(KeyCode.F))
        {
            
                CastSpell();
            
        }

        
    }

    public void CastSpell()
    {

   
        Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
   

    }



    private void FixedUpdate() //For Physics System
    {
        finalMoveSpeed = _moveSpeed;
        if(_isSprinting) {
            finalMoveSpeed = _moveSpeed * sprintMultiplier;
        }
        MovementUpdate(); //In Physics System

        //freezes player if in dialogue
        var dialogueManager = DialogueManager.GetInstance();
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
    }

    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);

        Inventory inventory = playerDataHandler.instance.inventory;

        if (Input.GetMouseButtonDown(0)) inventory.UseActive1();
        if (Input.GetMouseButtonDown(1)) inventory.UseActive2();

        if(Input.GetKeyDown(KeyCode.Tab)){
            gameObject.transform.Find("Canvas").transform.Find("InvScreen").GetComponent<UIDocument>().enabled = true;
            gameObject.transform.Find("Canvas").transform.Find("InvScreen").GetComponent<PlayerInvScreen>().enabled = true;
            enabled = false;
        }
        
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

 

    public void LoadData(GameData data){
        _moveSpeed = data.playerSpeed;
    }


    public void SaveData(GameData data){
        data.playerSpeed = _moveSpeed;
    }

    #endregion

    #region dodge
    private void DetectDoubleTap()
    {
        // Check for Shift key press
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Time.time - lastTapTime <= doubleTapTime)
            {
                Dodge(); // Call Dodge if double-tapped
               
            }

            
            lastTapTime = Time.time; // Update the last tap time
        }
    }

    private void Dodge()
    {
        // Get the player's current movement direction
        Vector3 dodgeDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized; 


        if (dodgeDirection == Vector3.zero) //if no movement, then simply go forward
        {
            dodgeDirection = transform.up;
        }

        transform.position += dodgeDirection * dodgeDistance;  // Move the player in the dodge direction


        //Debug.Log("Dodged in direction: " + dodgeDirection);

    }
    #endregion

  


}