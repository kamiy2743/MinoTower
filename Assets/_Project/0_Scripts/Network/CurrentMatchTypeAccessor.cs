using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class CurrentMatchTypeAccessor
    {
        private static MatchType _type = MatchType.None;

        public void Set(MatchType type)
        {
            _type = type;
        }

        public MatchType Get()
        {
            return _type;
        }
    }
}
