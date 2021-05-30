using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    public virtual void OnPicked(){ Debug.Log("Picked!"); Destroy(gameObject); }
    public virtual Object Pick(){
        return null;
    }
    public virtual bool CanPick(){
        return false;
    }
}
