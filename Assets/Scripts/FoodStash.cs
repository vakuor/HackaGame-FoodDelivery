using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStash : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] sprites;
    Stack<Food> foodStack = new Stack<Food>();
    [SerializeField] int maxFood = 4;
    public bool PushFood(Food food){
        if(foodStack.Count >= maxFood) return false;
        foodStack.Push(food);
        sprites[foodStack.Count-1].sprite = food.sprite;
        return true;
    }
    public Food PopFood(){
        if(foodStack.Count <= 0) return null;
        sprites[foodStack.Count-1].sprite = null;
        return foodStack.Pop();
    }
}
