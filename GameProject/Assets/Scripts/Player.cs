using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private int mSpeed;
    private Animator mAnimator;
    private Rigidbody mRB;
    
    // Use this for initialization
    void Start ()
    {
        mRB = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 fixeddir=new Vector3(0, 0, 0);
        mAnimator.SetBool("ISWalk", false);
        Vector3 Move = new Vector3(horizontal, 0, vertical);
        Move = Move.normalized * mSpeed;
        mRB.transform.position += Move * Time.deltaTime;

        Vector3 lookdir = vertical * Vector3.forward + horizontal * Vector3.right;
       
        fixeddir = lookdir;
        while (fixeddir == lookdir)
        {

            mRB.transform.rotation = Quaternion.LookRotation(fixeddir);
        }
        if (Move!=Vector3.zero)
        {
            mAnimator.SetBool("ISWalk", true);
        }
        
        
	}
}
