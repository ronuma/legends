using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalForm : MonoBehaviour
{
    public Animator animator;
    private Camera mainCam;

    private bool canTranform = true;
    private float chargeTimer;
    private float chargeTime = 10f;

    public bool isTransformed;

    private float durationTimer;
    private float duration = 20f;
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTranform)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeTime)
            {
                canTranform = true;
                chargeTimer = 0;
            }
        }
       

        if (Input.GetKeyDown(KeyCode.E) && canTranform)
        {
            isTransformed = true;
            animator.SetBool("FinalForm", true);
            canTranform = false;

            GetComponent<PlayerStats>().playerDamage = GetComponent<PlayerStats>().playerDamage * 3;
            GetComponent<PlayerStats>().playerHealth = GetComponent<PlayerStats>().playerHealth * 3;
        }

        if (isTransformed)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer >= duration)
            {
                isTransformed = false;
                durationTimer = 0;
                animator.SetBool("FinalForm", false);
                GetComponent<PlayerStats>().playerDamage = GetComponent<PlayerStats>().playerDamage / 3;
                GetComponent<PlayerStats>().playerHealth = GetComponent<PlayerStats>().playerHealth / 3;
            }
        }
    }
}

