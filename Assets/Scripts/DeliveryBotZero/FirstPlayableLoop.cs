using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DeliveryBotZero
{
    public sealed class FirstPlayableLoop : MonoBehaviour
    {
        private const float CellSize = 1.1f;

        private readonly DeliveryLoopState loopState = new DeliveryLoopState();
        private readonly List<GameObject> spawnedObjects = new List<GameObject>();

        private Sprite squareSprite;
        private GameObject robotObject;
        private GameObject itemObject;
        private Text objectiveText;
        private Text turnsText;
        private Text cargoText;
        private Text stateText;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Bootstrap()
        {
            if (SceneManager.GetActiveScene().name != "SampleScene")
            {
                return;
            }

            if (FindAnyObjectByType<FirstPlayableLoop>() != null)
            {
                return;
            }

            new GameObject("M1 First Playable Loop").AddComponent<FirstPlayableLoop>();
        }

        private void Awake()
        {
            squareSprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f), 1f);

            ConfigureCamera();
            BuildBoard();
            BuildUi();
            ResetLevel();
        }

        private void Update()
        {
            if (loopState.ResultState != DeliveryLoopResultState.Running)
            {
                return;
            }

            Vector2Int direction = ReadMoveDirection();
            if (direction != Vector2Int.zero)
            {
                TryMove(direction);
            }
        }

        private void OnDestroy()
        {
            for (int i = spawnedObjects.Count - 1; i >= 0; i--)
            {
                if (spawnedObjects[i] != null)
                {
                    Destroy(spawnedObjects[i]);
                }
            }

            if (squareSprite != null)
            {
                Destroy(squareSprite);
            }
        }

        private void ConfigureCamera()
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                GameObject cameraObject = new GameObject("Main Camera");
                cameraObject.tag = "MainCamera";
                mainCamera = cameraObject.AddComponent<Camera>();
                spawnedObjects.Add(cameraObject);
            }

            mainCamera.orthographic = true;
            mainCamera.orthographicSize = 3.8f;
            mainCamera.transform.position = new Vector3(0f, 0.25f, -10f);
            mainCamera.backgroundColor = new Color(0.08f, 0.1f, 0.12f);
        }

        private void BuildBoard()
        {
            GameObject boardRoot = new GameObject("M1 Board");
            spawnedObjects.Add(boardRoot);

            for (int y = 0; y < DeliveryLoopState.GridHeight; y++)
            {
                for (int x = 0; x < DeliveryLoopState.GridWidth; x++)
                {
                    Vector2Int cell = new Vector2Int(x, y);
                    bool isWall = DeliveryLoopState.IsWall(cell);
                    Color color = isWall ? new Color(0.18f, 0.2f, 0.23f) : new Color(0.82f, 0.86f, 0.9f);
                    GameObject cellObject = CreateTile("Cell " + x + "," + y, cell, color, 0.96f, 0);
                    cellObject.transform.SetParent(boardRoot.transform, true);
                }
            }

            GameObject destinationObject = CreateTile("Destination", DeliveryLoopState.DestinationPosition, new Color(0.2f, 0.72f, 0.38f), 0.74f, 1);
            AddWorldLabel(destinationObject, "GOAL", Color.white, 4);
            destinationObject.transform.SetParent(boardRoot.transform, true);

            itemObject = CreateTile("Package", DeliveryLoopState.ItemPosition, new Color(0.95f, 0.78f, 0.18f), 0.5f, 2);
            AddWorldLabel(itemObject, "BOX", Color.black, 5);
            itemObject.transform.SetParent(boardRoot.transform, true);

            robotObject = CreateTile("Delivery Bot", DeliveryLoopState.StartPosition, new Color(0.12f, 0.48f, 0.95f), 0.62f, 3);
            AddWorldLabel(robotObject, "BOT", Color.white, 6);
            robotObject.transform.SetParent(boardRoot.transform, true);
        }

        private GameObject CreateTile(string objectName, Vector2Int gridPosition, Color color, float scale, int sortingOrder)
        {
            GameObject tile = new GameObject(objectName);
            SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
            renderer.sprite = squareSprite;
            renderer.color = color;
            renderer.sortingOrder = sortingOrder;
            tile.transform.position = GridToWorld(gridPosition);
            tile.transform.localScale = new Vector3(scale * CellSize, scale * CellSize, 1f);
            return tile;
        }

        private void AddWorldLabel(GameObject parent, string label, Color color, int sortingOrder)
        {
            GameObject labelObject = new GameObject(label + " Label");
            labelObject.transform.SetParent(parent.transform, false);
            labelObject.transform.localPosition = new Vector3(0f, 0f, -0.01f);
            labelObject.transform.localScale = Vector3.one;

            TextMesh textMesh = labelObject.AddComponent<TextMesh>();
            textMesh.text = label;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;
            textMesh.characterSize = 0.08f;
            textMesh.fontSize = 32;
            textMesh.color = color;

            Font font = GetDefaultFont();
            if (font != null)
            {
                textMesh.font = font;
            }

            MeshRenderer renderer = labelObject.GetComponent<MeshRenderer>();
            if (font != null)
            {
                renderer.sharedMaterial = font.material;
            }

            renderer.sortingOrder = sortingOrder;
        }

        private void BuildUi()
        {
            EnsureEventSystem();

            GameObject canvasObject = new GameObject("M1 Minimal UI");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler scaler = canvasObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1280f, 720f);
            scaler.matchWidthOrHeight = 0.5f;
            canvasObject.AddComponent<GraphicRaycaster>();
            spawnedObjects.Add(canvasObject);

            Font font = GetDefaultFont();

            objectiveText = CreateText(canvasObject.transform, "Goal", font, new Vector2(24f, -24f), 24, new Vector2(680f, 34f));
            turnsText = CreateText(canvasObject.transform, "Turns", font, new Vector2(24f, -66f), 24, new Vector2(420f, 32f));
            cargoText = CreateText(canvasObject.transform, "Cargo", font, new Vector2(24f, -100f), 24, new Vector2(420f, 32f));
            stateText = CreateText(canvasObject.transform, "Status", font, new Vector2(24f, -134f), 24, new Vector2(680f, 32f));
            CreateRetryButton(canvasObject.transform, font);
        }

        private void EnsureEventSystem()
        {
            if (FindAnyObjectByType<EventSystem>() != null)
            {
                return;
            }

            GameObject eventSystemObject = new GameObject("EventSystem");
            eventSystemObject.AddComponent<EventSystem>();
            eventSystemObject.AddComponent<InputSystemUIInputModule>();
            spawnedObjects.Add(eventSystemObject);
        }

        private Text CreateText(Transform parent, string objectName, Font font, Vector2 anchoredPosition, int fontSize, Vector2 size)
        {
            GameObject textObject = new GameObject(objectName);
            textObject.transform.SetParent(parent, false);

            Text text = textObject.AddComponent<Text>();
            text.font = font;
            text.fontSize = fontSize;
            text.color = Color.white;
            text.alignment = TextAnchor.MiddleLeft;

            RectTransform rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = size;

            return text;
        }

        private void CreateRetryButton(Transform parent, Font font)
        {
            GameObject buttonObject = new GameObject("Retry Button");
            buttonObject.transform.SetParent(parent, false);

            Image image = buttonObject.AddComponent<Image>();
            image.color = new Color(0.18f, 0.24f, 0.3f, 0.95f);

            Button button = buttonObject.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(ResetLevel);

            RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.anchoredPosition = new Vector2(24f, -178f);
            rectTransform.sizeDelta = new Vector2(168f, 44f);

            GameObject labelObject = new GameObject("Label");
            labelObject.transform.SetParent(buttonObject.transform, false);
            Text label = labelObject.AddComponent<Text>();
            label.font = font;
            label.text = "Retry Level";
            label.fontSize = 22;
            label.color = Color.white;
            label.alignment = TextAnchor.MiddleCenter;

            RectTransform labelTransform = label.GetComponent<RectTransform>();
            labelTransform.anchorMin = Vector2.zero;
            labelTransform.anchorMax = Vector2.one;
            labelTransform.offsetMin = Vector2.zero;
            labelTransform.offsetMax = Vector2.zero;
        }

        private static Font GetDefaultFont()
        {
            Font font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            if (font == null)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            }

            return font;
        }

        private Vector2Int ReadMoveDirection()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                return Vector2Int.zero;
            }

            if (keyboard.upArrowKey.wasPressedThisFrame || keyboard.wKey.wasPressedThisFrame)
            {
                return Vector2Int.up;
            }

            if (keyboard.downArrowKey.wasPressedThisFrame || keyboard.sKey.wasPressedThisFrame)
            {
                return Vector2Int.down;
            }

            if (keyboard.leftArrowKey.wasPressedThisFrame || keyboard.aKey.wasPressedThisFrame)
            {
                return Vector2Int.left;
            }

            if (keyboard.rightArrowKey.wasPressedThisFrame || keyboard.dKey.wasPressedThisFrame)
            {
                return Vector2Int.right;
            }

            return Vector2Int.zero;
        }

        private void TryMove(Vector2Int direction)
        {
            if (!loopState.TryMove(direction))
            {
                return;
            }

            SyncBoardObjects();
            UpdateUi();
        }

        private void ResetLevel()
        {
            loopState.Reset();
            SyncBoardObjects();
            UpdateUi();
        }

        private void SyncBoardObjects()
        {
            if (robotObject != null)
            {
                robotObject.transform.position = GridToWorld(loopState.RobotPosition);
            }

            if (itemObject != null)
            {
                itemObject.SetActive(!loopState.HasItem);
            }
        }

        private void UpdateUi()
        {
            objectiveText.text = "Goal: Pick up BOX, then deliver it to GOAL.";
            turnsText.text = "Turns Left: " + loopState.RemainingTurns;
            cargoText.text = "Cargo: " + (loopState.HasItem ? "BOX loaded" : "No BOX");
            stateText.text = "Status: " + GetStateLabel();
            stateText.color = GetStateColor();
        }

        private string GetStateLabel()
        {
            switch (loopState.ResultState)
            {
                case DeliveryLoopResultState.Clear:
                    return "Delivered.";
                case DeliveryLoopResultState.Failed:
                    return "Out of turns.";
                default:
                    return loopState.HasItem ? "Deliver to GOAL." : "Pick up BOX.";
            }
        }

        private Color GetStateColor()
        {
            switch (loopState.ResultState)
            {
                case DeliveryLoopResultState.Clear:
                    return new Color(0.38f, 0.95f, 0.58f);
                case DeliveryLoopResultState.Failed:
                    return new Color(1f, 0.58f, 0.4f);
                default:
                    return Color.white;
            }
        }

        private static Vector3 GridToWorld(Vector2Int position)
        {
            float offsetX = (DeliveryLoopState.GridWidth - 1) * CellSize * 0.5f;
            float offsetY = (DeliveryLoopState.GridHeight - 1) * CellSize * 0.5f;
            return new Vector3(position.x * CellSize - offsetX, position.y * CellSize - offsetY, 0f);
        }
    }
}
