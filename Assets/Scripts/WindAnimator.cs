using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimator : MonoBehaviour
{

	Animator m_Animator;
    public float animSpeed = 10f;

    public Wind gObj;

    // Start is called before the first frame update
    void Start()
    {
        gObj = GameObject.Find("Player").GetComponent<Wind>();

        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gObj.windIsBlowing)
        {
            StartCoroutine("PlayAnimation");
        }
    }

    IEnumerator PlayAnimation() {
        // if wind is blowing
        if (gObj.windIsBlowing == true) {
            m_Animator.speed = animSpeed;
            m_Animator.enabled = true;
            yield return new WaitForSeconds(1f);
            //Debug.Log("running coroutine");
            m_Animator.enabled = false;
        }

        
    }
}
