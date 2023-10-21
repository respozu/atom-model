using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public int Charge { get; set; }
    public int Neutrons { get; set; }

    [SerializeField]
    private List<Nuclion> _nuclions = new List<Nuclion>();

    public void AddNuclion(Nuclion nc)
    {
        Instantiate(nc, transform);
        _nuclions.Add(nc);
    }
}
