using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class HostConnection : MonoBehaviour
{
    NetworkManager manager;
    public InputField ip_InputField;
   // public GameObject HostConnect_go;

    void Awake()
    {
        manager = GetComponent<NewNetWorkManager>();
    }

    public void HostFunction()
    {
        manager.StartHost();
       // HostConnect_go.SetActive(false);
    }

    public void ConnectFunction()
    {
        manager.networkAddress = ip_InputField.text;
        manager.StartClient();

        //HostConnect_go.SetActive(false);
    }
}