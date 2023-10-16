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
        Vector3 resultedForce = new Vector3();
        Collider[] nearbyNuclions = Physics.OverlapSphere(gameObject.transform.position, repulsionRadius);
        foreach (var item in nearbyNuclions)
        {
            if (item.gameObject == this.gameObject) continue;

            resultedForce = item.transform.position - transform.position;
            resultedForce *= attractionForce;

            if (item.TryGetComponent<Proton>(out Proton pr))
            {
                Vector3 repulsionForce = new Vector3(1f / resultedForce.x, 1f / resultedForce.y, 1f / resultedForce.z);

                resultedForce -= repulsionForce;
                pr.RB.AddForce(-resultedForce, ForceMode.Force);
            }

            if (item.TryGetComponent<Neutron>(out Neutron nt))
            {
                nt.RB.AddForce(-resultedForce);
            }

            RB.AddForce(resultedForce, ForceMode.Force);
        }
    }
}