using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food", order = 1)]
public class Food : ScriptableObject
{
    public string foodName;
    public int id;
    public Sprite sprite;
}
