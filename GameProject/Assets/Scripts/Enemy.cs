using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody mRB;
    [SerializeField]
    private float mSpeed;
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
        StartCoroutine(EnemRoutine());
    }

    private IEnumerator EnemRoutine()
    {
        WaitForSeconds OneSec = new WaitForSeconds(1f);
        while(true)
        {
            int RandDir = Random.Range(0, 2);
            if(RandDir==0)
            {
                mRB.velocity += Vector3.forward * mSpeed;
                
            }
            else
            {
                mRB.velocity += Vector3.forward * -mSpeed;
               
            }
            yield return OneSec;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
