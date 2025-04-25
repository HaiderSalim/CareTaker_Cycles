using UnityEngine;

[CreateAssetMenu(fileName = "Gun data", menuName = "Gun_info", order = 50)]
public class Gun_Info : ScriptableObject
{
    [Range(0.01f, 5f)]
    public float Fire_rate;
    [Range(5, 100), Tooltip("Sets the length of the raycast")]
    public float Range;
    public LayerMask Hit_effect_layer;
}
