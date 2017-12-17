using UnityEngine;
using System.Collections;

public class InteractionCubeE : InteractionBase
{
    protected GameObject cube_E;
    public Vector3 cube_E_offset;

    protected override void Start()
    {
        cube_E = Instantiate(GameObject.FindGameObjectWithTag("CubeE"));
        cube_E.transform.SetParent(transform);
        cube_E.transform.localPosition = cube_E_offset;
        cube_E.SetActive(false);
    }

    protected override void Update()
    {

    }

    protected override void OnDestroy()
    {
        Destroy(cube_E);
    }

    public override void SetActive(bool _active)
    {
        base.SetActive(_active);

        cube_E.SetActive(_active);
    }
}
