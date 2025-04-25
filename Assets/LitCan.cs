using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitCan : MonoBehaviour
{
    bool isLit = false;
    public GameObject[] bulbs;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision withsdadadasdadadasd " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Tree"))
        {
           bulbs[0].gameObject.GetComponent<newCon>().SetColor();
        }
        else if(collision.gameObject.CompareTag("TreeG"))
        {
            bulbs[1].GetComponent<newCon>().SetColor();
            isLit = true;
        }

    }
    void Update()
    {
        if(isLit)
        {
            bulbs[3].GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", new Color(255, 0, 0, 255));
            isLit=false;
        }
    }


}
