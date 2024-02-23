using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Craft/Resource")]
    public class Resource : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField, TextArea] private string _description;

        public string title => _title;

        public string description => _description;
    }
}
