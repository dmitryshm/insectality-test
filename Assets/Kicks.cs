using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicks : StateMachineBehaviour
{
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("LowJump 1"))
        {
            RootMotion.Demos.MechSpider obj = animator.gameObject.GetComponent<RootMotion.Demos.MechSpider>();
            if (obj != null)
            {
                obj.enabled = false;
                foreach(RootMotion.Demos.MechSpiderLeg leg in obj.legs)
                {
                    leg.enabled = false;
                    RootMotion.FinalIK.IK ik = leg.GetComponentInParent<RootMotion.FinalIK.IK>();
                    if (ik != null)
                    {
                        ik.enabled = false;
                    }
                }
            }
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Idle 1"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("LegFKick", true);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetBool("LowJump", true);
            }
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Leg F Kick"))
        {
            animator.SetBool("LegFKick", false);
        }
        else if (stateInfo.IsName("LowJump 1"))
        {
            animator.SetBool("LowJump", false);
            RootMotion.Demos.MechSpider obj = animator.gameObject.GetComponent<RootMotion.Demos.MechSpider>();
            if (obj != null)
            {
                foreach (RootMotion.Demos.MechSpiderLeg leg in obj.legs)
                {
                    RootMotion.FinalIK.IK ik = leg.GetComponentInParent<RootMotion.FinalIK.IK>();
                    if (ik != null)
                    {
                        ik.enabled = true;
                    }
                    leg.enabled = true;
                }
                obj.enabled = true;
            }
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
