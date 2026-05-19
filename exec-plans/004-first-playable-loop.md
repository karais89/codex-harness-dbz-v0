# M1 First Playable Loop

## 목적

이 ExecPlan의 목적은 Delivery Bot Zero의 첫 플레이 가능 루프를 Unity Play Mode에서 확인 가능한 상태로 구현하는 것이다.

완료 후에는 플레이어가 `Assets/Scenes/SampleScene.unity`를 열고 Play Mode에서 작은 격자 레벨을 시작해, 한 칸씩 이동하고, 물건을 자동으로 줍고, 목적지에 자동 배달하고, 성공 또는 실패 결과를 본 뒤 Retry로 같은 레벨을 다시 시작할 수 있다.

이 계획은 전체 게임 제작 계획이 아니다. M1에서 승인된 `Start -> Move -> Pickup -> Deliver -> Result -> Retry` 루프 하나만 작고 검증 가능하게 구현한다.

## 승인된 Design 기준

- `docs/design/core-beliefs.md` 상태: 승인됨
- `docs/design/gameplay-loop.md` 상태: 승인됨

이 계획은 위 두 문서의 player-facing gameplay 기준을 구현 방법과 검증 절차로 옮긴다. 새로운 gameplay 규칙을 추가하지 않는다.

## 진행 상황

상태: 진행 중

- [x] M1 gameplay loop 인터뷰와 공유된 이해 검증을 완료했다.
- [x] `docs/design/core-beliefs.md`가 `상태: 승인됨`임을 확인했다.
- [x] `docs/design/gameplay-loop.md`가 `상태: 승인됨`임을 확인했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공했다.
- [x] 사용자가 구현 시작을 승인했다.
- [x] 구현 시작 후 상태를 `진행 중`으로 갱신했다.
- [x] M1 gameplay 스크립트를 추가했다.
- [x] 명령 기반 C# 컴파일 검증을 완료했다.
- [x] Unity batchmode 검증 시도 결과를 기록했다.
- [ ] Unity Play Mode에서 핵심 루프를 수동 검증했다.
- [x] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록했다.
- [x] `docs/current-state.md`를 M1 구현 결과에 맞게 갱신했다.
- [ ] 구현 완료 커밋 후 `git status`가 clean임을 확인했다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

현재 M0는 완료되었다. Unity 프로젝트는 Unity `6000.4.1f1`로 생성되어 있고, 현재 플레이 가능한 gameplay 구현은 없다.

현재 관련 파일과 폴더는 다음과 같다.

- `Assets/Scenes/SampleScene.unity`: 현재 기본 씬. `Main Camera`와 `Global Light 2D`가 있다.
- `Packages/manifest.json`: `com.unity.inputsystem`, `com.unity.ugui`, URP 2D 관련 패키지가 이미 있다.
- `ProjectSettings/ProjectSettings.asset`: `activeInputHandler: 1`로 설정되어 있어 M1 입력은 Unity Input System 기준으로 구현한다.
- `docs/design/core-beliefs.md`: 상위 design baseline이며 `상태: 승인됨`이다.
- `docs/design/gameplay-loop.md`: M1 gameplay loop 기준이며 `상태: 승인됨`이다.
- `exec-plans/004-first-playable-loop.md`: 이 계획 파일이다.

M1 완료 전까지 hooks, MCP, custom skills, subagents, 별도 template 폴더, 서드파티 패키지를 추가하지 않는다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 Unity 씬, C# 스크립트, gameplay 파일을 만들거나 수정하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리가 clean인지 확인한다.
   - `Assets/Scenes/SampleScene.unity`, `Packages/manifest.json`, `ProjectSettings/ProjectVersion.txt`가 존재하는지 확인한다.
   - 이미 생성된 gameplay 파일이 있으면 이 계획의 예상 밖 발견에 기록하고, 범위 충돌이 없을 때만 이어간다.

3. M1 runtime gameplay 스크립트를 추가한다.
   - 새 폴더 `Assets/Scripts/DeliveryBotZero/`를 만든다.
   - 새 C# 파일 `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`를 만든다.
   - 하나의 작고 읽기 쉬운 MonoBehaviour에 M1 상태, 입력, 격자 렌더링, 최소 UI를 함께 둔다.
   - Play Mode 시작 시 `RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)`로 `SampleScene`에 필요한 runtime 오브젝트를 구성한다.
   - 이 방식은 M1에서 Unity 씬 YAML을 손으로 크게 수정하지 않고, Play Mode에서 관찰 가능한 루프를 먼저 검증하기 위한 선택이다.

4. 단일 고정 레벨을 코드에 정의한다.
   - 격자는 5 x 5 직사각형으로 둔다.
   - 시작 위치는 `(0, 0)`으로 둔다.
   - 물건 위치는 `(4, 0)`으로 둔다.
   - 목적지 위치는 `(4, 4)`로 둔다.
   - 막힌 칸은 `(1, 0)`, `(1, 1)`, `(3, 2)`로 둔다.
   - 턴 제한은 14로 둔다.
   - 위 수치는 `docs/design/gameplay-loop.md`가 허용한 “작고 읽기 쉬운 범위 안의 구현/검증 단계 결정”이며, 새 gameplay 종류를 추가하지 않는다.

5. 이동과 상태 규칙을 구현한다.
   - 방향키와 WASD를 입력으로 받는다.
   - 입력 1회는 인접한 한 칸 이동 시도로 처리한다.
   - 격자 밖 또는 막힌 칸 입력은 이동하지 않고 턴도 소모하지 않는다.
   - 유효 이동은 로봇 위치를 한 칸 바꾸고 남은 턴을 1 줄인다.
   - 물건 칸에 올라가면 자동 Pickup 상태가 된다.
   - 물건을 가진 상태로 목적지 칸에 올라가면 성공 상태가 된다.
   - 남은 턴이 0이 되고 아직 성공하지 않았으면 실패 상태가 된다.
   - 성공 또는 실패 이후에는 이동 입력을 무시한다.
   - Retry는 시작 위치, 물건 보유 상태, 결과 상태, 남은 턴, 표시 상태를 모두 초기화한다.

6. 최소 시각화와 UI를 구현한다.
   - 기본 도형과 색상만 사용해 배경 격자, 막힌 칸, 로봇, 물건, 목적지를 구분한다.
   - 외부 이미지 에셋을 추가하지 않는다.
   - UI에는 남은 턴, 물건 보유 여부, 결과 상태, Retry 버튼을 표시한다.
   - UI는 M1 검증용 최소 표현으로 유지하고, 레벨 선택이나 도움말 화면을 추가하지 않는다.

7. Unity에서 컴파일과 Play Mode를 검증한다.
   - Unity Editor에서 프로젝트를 열고 Console 컴파일 오류가 없는지 확인한다.
   - `Assets/Scenes/SampleScene.unity`를 열고 Play Mode를 시작한다.
   - 아래 검증 절차를 수행하고 결과를 이 ExecPlan에 기록한다.
   - Unity가 `.meta` 파일을 생성하면 예상 파일인지 확인하고 커밋에 포함한다.

8. 문서를 갱신하고 마무리한다.
   - 구현 결과, 검증 절차, 알려진 제한을 이 ExecPlan에 기록한다.
   - `docs/current-state.md`를 M1 구현 상태에 맞게 갱신한다.
   - 오래 유지해야 하는 결정이 새로 생긴 경우에만 `docs/decisions.md`를 갱신한다.
   - 완료 후 `git status --short`가 clean인지 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- Unity 프로젝트가 컴파일 오류 없이 열린다.
- `Assets/Scenes/SampleScene.unity`가 존재하고 Play Mode를 시작할 수 있다.
- Play Mode 시작 시 작은 격자, 로봇, 물건, 목적지, 막힌 칸이 보인다.
- UI에 남은 턴, 물건 보유 여부, 결과 상태, Retry 버튼이 보인다.
- 방향키와 WASD로 유효한 인접 칸 이동이 가능하다.
- 유효 이동 1회마다 남은 턴이 1 줄어든다.
- 막힌 칸 또는 격자 밖으로 이동하려는 입력은 로봇 위치와 남은 턴을 바꾸지 않는다.
- 로봇이 물건 칸에 올라가면 자동으로 물건 보유 상태가 된다.
- 물건 보유 상태로 목적지 칸에 올라가면 성공 상태가 된다.
- 성공 상태가 되면 추가 이동 입력이 무시된다.
- 물건을 배달하지 못한 채 남은 턴이 0이 되면 실패 상태가 된다.
- 실패 상태가 되면 추가 이동 입력이 무시된다.
- Retry 버튼을 누르면 같은 레벨이 시작 상태로 돌아간다.
- Console에 새 오류가 없다.
- 검증 결과가 이 ExecPlan과 `docs/current-state.md`에 기록된다.
- 최종 커밋 후 `git status --short`가 clean이다.

명령 기반 검증이 가능하면 다음도 함께 기록한다.

- `git status --short`
- Unity Editor 또는 batchmode 컴파일 확인 결과

자동 테스트는 M1 필수 범위가 아니다. 다만 구현 중 간단한 Edit Mode 테스트가 작고 안정적으로 가능하다고 판단되면 이 ExecPlan에 변경 이유를 기록한 뒤 추가할 수 있다.

현재 검증 결과:

- `dotnet build codex-harness-dbz-v0.sln`: 통과. 경고 0개, 오류 0개.
- `dotnet build codex-harness-dbz-v0.sln --no-restore`: `Temp/obj/Assembly-CSharp/project.assets.json` 누락으로 한 차례 실패했다. 일반 `dotnet build`가 복원을 수행한 뒤 경고 0개, 오류 0개로 통과했다.
- Unity batchmode 명령: 실행 시도했으나 같은 프로젝트를 연 Unity Editor 인스턴스가 이미 있어 중단됐다. 로그 파일은 `Logs/m1-batchmode.log`에 생성됐다.
- 열린 Unity Editor 확인: `Unity` 프로세스가 `codex-harness-dbz-v0 - SampleScene - Windows, Mac, Linux - Unity 6.4 (6000.4.1f1) <DX11>` 창 제목으로 실행 중임을 확인했다.
- Unity Editor 로그 확인: 기존 프로젝트 로드와 `SampleScene` 로드는 확인했지만, 새 `FirstPlayableLoop.cs`의 Play Mode 동작은 이 세션에서 직접 검증하지 못했다.
- 아직 필요한 검증: 열린 Unity Editor에서 Play Mode를 시작해 이동, Pickup, Deliver, 실패, Retry, Console 오류 여부를 수동 확인해야 한다.

## 자체 리뷰

- 인터뷰 합의와 ExecPlan 내용이 일치한다.
- 승인된 `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`를 Design 기준으로 명시했다.
- 목표, 포함 범위, 제외 범위, 구현 단계, 검증 방법이 포함되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있다.
- 현재 커밋 전 변경은 문서와 ExecPlan 작성뿐이며, Unity 씬 또는 gameplay 스크립트 구현은 시작하지 않았다.
- 정확한 격자 크기, 좌표, 턴 수, 벽 위치는 승인 design 문서가 허용한 ExecPlan 단계 결정으로만 기록했다.
- 완료 기준은 Play Mode 동작, Console 오류 확인, 문서 갱신, `git status` 확인으로 관찰 가능하다.

## 결정 기록

- 결정: M1 ExecPlan은 `exec-plans/004-first-playable-loop.md`를 사용한다.
  근거: `docs/decisions.md`에 M1 First Playable Loop ExecPlan 경로로 이미 기록되어 있다.
  날짜: 2026-05-19

- 결정: M1 구현은 외부 패키지, MCP, custom skill, hook, subagent를 추가하지 않는다.
  근거: M1 완료 전 하네스 확장을 보류한다는 장기 결정과 현재 실험 목적을 따른다.
  날짜: 2026-05-19

- 결정: M1은 Play Mode 시작 시 runtime bootstrap으로 필요한 오브젝트를 구성하는 단일 gameplay 스크립트부터 구현한다.
  근거: 현재 `SampleScene`은 기본 씬에 가깝고, M1 목표는 영구 씬 제작보다 작은 gameplay 루프의 검증이다. Unity 씬 YAML을 손으로 크게 편집하는 위험을 줄이고, Play Mode에서 관찰 가능한 루프를 먼저 만든다.
  날짜: 2026-05-19

- 결정: M1 단일 레벨의 구현 기준은 5 x 5 격자, 시작 `(0, 0)`, 물건 `(4, 0)`, 목적지 `(4, 4)`, 막힌 칸 `(1, 0)`, `(1, 1)`, `(3, 2)`, 턴 제한 14로 시작한다.
  근거: 승인된 `docs/design/gameplay-loop.md`는 정확한 좌표와 수치를 ExecPlan 또는 구현 검증 단계에서 작고 읽기 쉬운 범위 안에서 정할 수 있다고 했다. 이 배치는 단일 고정 레벨, 2-3개 막힌 칸, 한두 번 실수해도 재시도 가능한 턴 제한 범위를 만족한다.
  날짜: 2026-05-19

## 예상 밖 발견

- Unity batchmode 검증은 같은 프로젝트를 연 Unity Editor 인스턴스가 이미 있으면 실행되지 않는다. 이번 세션에서는 `dotnet build`로 C# 컴파일은 확인했지만, Play Mode 수동 검증은 열린 Editor에서 별도로 확인해야 한다.

## 회고

아직 Play Mode 검증 전이다.

- 완료한 것: M1 gameplay design 기준 승인 확인, 이 ExecPlan 생성, M1 gameplay 스크립트 추가, 명령 기반 C# 컴파일 검증.
- 완료하지 못한 것: Unity Play Mode 핵심 루프 수동 검증, M1 완료 상태 문서화.
- 배운 것: 현재 프로젝트가 Unity Editor에서 열려 있으면 batchmode 검증은 중단된다.
- 다음에 해야 할 것: 열린 Unity Editor에서 Play Mode를 실행해 이동, Pickup, Deliver, 실패, Retry를 수동 검증한다.
- 다음 계획을 시작할 준비가 되었는지 여부: 아니다. 이 ExecPlan의 구현과 검증이 먼저 필요하다.
