using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimateState {
        Idle,
        Walk,
        Sit
    }
    public enum AnimateDirection {
        Up,
        Right,
        Down,
        Left
    }
public class AnimateController : MonoBehaviour
{
    
    [SerializeField] Animator animator;
    public void SetMoveState(AnimateState state, AnimateDirection direction){
        SetState(state);
        SetDirection(direction);
        ApplyAnimationChanges();
    }
    public void SetDirection(AnimateDirection direction){
        animator.SetInteger("direction", AnimateDirectionToNum(direction));
    }
    public void SetState(AnimateState state){
        animator.SetInteger("state", AnimateStateToNum(state));
    }
    public void ApplyAnimationChanges(){
        animator.SetTrigger("change");
    }
    public void SetSpeed(float speed){
        animator.SetFloat("speed", speed);
    }
    public void SetDirections(float vertical, float horizontal){
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("horizontal", horizontal);
    }
    public AnimateState NumToAnimateState(int state){
        switch(state){
            case 0:{
                return AnimateState.Idle;
            }
            case 1:{
                return AnimateState.Walk;
            }
            case 2:{
                return AnimateState.Sit;
            }
            default: return AnimateState.Idle;
        }
    }
    public int AnimateStateToNum(AnimateState state){
        switch(state){
            case AnimateState.Idle:{
                return 0;
            }
            case AnimateState.Walk:{
                return 1;
            }
            case AnimateState.Sit:{
                return 2;
            }
            default: return -1;
        }
    }
    public AnimateDirection NumToAnimateDirection(int direction){
        switch(direction){
            case 1:{
                return AnimateDirection.Up;
            }
            case 2:{
                return AnimateDirection.Right;
            }
            case 3:{
                return AnimateDirection.Down;
            }
            case 4:{
                return AnimateDirection.Left;
            }
            default: return AnimateDirection.Down;
        }
    }
    public int AnimateDirectionToNum(AnimateDirection direction){
        switch(direction){
            case AnimateDirection.Up:{
                return 1;
            }
            case AnimateDirection.Right:{
                return 2;
            }
            case AnimateDirection.Down:{
                return 3;
            }
            case AnimateDirection.Left:{
                return 4;
            }
            default: return -1;
        }
    }
}
