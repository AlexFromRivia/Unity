using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace UI
{
    public class C_GUI : MonoBehaviour
    {
        public static void CreateMessage(Text _textPrefab, Transform _parentTransform, string _messageText)
        {
            _textPrefab.text = _messageText;
            Instantiate(_textPrefab, _parentTransform);
        }

        public static void CreateMessage(Text _textPrefab, string _messageText)
        {
            _textPrefab.text = _messageText;
            Instantiate(_textPrefab);
        }
    }

    public class Cell : MonoBehaviour
    {

    }
}