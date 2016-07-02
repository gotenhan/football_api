using System.Collections.Generic;

namespace FootballApi.CrossCuting
{
    public interface IMapper<S, D>
    {
        D Map(S source);
        void Map(S source, D destination);
    }

    public class Mapper<S, D> : IMapper<S, D>
    {
        public D Map(S source)
        {
            return ExpressMapper.Mapper.Map<S, D>(source);
        }

        public void Map(S source, D destination)
        {
            ExpressMapper.Mapper.Map<S, D>(source, destination);
        }
    }
}