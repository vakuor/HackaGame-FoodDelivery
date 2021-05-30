using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCBehaviour : MonoBehaviour
{   
    [SerializeField] FoodStash foodStash;
    private AnimateController animate;
    private new Rigidbody2D rigidbody2D;
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
        if(GameManager.instance.gameOver.active == false) {
        movement.x = PlayerInputController.GetHorizontalMove();
        movement.y = PlayerInputController.GetVerticalMove();
        animate.SetSpeed(rigidbody2D.velocity.sqrMagnitude);
        animate.SetDirections(movement.y, movement.x);       
        /*if(Input.GetKeyDown(KeyCode.Z))
            foodStash.PushFood(testFood);
        if(Input.GetKeyDown(KeyCode.X))
            foodStash.PopFood();
        if(Input.GetKeyDown(KeyCode.C))
            DropFood();
        if(Input.GetKeyDown(KeyCode.V))
            PickFood();
        if(Input.GetKeyDown(KeyCode.B))
            Pick();
        if(Input.GetKeyDown(KeyCode.G))
            GiveFood();*/
        if(Input.GetKeyDown(KeyCode.Q))
            Pick();
        if(Input.GetKeyDown(KeyCode.E))
            if(!GiveFood()) DropFood();
        } else {
            movement.x = 0;
            movement.y = 0;
        }
    }
    [SerializeField] GameObject foodPrefab;
    private void DropFood(){
        Food popFood = foodStash.PopFood();
        if(popFood==null) return;
        SpawnGroundFood(foodPrefab, popFood, transform.position);
        /*GameObject instance = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        GroundFood food = instance.GetComponent<GroundFood>();
        food.food = popFood;*/
    }
    private bool GiveFood(){
        PCPNCBehaviour pc = GetClosest<PCPNCBehaviour>();
        if(pc==null) return false;
        if(!pc.CanTakeFood()) return false;
        Food popFood = foodStash.PopFood();
        if(popFood==null) return false;
        
        return pc.TakeFood(popFood);
    }
    private void SpawnGroundFood(GameObject foodPrefab, Food popFood, Vector2 position){
        GameObject instance = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        GroundFood food = instance.GetComponent<GroundFood>();
        food.food = popFood;
    }
    [Obsolete]
    private void PickFood(){
        GroundFood found = GetClosestFood();
        if(found==null) return;
        if(foodStash.PushFood(found.food)) Destroy(found.gameObject);
    }
    private void Pick(){
        if(!CanPick()) { return; }
        Pickable found = GetClosest<Pickable>();
        if(found==null) { return; }
        if(!found.CanPick()){ return; }
        Food food = found.Pick() as Food;
        found.OnPicked();
        if(food==null) { Debug.Log("err3"); return; }
        foodStash.PushFood(food);
    }
    private bool CanPick(){
        return foodStash.CanPushFood();
    }
    private T GetClosest<T>() where T : Component /*, new()*/{
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(1f, 1.2f), 0, 1<<8);
        
        List<T> comps = new List<T>();
        foreach(Collider2D c in cols){
            T p = c.GetComponent<T>();
            if(p!=null)
            comps.Add(p);
        }
        T comp = StaticFuncs.GetClosestComponent(comps.ToArray(), transform.position) as T;
        if(comp!=null) {
            //Debug.Log(comp.name);
        }
        return comp;
    }

    [Obsolete]
    private GroundFood GetClosestFood(){
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1f, 1.2f), 0, 1<<8);
        if(colliders.Length<=0) { return null; }
        Collider2D closestCol = StaticFuncs.GetClosestComponent(colliders, transform.position) as Collider2D;
        if(closestCol==null) { return null; }
        return closestCol.GetComponent<GroundFood>();
    }
}
