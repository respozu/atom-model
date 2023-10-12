using Unity.VisualScripting;
using UnityEngine;

public class Proton : MonoBehaviour, INuclion
{
    [SerializeField] private float nuclionsAttractionForce;
    [SerializeField] private float attractionForce;
    [SerializeField] private float repulsionRadius;
    [SerializeField] private float repulsionMaxForce;


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

            //if (item.TryGetComponent<Proton>(out Proton pr))
            //{
            //    Vector3 repulsionForce = protonRepulsionForce * (gameObject.transform.position - pr.transform.position);
            //    Vector3 correctedRepulsionForce = new Vector3(2f / repulsionForce.x, 2f / repulsionForce.y, 2f / repulsionForce.z);

            //    resultedForce += correctedRepulsionForce;
            //}

            //if (item.TryGetComponent<Neutron>(out Neutron nt))
            //{
            //    resultedForce += nuclionsAttractionForce * (item.transform.position - gameObject.transform.position);
            //}

            resultedForce = item.transform.position - transform.position;
            resultedForce *= attractionForce;

            if (item.TryGetComponent<Proton>(out Proton pr))
            {
                Vector3 repulsionForce = new Vector3(1f / resultedForce.x, 1f / resultedForce.y, 1f / resultedForce.z);
                //repulsionForce = Vector3.ClampMagnitude(resultedForce, repulsionMaxForce);

                resultedForce -= repulsionForce;
            }

            RB.AddForce(resultedForce, ForceMode.Force);


        }
    }
}