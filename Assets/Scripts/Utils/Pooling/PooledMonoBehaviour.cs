using UnityEngine;

namespace Assets.Scripts.Utils.Pooling
{
    public class PooledMonoBehaviour : MonoBehaviour
    {
        private int m_PrefabId;

        public int PrefabId => m_PrefabId;

        // чтобы можно перегрузить этот методд у наследников сделали его виртуальным
        public virtual void AwakePooled()
        {
            
        }

        public void SetPrefabId(int id)
        {
            m_PrefabId = id;
        }
    }
}
