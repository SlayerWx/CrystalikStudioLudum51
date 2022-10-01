using UnityEngine;
using TMPro;

namespace Game
{
    public class CreditsBehaviour : MonoBehaviour
    {
        [SerializeField] TextAsset creditsText;

        void Start()
        {
            GetComponent<TextMeshProUGUI>().text = creditsText.ToString();
        }
    }
}


