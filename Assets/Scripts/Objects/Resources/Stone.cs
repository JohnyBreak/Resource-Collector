using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : BaseResource
{
    public override void Collect()
    {
        Destroy(gameObject);
    }
}
