using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SimpleAnimationPlayer : MonoBehaviour, IAnimationPlayer
    {
        [SerializeField] Animator anim;
        [SerializeField] string n;
        public void PlayAnimation()
        {
            anim.Play(n,0);
        }
    }
}
