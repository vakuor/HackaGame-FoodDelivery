using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{   
    [SerializeField] FoodStash foodStash;
    private AnimateController animate;
    private Rigidbody2D rigidbody2D;
    public Food testFood;
    private void Awake() {
        animate = GetComponent<AnimateController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start() {
    }
    bool isMoving = false;
    bool animationDirty = false;
    AnimateDirection lastDir;
    Vector2 movement = new Vector2();
    float moveSpeed = 10f;
    private void FixedUpdate() {
        rigidbody2D.velocity = movement * moveSpeed;
    }
    void Update()
    {
        movement.x = PlayerInputController.GetHorizontalMove();
        movement.y = PlayerInputController.GetVerticalMove();
        animate.SetSpeed(rigidbody2D.velocity.sqrMagnitude);
        animate.SetDirections(movement.y, movement.x);       
        if(Input.GetKeyDown(KeyCode.Z))
            foodStash.PushFood(testFood);
        if(Input.GetKeyDown(KeyCode.X))
            foodStash.PopFood();
        if(Input.GetKeyDown(KeyCode.C))
            DropFood();
        if(Input.GetKeyDown(KeyCode.V))
            PickFood();
    }
    [SerializeField] GameObject foodPrefab;
    private void DropFood(){
        Food popFood = foodStash.PopFood();
        if(popFood==null) return;
        GameObject instance = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        GroundFood food = instance.GetComponent<GroundFood>();
        food.food = popFood;
    }
    private void PickFood(){
        GroundFood found = GetClosestFood();
        if(found==null) return;
        if(foodStash.PushFood(found.food)) Destroy(found.gameObject);
    }
    private GroundFood GetClosestFood(){
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1f, 1.2f), 0, 1<<8);
        if(colliders.Length<=0) { return null; }
        Collider2D closestCol = StaticFuncs.GetClosestComponent(colliders, transform.position) as Collider2D;
        if(closestCol==null) { return null; }
        return closestCol.GetComponent<GroundFood>();
    }
}
