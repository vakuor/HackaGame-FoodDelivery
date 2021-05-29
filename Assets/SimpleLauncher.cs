using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleLauncher : MonoBehaviour
{
    NetworkManager manager;
    private void Start() {
        manager = GetComponent<NetworkManager>();
        manager.StartServer();
    }
}
