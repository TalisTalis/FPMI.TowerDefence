using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    // корневой файл
    // аттрибут для добавления пункта меню в редакторе
    [CreateAssetMenu(menuName = "Assets/Asset Root", fileName = "Asset Root")]
    public class AssetRoot : ScriptableObject // легко может серилизовать объекты
    {
        public SceneAsset UIScene;
        // ссылки на уровни
        public List<LevelAsset> Levels;
    }
}
