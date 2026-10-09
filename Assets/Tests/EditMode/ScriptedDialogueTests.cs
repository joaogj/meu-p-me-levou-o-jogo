using System;
using MeuPMeLevou.Phone;
using NUnit.Framework;
using UnityEngine;

namespace MeuPMeLevou.Tests
{
    public sealed class ScriptedDialogueTests
    {
        private MariConversation _conversation;

        [SetUp]
        public void SetUp()
        {
            // Two steps: the first branches into two messages that both lead to the second,
            // which ends the conversation.
            _conversation = ScriptableObject.CreateInstance<MariConversation>();
            _conversation.Set("oi, chegou?", new[]
            {
                new DialogueStep
                {
                    Choices = new[]
                    {
                        new DialogueChoice { Message = "quase", Reply = "tô te esperando", NextStep = 1 },
                        new DialogueChoice { Message = "me perdi", Reply = "pergunta pra alguém aí", NextStep = 1 },
                    },
                },
                new DialogueStep
                {
                    Choices = new[]
                    {
                        new DialogueChoice { Message = "ok", Reply = "beijo", NextStep = MariConversation.EndStep },
                    },
                },
            });
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(_conversation);
        }

        [Test]
        public void StartsAtFirstStepWithOpening()
        {
            var dialogue = new ScriptedDialogue(_conversation);

            Assert.AreEqual("oi, chegou?", dialogue.Opening);
            Assert.IsFalse(dialogue.IsFinished);
            CollectionAssert.AreEqual(new[] { "quase", "me perdi" }, dialogue.Choices);
        }

        [Test]
        public void WalksSampleConversationFromStartToEnd()
        {
            // Arrange
            var dialogue = new ScriptedDialogue(_conversation);

            // Act
            string firstReply = dialogue.Choose(1);
            var secondChoices = dialogue.Choices;
            string lastReply = dialogue.Choose(0);

            // Assert
            Assert.AreEqual("pergunta pra alguém aí", firstReply);
            CollectionAssert.AreEqual(new[] { "ok" }, secondChoices);
            Assert.AreEqual("beijo", lastReply);
            Assert.IsTrue(dialogue.IsFinished);
            Assert.IsEmpty(dialogue.Choices);
        }

        [Test]
        public void ChoosingAfterTheEndThrows()
        {
            var dialogue = new ScriptedDialogue(_conversation);
            dialogue.Choose(0);
            dialogue.Choose(0);

            Assert.Throws<InvalidOperationException>(() => dialogue.Choose(0));
        }

        [Test]
        public void EmptyConversationIsFinishedFromTheStart()
        {
            var empty = ScriptableObject.CreateInstance<MariConversation>();

            var dialogue = new ScriptedDialogue(empty);

            Assert.IsTrue(dialogue.IsFinished);
            Assert.IsEmpty(dialogue.Choices);
            UnityEngine.Object.DestroyImmediate(empty);
        }
    }
}
