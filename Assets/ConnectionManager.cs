using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ConnectionManager : MonoBehaviour
{
    public GameObject mainGen;
    public List<Wire> wires;
    public List<Bulb> bulbs;
    public GameObject generatorEffect;
    private bool generatorIsLit = false;

    Color color,mainGenColor;
    void Start()
    {
        mainGenColor=mainGen.GetComponent<MeshRenderer>().materials[7].GetColor("_EmissionColor");
        mainGen.GetComponent<MeshRenderer>().materials[7].SetColor("_EmissionColor", new Color(0, 0, 0, 0.5f));
        color = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0, 0.5f));

    }

    public void SetColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        mainGen.GetComponent<MeshRenderer>().materials[7].SetColor("_EmissionColor", mainGenColor);
    }
    void Update()
    {
        if (!generatorIsLit && AreAllConnected(wires, 2) && AreAllConnected(bulbs, 3))
        {
            Debug.Log("All connected");
            LightGenerator();
        }
    }

    bool AreAllConnected(List<Bulb> items, int requiredCount)
    {
        int count = 0;
        foreach (var item in items)
        {
            
            if (item.IsConnected) count++;
        }
        return count >= requiredCount;
    }
     bool AreAllConnected(List<Wire> items, int requiredCount)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.IsConnected) count++;
        }
        return count >= requiredCount;
        
    }
    void LightGenerator()
    {
        generatorIsLit = true;
        SetColor();
    }
}
