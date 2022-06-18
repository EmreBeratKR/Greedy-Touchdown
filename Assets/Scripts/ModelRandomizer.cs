using NaughtyAttributes;
using UnityEngine;

public class ModelRandomizer : MonoBehaviour
{
    [Header("Body Material")]
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Material[] bodyMaterials;
    [SerializeField] private bool randomizeBodyMaterial;

    [Header("Random Number by GameObject")]
    [SerializeField] private GameObject[] numbers;
    [SerializeField] private bool randomizeNumber;

    [Header("Random Number by Mesh")]
    [SerializeField] private MeshFilter numberMeshFilter;
    [SerializeField] private Mesh[] numberMeshes;
    [SerializeField] private bool randomizeNumberMesh;


    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void Randomize()
    {
        RandomizeBodyMaterial();
        RandomizeNumber();
        RandomizeNumberMesh();
    }

    private void RandomizeBodyMaterial()
    {
        if (!randomizeBodyMaterial) return;
        
        var randomBodyMaterial = bodyMaterials[Random.Range(0, bodyMaterials.Length)];

        foreach (var bodyRenderer in renderers)
        {
            bodyRenderer.material = randomBodyMaterial;
        }
    }
    
    private void RandomizeNumber()
    {
        if (!randomizeNumber) return;

        var randomNumber = Random.Range(0, numbers.Length);

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i].SetActive(i == randomNumber);
        }
    }

    private void RandomizeNumberMesh()
    {
        if (!randomizeNumberMesh) return;

        var randomMesh = numberMeshes[Random.Range(0, numberMeshes.Length)];
        numberMeshFilter.mesh = randomMesh;
    }
}
