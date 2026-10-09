using System.Collections.Generic;

namespace MeuPMeLevou.Phone
{
    // Where the phone chat gets Mari's lines from. In M0 the only implementation walks a
    // hand-written MariConversation; the Claude chat (through a server) comes in later as another one.
    public interface IDialogueSource
    {
        // Mari's first message, shown when the chat opens.
        string Opening { get; }

        // The ready-made messages the player can send now. Empty when the conversation is over.
        IReadOnlyList<string> Choices { get; }

        bool IsFinished { get; }

        // Sends the chosen message and returns Mari's reply, moving the conversation to the next step.
        string Choose(int choiceIndex);
    }
}
