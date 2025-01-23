using System.Collections;
using UnityEngine;

public class SpringJointCatapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private float _fireForce;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _drawbackForce;
    [SerializeField] private Transform _drawbackPoint;
    [SerializeField] private float _reloadTime;

    private WaitForSeconds _waitReload;
    private bool _isReloading = false;
    private bool _isReadyToFire = true;

    private void Awake()
    {
        _waitReload = new WaitForSeconds(_reloadTime);
    }

    public void Fire()
    {
        if (_isReloading)
            return;

        if (_isReadyToFire == false)
            return;

        _springJoint.anchor = _firePoint.localPosition;
        _springJoint.spring = _fireForce;
        _springJoint.connectedBody.WakeUp();

        _isReadyToFire = false;
    }

    public void Reload()
    {
        if (_isReloading || _isReadyToFire)
            return;

        StartCoroutine(Drawback());
    }

    private IEnumerator Drawback()
    {
        _isReloading = true;

        _springJoint.anchor = _drawbackPoint.localPosition;
        _springJoint.spring = _drawbackForce;
        _springJoint.connectedBody.WakeUp();

        yield return _waitReload;

        _projectileSpawner.Spawn();

        _isReloading = false;
        _isReadyToFire = true;
    }
}
