using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGen : MonoBehaviour
{
    Color color;
    void Start()
    {
       color = gameObject.GetComponent<MeshRenderer>().materials[2].GetColor("_EmissionColor");
        gameObject.GetComponent<MeshRenderer>().materials[2].SetColor("_EmissionColor", new Color(0, 0, 0, 0));
    }
    public void SetColor()
    {
        gameObject.GetComponent<MeshRenderer>().materials[2].SetColor("_EmissionColor", color);
    }
}
