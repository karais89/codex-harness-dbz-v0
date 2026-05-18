# M1 First Playable Loop

## 1. 목적

Delivery Bot Zero의 M1 First Playable Loop를 `docs/game-brief.md` 범위 안에서 구현한다.

완료 후 플레이어는 Play Mode에서 5x5 탑다운 그리드의 로봇을 한 칸씩 움직이고, Pickup에서 package를 얻은 뒤 Delivery에 배달하고, Result에서 Retry로 같은 루프를 다시 시작할 수 있어야 한다.

이번 첫 구현 단위는 전체 루프 중 가장 작게 Play Mode에서 검증 가능한 수직 슬라이스다. 5x5 보드, Start 위치, 로봇 표시, WASD/방향키 한 칸 이동, 그리드 경계 차단을 구현한다.

## 2. 진행 상황

- [x] 필수 문서 `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, `docs/game-brief.md`를 읽었다.
- [x] M1 전체를 작은 수직 슬라이스로 나누었다.
- [x] 첫 번째 슬라이스로 5x5 보드, 로봇 시작 위치, 한 칸 이동, 경계 차단을 구현한다.
- [x] Play Mode 수동 검증 방법을 기록한다.
- [x] `docs/current-state.md`를 M1 진행 상태로 갱신한다.
- [x] 변경 사항을 커밋하고 `git status`가 clean인지 확인한다.

## 3. 맥락

현재 프로젝트는 Unity 6000.4.1f1 기반의 2D URP 프로젝트다.

관련 파일과 상태는 다음과 같다.

- `docs/game-brief.md`: M1 범위를 정의한다. 루프는 `Start -> Move -> Pickup -> Deliver -> Result -> Retry`다.
- `Assets/Scenes/SampleScene.unity`: 현재 기본 카메라와 Global Light 2D만 있는 기본 씬이다.
- `Packages/manifest.json`: Unity 기본 2D/URP/Input System/Test Framework 패키지가 이미 포함되어 있다. 새 외부 패키지는 추가하지 않는다.
- `docs/current-state.md`: M0 완료, M1 시작 준비 상태로 기록되어 있다.
- `docs/decisions.md`: M1 범위와 ExecPlan 파일 이름 결정이 기록되어 있다.
- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`: 이번 계획에서 추가한 첫 번째 슬라이스 런타임 스크립트다. Play Mode 진입 후 보드, 타일 라벨, 로봇, 이동 처리를 생성한다.

이번 계획에서는 MCP, 사용자 정의 skill, hook, subagent, 외부 패키지를 추가하지 않는다.

## 4. 계획

M1은 다음 수직 슬라이스로 진행한다.

1. 보드와 이동 슬라이스
   - 5x5 탑다운 보드를 Play Mode에서 볼 수 있게 만든다.
   - Start, Pickup, Delivery 위치를 색과 라벨로 구분한다.
   - 로봇을 Start 위치에 둔다.
   - WASD와 방향키 입력 한 번을 상하좌우 한 칸 이동으로 처리한다.
   - 로봇이 그리드 밖으로 이동하지 못하게 한다.

2. Pickup 슬라이스
   - 로봇이 Pickup 위치에 도착하면 package 보유 상태가 되게 한다.
   - package 획득 전과 후를 화면 텍스트와 로봇 색으로 구분한다.

3. Delivery와 Result 슬라이스
   - package를 가진 상태로 Delivery 위치에 도착하면 Result 상태로 진입한다.
   - Result 상태를 화면에서 확인할 수 있게 한다.
   - Result 상태에서는 이동 입력을 무시한다.

4. Retry 슬라이스
   - Result 상태에서 Retry를 선택하면 로봇과 package 상태가 시작 상태로 돌아가게 한다.
   - 같은 루프를 Play Mode에서 반복할 수 있게 한다.

이번 턴에서는 1번 보드와 이동 슬라이스만 구현한다. 2번부터 4번은 남은 작업으로 유지한다.

## 5. 검증

첫 번째 슬라이스 검증은 Unity Editor Play Mode에서 수동으로 수행한다.

검증 절차:

1. Unity Editor에서 `Assets/Scenes/SampleScene.unity`를 연다.
2. Play Mode를 시작한다.
3. 5x5 보드가 보이고 Start, Pickup, Delivery 라벨이 구분되는지 확인한다.
4. 로봇이 Start 위치에서 시작하는지 확인한다.
5. WASD와 방향키를 한 번씩 눌러 입력 한 번에 로봇이 한 칸씩 움직이는지 확인한다.
6. 보드 가장자리에서 바깥 방향 입력을 눌러 로봇이 그리드 밖으로 나가지 않는지 확인한다.
7. Console에 컴파일 오류나 런타임 오류가 없는지 확인한다.

현재 기록된 검증 결과:

- `git diff --check`를 실행해 공백 오류가 없음을 확인했다.
- Unity 6000.4.1f1 참조 어셈블리와 `Library/ScriptAssemblies/Unity.InputSystem.dll`을 사용해 `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`를 로컬 Roslyn 컴파일로 확인했다. 컴파일 오류와 경고는 없었다.
- Unity batchmode 프로젝트 로드 검증은 같은 프로젝트가 이미 다른 Unity Editor 인스턴스에서 열려 있어 실행하지 못했다.
- Codex가 실제 Unity Play Mode 조작을 수행하지는 못했다. 위 수동 절차에 따라 Editor에서 확인해야 한다.

이번 슬라이스에서 아직 검증하지 않는 항목:

- Pickup에서 package를 얻는 동작
- package 보유 상태 표시
- Delivery 완료와 Result 상태
- Retry

## 6. 결정 기록

- 결정: M1 첫 구현 단위는 보드와 이동 슬라이스로 제한한다.
- 근거: Play Mode에서 바로 관찰할 수 있으면서도 Pickup, Delivery, Result, Retry를 구현하기 전의 가장 작은 수직 단위다.
- 날짜: 2026-05-18

- 결정: 첫 슬라이스는 런타임 스크립트가 기본 씬에 보드와 표시 오브젝트를 생성하는 방식으로 구현한다.
- 근거: 현재 `SampleScene.unity`는 비어 있는 기본 씬에 가깝다. 수동 씬 YAML 편집보다 작은 코드 변경으로 Play Mode 검증 대상을 만들 수 있고, 외부 패키지나 새 워크플로우를 추가하지 않는다.
- 날짜: 2026-05-18

## 7. 예상 밖 발견

- 같은 프로젝트가 이미 Unity Editor에서 열려 있어 `Unity.exe -batchmode -projectPath ... -quit` 검증이 중단되었다.
- PATH에는 `Unity` 명령이 없었지만, Unity Editor는 `C:\Program Files\Unity\Hub\Editor\6000.4.1f1\Editor\Unity.exe`에 설치되어 있었다.
- Unity batchmode 대신 Unity 참조 어셈블리를 직접 지정한 로컬 Roslyn 컴파일로 새 C# 스크립트의 컴파일 오류 여부를 확인했다.

## 8. 회고

완료한 것:

- M1 전체를 네 개의 수직 슬라이스로 나누었다.
- 첫 번째 슬라이스로 5x5 보드, Start/Pickup/Delivery 라벨, Start 위치의 로봇, WASD/방향키 한 칸 이동, 그리드 경계 차단을 구현했다.
- Play Mode 수동 검증 절차와 아직 검증하지 않은 M1 항목을 기록했다.

완료하지 못한 것:

- Pickup package 획득, Delivery Result, Retry는 아직 구현하지 않았다.
- Codex가 실제 Unity Editor Play Mode 조작을 수행하지 못했다.

배운 것:

- 현재 프로젝트는 기본 씬에 런타임 부트스트랩 스크립트를 추가하는 방식만으로 첫 번째 검증 가능한 슬라이스를 만들 수 있다.
- 열린 Editor 인스턴스가 있으면 batchmode 검증은 같은 프로젝트에 대해 실행할 수 없다.

다음에 해야 할 것:

- Unity Editor Play Mode에서 첫 번째 슬라이스를 수동 검증한다.
- 다음 슬라이스로 Pickup 위치에서 package 보유 상태를 구현한다.

다음 계획을 시작할 준비:

- M1 계획은 계속 진행 중이며, 첫 번째 슬라이스 검증 후 두 번째 슬라이스를 진행할 수 있다.
