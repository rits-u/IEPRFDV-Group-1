using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    public abstract void ActivateItem(Player p);

    public ItemType Type
    {
        get => type;
        set => type = value;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if(type == ItemType.Orb)
    //        {

    //        }
    //    }
}
