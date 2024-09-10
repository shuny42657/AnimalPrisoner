using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class PasswordInputFieldView : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputField;
        [SerializeField] ButtonInteract buttonInteract;
        [SerializeField] CustomMatching customMatching; 
        private void Awake()
        {
            inputField.onValueChanged.AddListener(value => buttonInteract.Show(value.Length == 6));
            inputField.onValueChanged.AddListener(value => customMatching.SetPassword(value));
        }
    }
}
