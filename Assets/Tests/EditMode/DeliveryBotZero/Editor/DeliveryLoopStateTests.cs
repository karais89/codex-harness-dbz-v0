using NUnit.Framework;
using UnityEngine;

namespace DeliveryBotZero.Tests
{
    public sealed class DeliveryLoopStateTests
    {
        [Test]
        public void NewStateStartsAtInitialValues()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            Assert.AreEqual(DeliveryLoopState.StartPosition, state.RobotPosition);
            Assert.AreEqual(DeliveryLoopState.TurnLimit, state.RemainingTurns);
            Assert.IsFalse(state.HasItem);
            Assert.AreEqual(DeliveryLoopResultState.Running, state.ResultState);
        }

        [Test]
        public void InvalidMovesDoNotChangePositionOrTurns()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            Assert.IsFalse(state.TryMove(Vector2Int.right));
            Assert.IsFalse(state.TryMove(Vector2Int.left));
            Assert.IsFalse(state.TryMove(Vector2Int.down));
            Assert.IsFalse(state.TryMove(new Vector2Int(2, 0)));

            Assert.AreEqual(DeliveryLoopState.StartPosition, state.RobotPosition);
            Assert.AreEqual(DeliveryLoopState.TurnLimit, state.RemainingTurns);
            Assert.AreEqual(DeliveryLoopResultState.Running, state.ResultState);
        }

        [Test]
        public void ValidMoveChangesPositionAndSpendsOneTurn()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            Assert.IsTrue(state.TryMove(Vector2Int.up));

            Assert.AreEqual(new Vector2Int(0, 1), state.RobotPosition);
            Assert.AreEqual(DeliveryLoopState.TurnLimit - 1, state.RemainingTurns);
            Assert.AreEqual(DeliveryLoopResultState.Running, state.ResultState);
        }

        [Test]
        public void PickupAndDeliveryReachClearState()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            MoveAlong(state, Vector2Int.up, Vector2Int.up, Vector2Int.right, Vector2Int.right, Vector2Int.down, Vector2Int.down, Vector2Int.right, Vector2Int.right);

            Assert.AreEqual(DeliveryLoopState.ItemPosition, state.RobotPosition);
            Assert.IsTrue(state.HasItem);
            Assert.AreEqual(6, state.RemainingTurns);
            Assert.AreEqual(DeliveryLoopResultState.Running, state.ResultState);

            MoveAlong(state, Vector2Int.up, Vector2Int.up, Vector2Int.up, Vector2Int.up);

            Assert.AreEqual(DeliveryLoopState.DestinationPosition, state.RobotPosition);
            Assert.AreEqual(2, state.RemainingTurns);
            Assert.AreEqual(DeliveryLoopResultState.Clear, state.ResultState);
            Assert.IsFalse(state.TryMove(Vector2Int.down));
        }

        [Test]
        public void TurnsRunningOutBeforeDeliveryReachesFailedState()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            for (int i = 0; i < 7; i++)
            {
                MoveAlong(state, Vector2Int.up, Vector2Int.down);
            }

            Assert.AreEqual(DeliveryLoopState.StartPosition, state.RobotPosition);
            Assert.AreEqual(0, state.RemainingTurns);
            Assert.IsFalse(state.HasItem);
            Assert.AreEqual(DeliveryLoopResultState.Failed, state.ResultState);
            Assert.IsFalse(state.TryMove(Vector2Int.up));
        }

        [Test]
        public void ResetRestoresInitialStateAfterProgress()
        {
            DeliveryLoopState state = new DeliveryLoopState();

            MoveAlong(state, Vector2Int.up, Vector2Int.up, Vector2Int.right);
            state.Reset();

            Assert.AreEqual(DeliveryLoopState.StartPosition, state.RobotPosition);
            Assert.AreEqual(DeliveryLoopState.TurnLimit, state.RemainingTurns);
            Assert.IsFalse(state.HasItem);
            Assert.AreEqual(DeliveryLoopResultState.Running, state.ResultState);
        }

        private static void MoveAlong(DeliveryLoopState state, params Vector2Int[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                Assert.IsTrue(state.TryMove(directions[i]), "Expected move " + directions[i] + " to be valid.");
            }
        }
    }
}
