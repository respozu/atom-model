using TMPro;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class ProtonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject proton;
    [SerializeField] private TMP_Text text;

    public List<Proton> _list = new List<Proton>();

    private Rigidbody _rb;

    private int _count;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Spawn()
    {
        Vector3 pos = new Vector3(Random.value * 2 - 1, Random.value * 2 - 1, Random.value * 2 - 1);

        var pr = Instantiate(proton, pos, Quaternion.identity).GetComponent<Proton>();

        //pr.Initialize(_rb);
        _list.Add(pr);

        _count++;
        text.text = $"Protons: {_count}";
    }
}
