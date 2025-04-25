using UnityEngine;

public class Disableself : MonoBehaviour
{
    [SerializeField] private float delaycount;
    private float delaycounttemp;

    private void Start() {
        delaycounttemp = delaycount;
    }
    
    void FixedUpdate()
    {
        if (delaycount <= 0)
        {
            delaycount = delaycounttemp;
            gameObject.SetActive(false);
        }
        delaycount -= Time.deltaTime;
    }
}
