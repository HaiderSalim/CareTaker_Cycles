using System.Linq;
using DigitalRuby.LightningBolt;
using Unity.Mathematics;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [Header("Gun Data Objects"),SerializeField]//These are the Scriptable objects that tell hold all the info about the type of guns
    private Gun_Info Current_gun_info = null;

    [Header("Crosshair Fields")]
    public Vector3 Crosshair_pos_relative_to_viewport = new(0.5f, 0.5f, 0);
    public Transform Crosshair;

    [Header("Gravity Gun Fields")]
    public float holdDistance = 2f;
    public float objectMoveSpeed = 10f;
    Vector3 objectOffset = Vector3.zero; // offset in local camera space
    public float mouseSensitivity = 0.1f;
    public float scrollWheelAxis;

    [SerializeField]
    private LightningBoltScript lightningEffect;

    //Handlers
    // private First_Person_Handler first_Person_Data;
    // private Ui_Handler ui_Handler;
    // private Camera_effect_Handler camera_Effect_Handler;

    private Camera Cam;
    Vector2 mouseDelta;
    private float fireRateTemp;
    private ThirdPersonController playerCS;
    private GameObject currentHeldObject;
    private float originelHoldDistance = 2f;

    void Start()
    {
        playerCS = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        Cam = Camera.main;
        fireRateTemp = Current_gun_info.Fire_rate;
        originelHoldDistance = holdDistance;
    }

    void Update()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        objectOffset += new Vector3(mouseDelta.x, mouseDelta.y, 0f) * mouseSensitivity;
        scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");//get the mouse scroll wheel movement

        ObjectPickUp();
        ChageObjectHeldDistance();
    }

    void FixedUpdate()
    {
        if (!Current_gun_info)//Safty
            return;
        
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            var pos = Cam.ViewportToWorldPoint(Crosshair_pos_relative_to_viewport);
            if (fireRateTemp <= 0)
            {
                //Applay camera Efects
                fireRateTemp = Current_gun_info.Fire_rate;

                RaycastHit[] result = 
                Physics.RaycastAll(
                    pos,
                    Cam.transform.forward,
                    Current_gun_info.Range,
                    Current_gun_info.Hit_effect_layer
                );
                
                result = result.OrderBy(result => result.distance).ToArray();
                if (result.Length > 0 && currentHeldObject == null)
                {
                    //Applay Damage
                    var hit = result[0];
                    var Objectholdposition = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

                    Debug.Log("hit " + hit.collider.name);
                    currentHeldObject = hit.collider.gameObject;

                    hit.rigidbody.useGravity = false;
                    hit.transform.position = Objectholdposition;

                    // if (hit.rigidbody)
                    //     hit.rigidbody.AddForce(cam.transform.forward * 5f, ForceMode.Impulse);
                }

                playerCS.isShooting = true;
            }
        }
        fireRateTemp -= Time.deltaTime;
        
        if (Input.GetMouseButtonUp(0))
        {
            playerCS.isShooting = false;
            if (currentHeldObject)
                currentHeldObject.GetComponent<Rigidbody>().useGravity = true;

            currentHeldObject = null;
            holdDistance = originelHoldDistance;
        }
    }

    private void ObjectPickUp()
    {
        if (currentHeldObject != null)
        {
            Vector3 desiredWorldPosition = transform.position + 
                    Cam.transform.forward * holdDistance + 
                    transform.right  + 
                    Cam.transform.up ;

            currentHeldObject.transform.position = Vector3.Lerp(
                currentHeldObject.transform.position,
                desiredWorldPosition,
                Time.deltaTime * objectMoveSpeed
            );

            lightningEffect.EndObject.transform.position = currentHeldObject.transform.position;
            lightningEffect.Trigger();
        }
    }

    public void ChageObjectHeldDistance()
    {
        if (currentHeldObject != null)
        {
            if (scrollWheelAxis < 0f)
            {
                holdDistance -= 1;
            }
            else if (scrollWheelAxis > 0f)
            {
                holdDistance += 1;
            }

            holdDistance = math.clamp(holdDistance, 2, originelHoldDistance);
        }            
    }
}
