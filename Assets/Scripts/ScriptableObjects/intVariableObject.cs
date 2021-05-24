using UnityEngine;

[CreateAssetMenu(fileName = "IntObject", menuName = "ScriptableObjects/IntObject")]
public class intVariableObject : ScriptableObject, ISerializationCallbackReceiver
{
    int value;

    [SerializeField]
    int startValue;

    public int Value
    {
        get { return value; }
        set { value = Value; }
    }

    public void OnAfterDeserialize()
    {
        value = startValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
