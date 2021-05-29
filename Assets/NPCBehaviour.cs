using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{   
    private AnimateController animate;
    private void Awake() {
        animate = GetComponent<AnimateController>();
    }
    bool isMoving = false;
    void Update()
    {
        if(!isMoving && WannaMove()) {
            isMoving = true;
            Debug.Log("Move");
            animate.SetMoveState(AnimateState.Walk, AnimateDirectionByInput(PlayerInputController.GetHorizontalMove(), PlayerInputController.GetVerticalMove()));
        } else if(isMoving && !WannaMove()){
            Debug.Log("Stop");
            isMoving = false;
            animate.SetMoveState(AnimateState.Idle, AnimateDirection.Down);
        }
        /*if(Input.GetKeyDown(KeyCode.W)) animate.SetMoveState(AnimateState.Walk, AnimateDirection.Up);
        if(Input.GetKeyDown(KeyCode.D)) animate.SetMoveState(AnimateState.Walk, AnimateDirection.Right);
        if(Input.GetKeyDown(KeyCode.S)) animate.SetMoveState(AnimateState.Walk, AnimateDirection.Down);
        if(Input.GetKeyDown(KeyCode.A)) animate.SetMoveState(AnimateState.Walk, AnimateDirection.Left);*/
    }
    private void FixedUpdate() {
        
    }
    private bool WannaMove(){
        return PlayerInputController.GetHorizontalMove()!=0 || PlayerInputController.GetVerticalMove()!=0;
    }
    private AnimateDirection AnimateDirectionByInput(float horizontal, float vertical){
        if(Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
            return horizontal>0 ? AnimateDirection.Right : AnimateDirection.Left;
        } else{
            return vertical>0 ? AnimateDirection.Up : AnimateDirection.Down;
        }
    }
}
