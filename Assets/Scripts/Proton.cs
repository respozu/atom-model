using UnityEngine;

public class Proton : MonoBehaviour, INuclion
{
    [SerializeField] private float nuclionsAttractionForce;
    [SerializeField] private float attractionForce;
    [SerializeField] private float repulsionRadius;
    [SerializeField] private float repulsionMaxForce;
    [SerializeField] private float charge;


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

            //resultedForce = item.transform.position - transform.position;
            //resultedForce *= attractionForce;

            //if (item.TryGetComponent<Neutron>(out Neutron nt))
            //{
            //    nt.RB.AddForce(-resultedForce);
            //}

            //if (item.TryGetComponent<Proton>(out Proton pr))
            //{
            //    Vector3 repulsionForce = new Vector3(1f / resultedForce.x, 1f / resultedForce.y, 1f / resultedForce.z);

            //    resultedForce -= repulsionForce;
            //    pr.RB.AddForce(-resultedForce, ForceMode.Force);
            //}

            {
                INuclion nuclion = null;

                if (item.TryGetComponent<Neutron>(out Neutron nt))
                {
                    nuclion = nt;
                    resultedForce += nuclion.RB.transform.position - transform.position;
                    resultedForce *= attractionForce;
                }
                else if (item.TryGetComponent<Proton>(out Proton pr))
                {
                    nuclion = pr;
                    float distance = Vector3.Magnitude(item.transform.position - transform.position);
                    Vector3 electromagneticForce = item.transform.position * ((pr.charge * this.charge) / Mathf.Pow(distance, 1));
                    resultedForce += electromagneticForce;
                }
                else continue;

                resultedForce += nuclion.RB.transform.position - transform.position;
                resultedForce *= attractionForce;
                nuclion?.RB.AddForce(-resultedForce, ForceMode.Force);
            }

            RB.AddForce(resultedForce, ForceMode.Force);
        }
    }
}