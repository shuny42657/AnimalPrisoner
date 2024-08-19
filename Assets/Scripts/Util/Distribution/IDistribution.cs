using System;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public interface IDitribution<T>
    {
        public T Sample(System.Random random);
    }

    public class CategoricalDistribution : IDitribution<int>
    {
        List<int> dists = new();

        public CategoricalDistribution(List<int> dists)
        {
            this.dists = dists;
        }
        public int Sample(System.Random random)
        {
            int total = 0;
            foreach(var d in dists)
            {
                total += d;
            }
            Debug.Log($"total : {total}");
            var rand = UnityEngine.Random.Range(0, total);
            Debug.Log($"rand : {rand}");
            total = 0;
            for(int i = 0; i < dists.Count; i++)
            {
                if(rand >= total && rand < total + dists[i])
                {
                    return i;
                }
                else
                {
                    total += dists[i];
                }
            }
            throw new Exception("Invalid cumulative distribution");
        }
    }

    public class FrozenDistribution : IDitribution<int>
    {
        public int Sample(System.Random random)
        {
            return 0;
        }
    }
}
