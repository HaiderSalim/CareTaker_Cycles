using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Wire : MonoBehaviour, IConnectable
{

    public bool IsConnected { get; private set; }
    public void Connect()
    {
        IsConnected = false;
    }
    Color color;
    void Start()
    {
        color = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0, 0.5f));
  
    }

    public void SetColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        Debug.Log("Wire color set to 1f");
    }
    public void SetPosition(UnityEngine.Vector3 pos)
    {
            if(IsConnected==false)
            {
                gameObject.layer = 6;
            transform.position = pos;
              Debug.Log("Wire position set to YEss " + pos);
              IsConnected=true;
            }

    }
   
        
}
