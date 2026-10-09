using System;
using System.Collections.Generic;

namespace MeuPMeLevou.Phone
{
    // Walks a MariConversation step by step. Pure C# over the asset's data, so it is tested in EditMode.
    public sealed class ScriptedDialogue : IDialogueSource
    {
        private static readonly string[] NoChoices = Array.Empty<string>();

        private readonly MariConversation _conversation;
        private int _step;

        public ScriptedDialogue(MariConversation conversation)
        {
            _conversation = conversation;
            _step = conversation.Steps.Length > 0 ? 0 : MariConversation.EndStep;
        }

        public string Opening => _conversation.Opening;

        public bool IsFinished => _step == MariConversation.EndStep;

        public IReadOnlyList<string> Choices
        {
            get
            {
                if (IsFinished)
                {
                    return NoChoices;
                }

                DialogueChoice[] choices = _conversation.Steps[_step].Choices;
                var messages = new string[choices.Length];
                for (int i = 0; i < choices.Length; i++)
                {
                    messages[i] = choices[i].Message;
                }

                return messages;
            }
        }

        public string Choose(int choiceIndex)
        {
            if (IsFinished)
            {
                throw new InvalidOperationException("The conversation with Mari is already over.");
            }

            DialogueChoice choice = _conversation.Steps[_step].Choices[choiceIndex];
            _step = choice.NextStep;
            return choice.Reply;
        }
    }
}
