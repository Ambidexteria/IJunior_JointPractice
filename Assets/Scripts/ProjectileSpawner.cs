using UnityEngine;

public class ProjectileSpawner : GenericSpawner<Projectile>
{
    [SerializeField] private Transform _spawnPosition;

    protected override void PrepareForSpawn(ref Projectile projectile)
    {
        projectile.transform.position = _spawnPosition.position;
    }

    protected override void PrepareForDespawn(ref Projectile projectile)
    {
            projectile.Rigidbody.velocity = Vector3.zero;
    }
}
