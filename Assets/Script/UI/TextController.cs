using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour
{
    public GameObject dialogue1_pool_prefab;
    public GameObject dialogue2_pool_prefab;
    public GameObject tip_pool_prefab;

    private GameObject dialogue1_pool_obj;
    private GameObject dialogue2_pool_obj;
    private GameObject tip_pool_obj;

    private Dialogue1Pool dialogue1_pool;

    // Use this for initialization
    void Start()
    {
        dialogue1_pool_obj = Instantiate(dialogue1_pool_prefab);
        dialogue1_pool_obj.transform.SetParent(transform.parent);

        dialogue2_pool_obj = Instantiate(dialogue2_pool_prefab);
        dialogue2_pool_obj.transform.SetParent(transform.parent);

        tip_pool_obj = Instantiate(tip_pool_prefab);
        tip_pool_obj.transform.SetParent(transform.parent);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Destroy(dialogue1_pool_obj);
        Destroy(dialogue2_pool_obj);
        Destroy(tip_pool_obj);
    }
}
