using System.Collections.Generic;
using UnityEngine;

namespace DeliveryBotZero
{
    public enum DeliveryLoopResultState
    {
        Running,
        Clear,
        Failed
    }

    public sealed class DeliveryLoopState
    {
        public const int GridWidth = 5;
        public const int GridHeight = 5;
        public const int TurnLimit = 14;

        public static readonly Vector2Int StartPosition = new Vector2Int(0, 0);
        public static readonly Vector2Int ItemPosition = new Vector2Int(4, 0);
        public static readonly Vector2Int DestinationPosition = new Vector2Int(4, 4);

        private static readonly Vector2Int[] WallPositionsInternal =
        {
            new Vector2Int(1, 0),
            new Vector2Int(1, 1),
            new Vector2Int(3, 2)
        };

        public DeliveryLoopState()
        {
            Reset();
        }

        public static IReadOnlyList<Vector2Int> WallPositions
        {
            get { return WallPositionsInternal; }
        }

        public Vector2Int RobotPosition { get; private set; }

        public int RemainingTurns { get; private set; }

        public bool HasItem { get; private set; }

        public DeliveryLoopResultState ResultState { get; private set; }

        public bool TryMove(Vector2Int direction)
        {
            if (ResultState != DeliveryLoopResultState.Running || !IsSingleStepDirection(direction))
            {
                return false;
            }

            Vector2Int nextPosition = RobotPosition + direction;
            if (!IsInsideGrid(nextPosition) || IsWall(nextPosition))
            {
                return false;
            }

            RobotPosition = nextPosition;
            RemainingTurns--;

            ResolveCellEffects();
            if (ResultState == DeliveryLoopResultState.Running && RemainingTurns <= 0)
            {
                ResultState = DeliveryLoopResultState.Failed;
            }

            return true;
        }

        public void Reset()
        {
            RobotPosition = StartPosition;
            RemainingTurns = TurnLimit;
            HasItem = false;
            ResultState = DeliveryLoopResultState.Running;
        }

        public static bool IsInsideGrid(Vector2Int position)
        {
            return position.x >= 0 && position.x < GridWidth && position.y >= 0 && position.y < GridHeight;
        }

        public static bool IsWall(Vector2Int position)
        {
            for (int i = 0; i < WallPositionsInternal.Length; i++)
            {
                if (WallPositionsInternal[i] == position)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSingleStepDirection(Vector2Int direction)
        {
            return direction == Vector2Int.up
                || direction == Vector2Int.down
                || direction == Vector2Int.left
                || direction == Vector2Int.right;
        }

        private void ResolveCellEffects()
        {
            if (!HasItem && RobotPosition == ItemPosition)
            {
                HasItem = true;
            }

            if (HasItem && RobotPosition == DestinationPosition)
            {
                ResultState = DeliveryLoopResultState.Clear;
            }
        }
    }
}
