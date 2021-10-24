using System;
using UnityEngine;

namespace Sample
{
    public class Table : SceneObj
    {
        public TextMesh text;
        public string tableName;
        public string itemName;
        public string itemStatus;
        public int itemCount;

        private void LateUpdate()
        {
            //this.text.text = $"{itemName}({itemStatus}):{itemCount}";
            this.text.text = $"{tableName}";
        }
    }
}
