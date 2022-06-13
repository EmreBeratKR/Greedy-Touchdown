using NaughtyAttributes;
using UnityEngine;

public class ModelRandomizer : MonoBehaviour
{
    [Header("Body Material")]
    [SerializeField] private SkinnedMeshRenderer bodyRenderer;
    [SerializeField] private Material[] bodyMaterials;
    [SerializeField] private bool randomizeBodyMaterial;

    [SerializeField] private GameObject[] numbers;
    [SerializeField] private bool randomizeNumber;


    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void Randomize()
    {
        RandomizeBodyMaterial();
        RandomizeNumber();
    }

    private void RandomizeBodyMaterial()
    {
        if (!randomizeBodyMaterial) return;
        
        var randomBodyMaterial = bodyMaterials[Random.Range(0, bodyMaterials.Length)];
        bodyRenderer.material = randomBodyMaterial;
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
}
