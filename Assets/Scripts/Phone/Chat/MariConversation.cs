using System;
using UnityEngine;

namespace MeuPMeLevou.Phone
{
    // Hand-written chat with Mari: an opening message and a list of steps. Each step offers
    // two or three messages for the player; each one leads to Mari's reply and to the next step.
    [CreateAssetMenu(fileName = "MariConversation", menuName = "Meu P Me Levou/Mari Conversation")]
    public sealed class MariConversation : ScriptableObject
    {
        // Marks a choice that ends the conversation.
        public const int EndStep = -1;

        [SerializeField, TextArea] private string _opening;
        [SerializeField] private DialogueStep[] _steps = Array.Empty<DialogueStep>();

        public string Opening => _opening;

        public DialogueStep[] Steps => _steps;

        // Lets tests and editor tools fill the asset without the Inspector.
        public void Set(string opening, DialogueStep[] steps)
        {
            _opening = opening;
            _steps = steps;
        }
    }

    [Serializable]
    public sealed class DialogueStep
    {
        public DialogueChoice[] Choices = Array.Empty<DialogueChoice>();
    }

    [Serializable]
    public sealed class DialogueChoice
    {
        [TextArea] public string Message;
        [TextArea] public string Reply;

        // Index of the next step in MariConversation.Steps, or MariConversation.EndStep.
        public int NextStep = MariConversation.EndStep;
    }
}
