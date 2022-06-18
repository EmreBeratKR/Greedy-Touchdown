using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Transform[] uniformNumberModels;
    [SerializeField] private Material[] playerTypeMaterials;


    private void Start()
    {
        LoadPlayerType();
        LoadUniformNumber();
    }

    public void OnPlayerTypeChanged()
    {
        LoadPlayerType();
    }

    public void OnUniformNumberChanged()
    {
        LoadUniformNumber();
    }

    private void LoadPlayerType()
    {
        var newPlayerType = FittingRoom.PlayerType;

        foreach (var renderer in renderers)
        {
            renderer.material = playerTypeMaterials[newPlayerType];
        }
    }

    private void LoadUniformNumber()
    {
        var newUniformNumber = FittingRoom.UniformNumber;
        var newUniformNumberAsIndex = newUniformNumber - 1;

        var index = 0;
        foreach (var uniformNumberModel in uniformNumberModels)
        {
            uniformNumberModel.gameObject.SetActive(index == newUniformNumberAsIndex);
            index++;
        }
    }
}
