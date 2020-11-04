using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private ResourceGatherDelegate gatherCallback;
    private ResourceCountDelegate countCallback;

    private List<Resource> resources = new List<Resource>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void RegisterResource(Resource _resource)
    {
        resources.Add(_resource);
    }
    /// <summary>
    /// Subscribes the passed function to the gather callback so that when a resource is gathered,
    /// the passed function runs
    /// </summary>
    /// <param name="_callback"></param> The function to run when a resource is gathered</param>
    public void ListenForResourceGather(ResourceGatherDelegate _callback)
    {
        gatherCallback += _callback;
    }

    /// <summary>
    /// Subscribes the passed function to the gather callback so that when a resource is counted,
    /// the passed function runs
    /// </summary>
    /// <param name="_callback"></param> The function to run when a resource is counted</param>
    public void ListenForResourceCount(ResourceCountDelegate _callback)
    {
        countCallback += _callback;
    }
    /// <summary>
    /// Runs the gather delegate and removes the resouce from the list when the resource is clicked on.
    /// </summary>
    /// <param name="_resource">The resource is being gathered</param>
    public void GatherResource(Resource _resource)
    {
        if (gatherCallback != null)
        {
            gatherCallback(_resource);
        }

        resources.Remove(_resource);
    }
    public void RequestResourceCount()
    {
        if (countCallback != null)
        {
            countCallback(resources.Count);
        }
    }
}
    
