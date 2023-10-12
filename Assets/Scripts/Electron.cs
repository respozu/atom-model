using UnityEngine;

public class Electron : MonoBehaviour
{
    [SerializeField] private float radiusMod;
    [SerializeField] private float speedMod;

    private float startDiff;

    private void Start()
    {
        startDiff = Random.value * 7;
    }

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Sin(Time.time * speedMod + startDiff) * radiusMod;
        newPos.z = Mathf.Cos(Time.time * speedMod + startDiff) * radiusMod;
        transform.position = newPos;
    }

    public void Initialize(float radius, float speed)
    {
        radiusMod = radius;
        speedMod = speed;
    }
}
