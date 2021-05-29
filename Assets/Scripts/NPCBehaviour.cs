using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{   
    [SerializeField] FoodStash foodStash;
    private AnimateController animate;
    private Rigidbody2D rigidbody2D;
    private void Awake() {
        animate = GetComponent<AnimateController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    bool isMoving = false;
    bool animationDirty = false;
    AnimateDirection lastDir;
    Vector2 movement = new Vector2();
    float moveSpeed = 10f;
    private void FixedUpdate() {
        rigidbody2D.velocity = movement * moveSpeed;
        //rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void Update()
    {
        movement.x = PlayerInputController.GetHorizontalMove();
        movement.y = PlayerInputController.GetVerticalMove();
        animate.SetSpeed(rigidbody2D.velocity.sqrMagnitude);
        animate.SetDirections(movement.y, movement.x);

        /*AnimateDirection directionCache = AnimateDirectionByInput(PlayerInputController.GetHorizontalMove(), PlayerInputController.GetVerticalMove());
        if(lastDir!=directionCache){
            animate.SetDirection(directionCache);
            animationDirty = true;
            Debug.Log("dir");
        }
        if(!isMoving && WannaMove()) {
            isMoving = true;
            animate.SetState(AnimateState.Walk);
            animationDirty = true;
            Debug.Log("move");
          } else if(isMoving && !WannaMove()){
            Debug.Log("stop");
            isMoving = false;
            animate.SetState(AnimateState.Walk);
            animationDirty = true;
            //animate.SetMoveState(AnimateState.Idle, AnimateDirection.Down);
        }
        if(animationDirty) animate.ApplyAnimationChanges();*/
        
    }
    /*private bool WannaMove(){
        return PlayerInputController.GetHorizontalMove()!=0 || PlayerInputController.GetVerticalMove()!=0;
    }*/
    /*private AnimateDirection AnimateDirectionByInput(float horizontal, float vertical){
        if(Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
            return horizontal>0 ? AnimateDirection.Right : AnimateDirection.Left;
        } else{
            return vertical>0 ? AnimateDirection.Up : AnimateDirection.Down;
        }
    }*/
}
