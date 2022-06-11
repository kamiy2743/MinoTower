using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class CurrentMatchTypeAccessor
    {
        public async UniTask SetAsync(MatchType type)
        {
            await PropertyAccessor.Instance.SetAsync<MatchType>(PropertyType.Player, PropertyKey.CurrentMatchType, type);
        }

        public MatchType Get()
        {
            return PropertyAccessor.Instance.Get<MatchType>(PropertyType.Player, PropertyKey.CurrentMatchType);
        }
    }
}
