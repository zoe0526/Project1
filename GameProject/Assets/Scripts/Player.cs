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

        mAnimator.SetBool("ISWalk", false);
        Vector3 Move = new Vector3(horizontal, 0, vertical);
        Move = Move.normalized * mSpeed;
        
        mRB.transform.position += Move * Time.deltaTime;
        mRB.transform.LookAt(mRB.transform.position);
        Vector3 lookdir = vertical * Vector3.forward + horizontal * Vector3.right;

        mRB.transform.rotation = Quaternion.LookRotation(lookdir);
        if(Move!=Vector3.zero)
        {
            mAnimator.SetBool("ISWalk", true);
        }
        
        
	}
}
