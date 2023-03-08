using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class EmptyRaycast : Graphic
    {
        protected override void Start()
        {
            raycastTarget = true;
            useLegacyMeshGeneration = false;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}