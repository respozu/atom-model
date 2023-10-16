using UnityEngine;

public class Proton : MonoBehaviour, INuclion
{
    [SerializeField] private float nuclionsAttractionForce;
    [SerializeField] private float attractionForce;
    [SerializeField] private float repulsionRadius;
    [SerializeField] private float repulsionMaxForce;

    private Rigidbody _rb;
    public Rigidbody RB => _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 resultedForce = Vector3.zero;
        Collider[] nearbyNuclions = Physics.OverlapSphere(gameObject.transform.position, repulsionRadius);
        foreach (var item in nearbyNuclions)
        {
            if (item.gameObject == this.gameObject) continue;

            INuclion nuclion = null;

            if (item.TryGetComponent<Neutron>(out Neutron nt))
            {
                nuclion = nt;
                resultedForce = item.transform.position -= transform.position;
                resultedForce *= attractionForce;

            }
            else if (item.TryGetComponent<Proton>(out Proton pr))
            {
                nuclion = pr;
                resultedForce = item.transform.position -= transform.position;
                resultedForce *= attractionForce;
            }

            nuclion?.RB.AddForce(resultedForce, ForceMode.Force);
             
            RB.AddForce(-resultedForce, ForceMode.Force);
        }
    }
}