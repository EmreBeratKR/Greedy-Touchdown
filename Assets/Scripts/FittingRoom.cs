using ScriptableEvents.Core.Channels;
using UnityEngine;

public class FittingRoom : MonoBehaviour
{
    private const string UniformNumberKey = "Uniform_Number";
    private const string PlayerTypeKey = "Player_Type";
    private const string IsPlayerCustomizedKey = "Is_Player_Customized";

    private const int MinUniformNumber = 1;
    private const int MaxUniformNumber = 20;


    [Header("Event Channels")]
    [SerializeField] private VoidEventChannel uniformNumberChanged;
    [SerializeField] private VoidEventChannel playerTypeChanged;
    [SerializeField] private VoidEventChannel fittingRoomAutoSkipped;
    
    
    public static int UniformNumber
    {
        get => PlayerPrefs.GetInt(UniformNumberKey, 1);
        private set => PlayerPrefs.SetInt(UniformNumberKey, value);
    }
    
    public static int PlayerType
    {
        get => PlayerPrefs.GetInt(PlayerTypeKey, 0);
        private set => PlayerPrefs.SetInt(PlayerTypeKey, value);
    }

    public static bool IsCharacterCustomized
    {
        get => PlayerPrefs.GetInt(IsPlayerCustomizedKey, 0) != 0;
        private set => PlayerPrefs.SetInt(IsPlayerCustomizedKey, value ? 1 : 0);
    }


    private void Start()
    {
        if (IsCharacterCustomized)
        {
            fittingRoomAutoSkipped.RaiseEvent();
        }
    }

    public void ChangeUniformNumber(int delta)
    {
        var newUniformNumber = UniformNumber + delta;
        UniformNumber = Mathf.Clamp(newUniformNumber, MinUniformNumber, MaxUniformNumber);
        IsCharacterCustomized = true;
        uniformNumberChanged.RaiseEvent();
    }

    public void ChangePlayerType(int typeId)
    {
        PlayerType = typeId;
        IsCharacterCustomized = true;
        playerTypeChanged.RaiseEvent();
    }
}
