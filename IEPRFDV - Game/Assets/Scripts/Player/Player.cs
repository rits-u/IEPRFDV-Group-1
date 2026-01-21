using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private float HP;
    [SerializeField] private float ATK;

    public float Health
    {
        get => HP;
        set => HP = value;
    }
}
