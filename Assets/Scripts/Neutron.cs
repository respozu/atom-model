using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutron : MonoBehaviour, INuclion
{
    [SerializeField] private float nuclionsAttractionForce;
    [SerializeField] private float attractionForce;
    [SerializeField] private float repulsionRadius;
    [SerializeField] private float repulsionForce;

    public Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 resultedForce = new Vector3();
        Collider[] nearbyNuclions = Physics.OverlapSphere(gameObject.transform.position, repulsionRadius);
        foreach (var item in nearbyNuclions)
        {
            if (item.gameObject == this.gameObject) continue;

            if ((item.transform.position - transform.position).magnitude >= 1f)
            {
                resultedForce = -(item.transform.position - transform.position);
                resultedForce *= repulsionForce;

            }
            else
            {
                resultedForce = item.transform.position - transform.position;
                resultedForce *= attractionForce;
            }

            RB.AddForce(resultedForce, ForceMode.Force);
        }
    }
}
