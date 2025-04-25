using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Connector : MonoBehaviour
{
    public GlobalValues.Connectors connector;

    public Transform bulbPos;
    public Transform wirePos;

    void OnCollisionEnter(Collision collision)
    {
        Bulb bulb = collision.gameObject.GetComponent<Bulb>();
        if (bulb != null)
        {
            if (bulb.type.ToString() == connector.ToString())
            {
                bulb.SetColor();
                bulb.SetPosition(bulbPos.position);
            }
        }

        Wire wire = collision.gameObject.GetComponent<Wire>();
        if (wire != null)
        {
            wire.SetColor();
            Debug.Log("Wire color set to 1f");
            wire.SetPosition(wirePos.position);
        }
    }

}
