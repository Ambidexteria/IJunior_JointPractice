using UnityEngine;

public class ForceApplyer : MonoBehaviour
{
    [SerializeField] private Rigidbody _target;
    [SerializeField] private float _force;
    [SerializeField] private float _breakingForceMultiplyer;

    public void ApplyForceAtForwardDirection()
    {
        _target.AddForce(_target.transform.forward * _force, ForceMode.Force);
    }

    public void ApplyForceWithMultiplyer()
    {
        _target.AddForce(_target.transform.forward * _force * _breakingForceMultiplyer, ForceMode.Force);
    }
}
