using UnityEngine;

[CreateAssetMenu(fileName = "DataBaseManager", menuName = "Scriptable Object/DataBase", order = int.MaxValue)]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    public float Speed = 4f;
    public float JumpPower = 3f;
    public float Jumplimt = 7f;

    public float H_sco;
    public GameObject Poin;
    public GameObject Item;
    public GameObject Monster;
}
