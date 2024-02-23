using UnityEngine;
using TMPro;

namespace CraftSystem.Menu
{
    public class ResourceInMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmp;
        [SerializeField] private Resource _resource;

        public Resource resource => _resource;

        public int count { get; private set; }

        public int max { get; private set; }

        private void UpdateView()
		{
            _tmp.text = $"{count}/{max}";
		}

        public void SetCount(int value)
		{
            count = value;
            UpdateView();
		}

        public void SetMax(int value)
		{
            max = value;
		}

        public void Set(int max, int count)
		{
            this.max = max;
            this.count = count;

            UpdateView();
		}
    }
}
