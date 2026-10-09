using MeuPMeLevou.Jaime;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class StaminaTests
    {
        [Test]
        public void SprintingDrainsStamina()
        {
            var stamina = new Stamina(max: 100f, drainPerSecond: 20f);

            bool sprinting = stamina.Tick(1f, wantsSprint: true, isMoving: true);

            Assert.IsTrue(sprinting);
            Assert.AreEqual(80f, stamina.Current, 0.001f);
        }

        [Test]
        public void WalkingWithoutSprintingRecoversStamina()
        {
            var stamina = new Stamina(max: 100f, recoveryPerSecond: 15f);
            stamina.Tick(2f, wantsSprint: true, isMoving: true); // drains 40 -> 60

            bool sprinting = stamina.Tick(1f, wantsSprint: false, isMoving: true);

            Assert.IsFalse(sprinting);
            Assert.AreEqual(75f, stamina.Current, 0.001f);
        }

        [Test]
        public void StandingStillDoesNotRecoverStamina()
        {
            var stamina = new Stamina(max: 100f);
            stamina.Tick(2f, wantsSprint: true, isMoving: true); // 100 -> 60

            stamina.Tick(1f, wantsSprint: false, isMoving: false);

            Assert.AreEqual(60f, stamina.Current, 0.001f);
        }

        [Test]
        public void CannotSprintWithZeroStamina()
        {
            var stamina = new Stamina(max: 100f, drainPerSecond: 20f);
            stamina.Tick(5f, wantsSprint: true, isMoving: true); // empties stamina
            Assert.IsFalse(stamina.CanSprint);

            bool sprinting = stamina.Tick(1f, wantsSprint: true, isMoving: false);

            Assert.IsFalse(sprinting);
            Assert.IsFalse(stamina.CanSprint);
            Assert.AreEqual(0f, stamina.Current, 0.001f);
        }

        [Test]
        public void StaminaNeverExceedsMaxNorGoesNegative()
        {
            var stamina = new Stamina(max: 100f, drainPerSecond: 20f, recoveryPerSecond: 15f);

            stamina.Tick(10f, wantsSprint: true, isMoving: true);
            Assert.AreEqual(0f, stamina.Current, 0.001f);

            stamina.Tick(100f, wantsSprint: false, isMoving: true);
            Assert.AreEqual(100f, stamina.Current, 0.001f);
        }
    }
}
