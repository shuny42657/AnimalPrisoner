using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI;

namespace Matching
{
    public class PasswordInputFieldPresenter : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputField;
        [SerializeField] ButtonInteract buttonInteract;
        private void Awake()
        {
            inputField.onValueChanged.AddListener(value => buttonInteract.Show(value.Length == 6));
        }
    }
}
