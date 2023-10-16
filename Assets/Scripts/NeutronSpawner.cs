using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class NeutronSpawner : MonoBehaviour
{
    [SerializeField] private GameObject neutron;
    [SerializeField] private TMP_Text text;

    private Rigidbody _rb;

    private int _count;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Spawn()
    {
        Vector3 pos = new Vector3(Random.value * 2 - 1, Random.value * 2 - 1, Random.value * 2 - 1);

        var pr = Instantiate(neutron, pos, Quaternion.identity);
        _count++;
        text.text = $"Neutrons: {_count}";
    }
}
