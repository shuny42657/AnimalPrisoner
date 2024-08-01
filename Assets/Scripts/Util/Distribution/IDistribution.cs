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
        List<float> dists = new();

        public CategoricalDistribution(List<float> dists)
        {
            this.dists = dists;
        }
        public int Sample(Random random)
        {
            var rand = random.NextDouble();

            for(int i = 0; i < dists.Count; i++)
            {
                if(rand > dists[i] && rand <= dists[i])
                {
                    return i;
                }
            }
            throw new Exception("Invalid cumulative distribution");
        }
    }
}
