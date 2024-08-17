using System;
using System.Collections.Generic;

namespace Util
{
    public interface IDitribution<T>
    {
        public T Sample(Random random);
    }

    public class CategoricalDistribution : IDitribution<int>
    {
        List<int> dists = new();

        public CategoricalDistribution(List<int> dists)
        {
            this.dists = dists;
        }
        public int Sample(Random random)
        {
            /*var rand = random.NextDouble();

            for(int i = 0; i < dists.Count; i++)
            {
                if(rand > dists[i] && rand <= dists[i])
                {
                    return i;
                }
            }
            throw new Exception("Invalid cumulative distribution");*/

            int total = 0;
            foreach(var d in dists)
            {
                total += d;
            }
            var rand = UnityEngine.Random.Range(0, total);
            total = 0;
            for(int i = 0; i < dists.Count; i++)
            {
                if(rand > total && rand <= total + dists[i])
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
        public int Sample(Random random)
        {
            return 0;
        }
    }
}
