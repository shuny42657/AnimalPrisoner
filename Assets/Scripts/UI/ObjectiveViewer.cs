using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ObjectiveViewer : MonoBehaviour
    {
        [SerializeField] ImageSetter item1Image; public ImageSetter Item1Image { get { return item1Image; }}
        [SerializeField] ImageSetter item2Image; public ImageSetter Item2Image { get { return item2Image; } }
        [SerializeField] ImageSetter craftItemImage; public ImageSetter CraftItemImage { get { return craftItemImage; } }
        [SerializeField] ImageSetter effectImage; public ImageSetter EffectImage { get { return effectImage; } }
        [SerializeField] TextSetter item1qty; public TextSetter Item1Qty { get { return item1qty; } }
        [SerializeField] TextSetter item2qty; public TextSetter Item2Qty { get { return item2qty; } }
        
    }
}
