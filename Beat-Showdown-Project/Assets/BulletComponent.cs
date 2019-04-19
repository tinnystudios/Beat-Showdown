using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public float Force = 10;

    public void Init(float force)
    {
        Force = force;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Force;
    }
}
