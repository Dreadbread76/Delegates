using UnityEngine;

public delegate void ResourceGatherDelegate(Resource _resource);
public delegate void ResourceCountDelegate(int _count);
public class Resource : MonoBehaviour
{
    public int GoldValue { get { return baseGold + offsetGold; } }

    [SerializeField]
    private int baseGold;

    private int offsetGold;
    // Start is called before the first frame update
    void Start()
    {
        offsetGold = Random.Range(0, 10);
        GameManager.instance.RegisterResource(this);
    }

   
    private void OnMouseUpAsButton()
    {
        GameManager.instance.GatherResource(this);
        Destroy(gameObject);
    }
}
