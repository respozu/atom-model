using UnityEngine;
using TMPro;

public class ElectronSpawner : MonoBehaviour
{
    [SerializeField] private GameObject electron;
    [SerializeField] private TMP_Text text;

    private int newRadius = 5;

    private int _count;

    public void Spawn()
    {
        var el = Instantiate(electron);
        float newSpeed = Mathf.Clamp((Random.value * 3), 0.5f, 3f) / (newRadius * 0.3f);
        newSpeed *= 10;
        el.GetComponent<Electron>().Initialize(newRadius, newSpeed);
        newRadius++;
        _count++;
        text.text = $"Electrons: {_count}";
    }
}
