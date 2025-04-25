using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bulb : MonoBehaviour, IConnectable
{
    public GlobalValues.Bulbs type;
    Color color;
    public bool IsConnected { get; private set; }
    public void Connect()
    {
        IsConnected = false;
    }
    void Start()
    {
        color = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0, 0.5f));

    }

    public void SetColor()
    {
          gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        Debug.Log("Bulb color set to 1f");
    }
    public void SetPosition(Vector3 pos)
    {
        gameObject.layer = 6;
        transform.position = pos;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Bulb position set to YEss " + pos);
        
        IsConnected = true;

       

    }
}
