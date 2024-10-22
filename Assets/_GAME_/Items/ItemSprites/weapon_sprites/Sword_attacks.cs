using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_attacks : MonoBehaviour
{
    public Animator animator;
    public string sword_swing;
    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&& !hasPlayed)
        {
            animator.Play(sword_swing,0);
            hasPlayed = true;
        }
    }
}
