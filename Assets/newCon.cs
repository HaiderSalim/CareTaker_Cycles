using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCon : MonoBehaviour
{
    Color color;
    void Start()
    {
        color = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));

    }

    public void SetColor()
    {
          gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        Debug.Log("Bulb color set to 1f");
    }
}
