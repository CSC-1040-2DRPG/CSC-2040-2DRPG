using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_mana : MonoBehaviour
{
    
    
        public Slider manaSlider;
        public float maxmana = 100f;
        public float mana;

        void Start()
        {
            mana = maxmana;
        }

        void Update()
        {
            if (manaSlider.value != mana)
            {
                manaSlider.value = mana;
            }
        }

        public void SetHealth(float newMana)
        {
            mana = newMana;
        }
    
}
