using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStash : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] sprites;
    Stack<Food> foodStack = new Stack<Food>();
    [SerializeField] public int maxFood = 4;
    public bool PushFood(Food food){
        if(!CanPushFood()) return false;
        foodStack.Push(food);
        Debug.Log(foodStack.Count-1);
        if(foodStack.Count-1>=0 && foodStack.Count-1<sprites.Length)
            sprites[foodStack.Count-1].sprite = food.sprite;
        return true;
    }
    public Food PopFood(){
        if(!CanPopFood()) return null;
        if(foodStack.Count-1>=0 && foodStack.Count-1<sprites.Length)
            sprites[foodStack.Count-1].sprite = null;
        return foodStack.Pop();
    }
    public bool CanPushFood(){
        if(foodStack.Count >= maxFood) return false;
        return true;
    }
    public bool CanPopFood(){
        if(foodStack.Count <= 0) return false;
        return true;
    }
}
