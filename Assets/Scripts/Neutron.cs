using UnityEngine;

public class Neutron : MonoBehaviour, INuclion
{
    [SerializeField] private float nuclionsAttractionForce;
    [SerializeField] private float attractionForce;
    [SerializeField] private float repulsionRadius;
    [SerializeField] private float repulsionForce;

    private Rigidbody _rb;
    public Rigidbody RB => _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 resultedForce = new Vector3();
        Collider[] nearbyNuclions = Physics.OverlapSphere(gameObject.transform.position, repulsionRadius);
        foreach (var item in nearbyNuclions)
        {
            INuclion nuclion = null;

            if (item.TryGetComponent<Neutron>(out Neutron nt))
            {
                nuclion = nt;
            }
            if (item.TryGetComponent<Proton>(out Proton pr))
            {
                nuclion = pr;
            }

            resultedForce += nuclion.RB.transform.position - transform.position;
            resultedForce *= attractionForce;
            nuclion?.RB.AddForce(-resultedForce, ForceMode.Force);
            RB.AddForce(resultedForce, ForceMode.Force);
        }
    }
}
