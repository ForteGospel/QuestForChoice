using UnityEngine;

[CreateAssetMenu(fileName = "IntObject", menuName = "ScriptableObjects/IntObject")]
public class intVariableObject : ScriptableObject, ISerializationCallbackReceiver
{
    int value;

    [SerializeField]
    int startValue;

    [SerializeField]
    int maxValue;

    public int Value
    {
        get { return value; }
    }

    public void addValue(int num)
    {
        if (value + num <= maxValue || maxValue == 0)
            value += num;
    }

    public void minusValue (int num)
    {
        value -= num;
    }

    public void OnAfterDeserialize()
    {
        value = startValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
