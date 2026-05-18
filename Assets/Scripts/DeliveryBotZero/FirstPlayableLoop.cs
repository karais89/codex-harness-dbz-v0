using UnityEngine;
using UnityEngine.InputSystem;

namespace DeliveryBotZero
{
    public sealed class FirstPlayableLoop : MonoBehaviour
    {
        private const int BoardSize = 5;
        private const float CellSize = 1.1f;

        private static readonly Vector2Int StartCell = new Vector2Int(0, 0);
        private static readonly Vector2Int PickupCell = new Vector2Int(2, 2);
        private static readonly Vector2Int DeliveryCell = new Vector2Int(4, 4);

        private Transform robotTransform;
        private Vector2Int robotCell;
        private Sprite squareSprite;
        private GUIStyle statusStyle;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Bootstrap()
        {
            if (FindAnyObjectByType<FirstPlayableLoop>() != null)
            {
                return;
            }

            var root = new GameObject("Delivery Bot Zero - M1 Slice 1");
            root.AddComponent<FirstPlayableLoop>();
        }

        private void Awake()
        {
            robotCell = StartCell;
            squareSprite = CreateSquareSprite();

            ConfigureCamera();
            BuildBoard();
            BuildRobot();
            UpdateRobotPosition();
        }

        private void Update()
        {
            var move = ReadMoveInput();
            if (move != Vector2Int.zero)
            {
                TryMove(move);
            }
        }

        private void OnGUI()
        {
            EnsureStatusStyle();

            var status = "Delivery Bot Zero M1\n"
                + "Slice 1: Board + Move\n"
                + "Robot: (" + robotCell.x + ", " + robotCell.y + ")\n"
                + "Package: No";

            GUI.Label(new Rect(16f, 16f, 280f, 96f), status, statusStyle);
        }

        private static Vector2Int ReadMoveInput()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null)
            {
                return Vector2Int.zero;
            }

            if (keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame)
            {
                return Vector2Int.up;
            }

            if (keyboard.sKey.wasPressedThisFrame || keyboard.downArrowKey.wasPressedThisFrame)
            {
                return Vector2Int.down;
            }

            if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
            {
                return Vector2Int.left;
            }

            if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
            {
                return Vector2Int.right;
            }

            return Vector2Int.zero;
        }

        private void TryMove(Vector2Int move)
        {
            var target = robotCell + move;
            if (!IsInsideBoard(target))
            {
                return;
            }

            robotCell = target;
            UpdateRobotPosition();
        }

        private static bool IsInsideBoard(Vector2Int cell)
        {
            return cell.x >= 0
                && cell.x < BoardSize
                && cell.y >= 0
                && cell.y < BoardSize;
        }

        private void ConfigureCamera()
        {
            var mainCamera = Camera.main;
            if (mainCamera == null)
            {
                return;
            }

            mainCamera.transform.position = new Vector3(0f, 0f, -10f);
            mainCamera.orthographic = true;
            mainCamera.orthographicSize = 4.1f;
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
            mainCamera.backgroundColor = new Color(0.08f, 0.09f, 0.1f);
        }

        private void BuildBoard()
        {
            for (var y = 0; y < BoardSize; y++)
            {
                for (var x = 0; x < BoardSize; x++)
                {
                    var cell = new Vector2Int(x, y);
                    var tile = new GameObject("Tile " + x + "," + y);
                    tile.transform.SetParent(transform, false);
                    tile.transform.position = CellToWorld(cell);
                    tile.transform.localScale = Vector3.one * 0.98f;

                    var renderer = tile.AddComponent<SpriteRenderer>();
                    renderer.sprite = squareSprite;
                    renderer.color = TileColor(cell);
                    renderer.sortingOrder = 0;

                    var label = TileLabel(cell);
                    if (!string.IsNullOrEmpty(label))
                    {
                        CreateTileLabel(tile.transform, label);
                    }
                }
            }
        }

        private void BuildRobot()
        {
            var robot = new GameObject("Robot");
            robot.transform.SetParent(transform, false);
            robot.transform.localScale = Vector3.one * 0.62f;

            var renderer = robot.AddComponent<SpriteRenderer>();
            renderer.sprite = squareSprite;
            renderer.color = new Color(0.06f, 0.72f, 0.9f);
            renderer.sortingOrder = 10;

            CreateTileLabel(robot.transform, "BOT", Color.black, 0.13f, 20, 20);
            robotTransform = robot.transform;
        }

        private void UpdateRobotPosition()
        {
            if (robotTransform != null)
            {
                robotTransform.position = CellToWorld(robotCell) + new Vector3(0f, 0f, -0.1f);
            }
        }

        private static Color TileColor(Vector2Int cell)
        {
            if (cell == StartCell)
            {
                return new Color(0.28f, 0.68f, 0.38f);
            }

            if (cell == PickupCell)
            {
                return new Color(0.95f, 0.73f, 0.22f);
            }

            if (cell == DeliveryCell)
            {
                return new Color(0.3f, 0.47f, 0.92f);
            }

            var even = (cell.x + cell.y) % 2 == 0;
            return even ? new Color(0.78f, 0.8f, 0.82f) : new Color(0.64f, 0.67f, 0.7f);
        }

        private static string TileLabel(Vector2Int cell)
        {
            if (cell == StartCell)
            {
                return "START";
            }

            if (cell == PickupCell)
            {
                return "PICKUP";
            }

            if (cell == DeliveryCell)
            {
                return "DROP";
            }

            return string.Empty;
        }

        private static void CreateTileLabel(Transform parent, string label)
        {
            CreateTileLabel(parent, label, Color.black, 0.1f, 18, 5);
        }

        private static void CreateTileLabel(
            Transform parent,
            string label,
            Color color,
            float characterSize,
            int fontSize,
            int sortingOrder)
        {
            var labelObject = new GameObject("Label");
            labelObject.transform.SetParent(parent, false);
            labelObject.transform.localPosition = new Vector3(0f, 0f, -0.2f);

            var text = labelObject.AddComponent<TextMesh>();
            text.text = label;
            text.anchor = TextAnchor.MiddleCenter;
            text.alignment = TextAlignment.Center;
            text.characterSize = characterSize;
            text.fontSize = fontSize;
            text.color = color;

            var renderer = labelObject.GetComponent<MeshRenderer>();
            renderer.sortingOrder = sortingOrder;
        }

        private static Vector3 CellToWorld(Vector2Int cell)
        {
            var offset = -((BoardSize - 1) * CellSize) / 2f;
            return new Vector3(offset + cell.x * CellSize, offset + cell.y * CellSize, 0f);
        }

        private static Sprite CreateSquareSprite()
        {
            var texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();
            texture.hideFlags = HideFlags.HideAndDontSave;

            var sprite = Sprite.Create(texture, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f), 1f);
            sprite.name = "RuntimeSquare";
            sprite.hideFlags = HideFlags.HideAndDontSave;
            return sprite;
        }

        private void EnsureStatusStyle()
        {
            if (statusStyle != null)
            {
                return;
            }

            statusStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 18,
                normal =
                {
                    textColor = Color.white
                }
            };
        }
    }
}
