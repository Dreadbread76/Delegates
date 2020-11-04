using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.ListenForResourceGather(OnResourceGather);
        GameManager.instance.ListenForResourceCount(OnResourceCounted);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.RequestResourceCount();
        }
    }

    private void OnResourceGather(Resource _resource)
    {
        Debug.Log("Resource was worth: " + _resource.GoldValue);
    }

    private void OnResourceCounted(int _count)
    {
        Debug.Log("There are " + _count.ToString() + " resources remaining");
    }
}
