# M3 Verification Loop

## 목적

이 ExecPlan의 목적은 M1/M2 플레이어블 루프를 새 기능 추가 없이 반복 검증 가능한 상태로 만드는 것이다.

완료 후에는 Codex 또는 사람이 `Assets/Scenes/SampleScene.unity`의 현재 루프를 같은 절차로 다시 확인할 수 있고, 핵심 규칙 일부는 Edit Mode 테스트로 자동 검증할 수 있다. M3는 gameplay 확장 계획이 아니라 검증 루프 정착 계획이다.

## 승인된 Design 기준

- `docs/design/core-beliefs.md` 상태: 승인됨
- `docs/design/gameplay-loop.md` 상태: 승인됨

M3는 위 design 기준에 이미 승인된 `Start -> Move -> Pickup -> Deliver -> Result -> Retry` 규칙을 검증 가능하게 고정한다. 새 player-facing gameplay 규칙, 새 레벨, 새 입력, 새 UI 의미를 추가하지 않는다.

## 진행 상황

상태: 완료됨

- [x] M3 범위를 논의했다.
- [x] 공유된 이해 검증을 완료했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] M2 완료 상태와 작업트리 상태를 확인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공했다.
- [x] 사용자가 구현 시작을 승인했다.
- [x] 구현 시작 후 상태를 `진행 중`으로 갱신했다.
- [x] 구현 시작 후 작업트리 상태를 재확인했다.
- [x] Play Mode 수동 검증 체크리스트 문서를 추가했다.
- [x] 기존 gameplay 규칙을 테스트 가능한 순수 로직으로 작게 분리했다.
- [x] Edit Mode 테스트를 추가했다.
- [x] 명령 기반 C# 컴파일 검증을 완료했다.
- [x] Unity 테스트 실행 또는 실행 가능 절차를 검증했다.
- [x] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록했다.
- [x] `docs/current-state.md`를 M3 구현 결과에 맞게 갱신했다.
- [x] 필요한 경우 `docs/decisions.md`에 장기 검증 위치 결정을 기록했다.
- [x] 구현 완료 커밋 후 `git status`가 clean임을 확인한다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

M1 First Playable Loop는 완료되었다. `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`는 Play Mode 시작 시 `SampleScene`에 5 x 5 격자, `BOT` 로봇, `BOX` 물건, `GOAL` 목적지, 막힌 칸, UI, Retry 버튼을 runtime으로 구성한다.

M2 Readability and Regression Check는 기존 M1 루프를 유지한 채 목표, 남은 턴, 화물 보유, 진행 또는 결과 상태, Retry 의미를 더 읽기 쉽게 만든 단계다. `docs/current-state.md`와 `exec-plans/008-m2-readability-regression-check.md`에는 M2가 완료됨으로 기록되어 있다.

현재 코드 구조에서는 gameplay 규칙이 `FirstPlayableLoop`의 private 상태와 private 메서드에 묶여 있다. 이 상태로도 Reflection 기반 테스트는 가능하지만, M3 목적에는 맞지 않는다. M3에서는 동작을 바꾸지 않는 작은 리팩터로 기존 규칙을 순수 C# 로직에 분리하고, 그 로직을 Edit Mode 테스트로 검증한다.

관련 파일과 폴더는 다음과 같다.

- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`: 현재 runtime board, input, UI, gameplay 규칙을 함께 담고 있는 스크립트.
- `Assets/Scenes/SampleScene.unity`: Play Mode 수동 검증 대상 씬.
- `Packages/manifest.json`: `com.unity.test-framework` 1.6.0이 이미 포함되어 있다.
- `docs/design/core-beliefs.md`: 상위 design baseline이며 `상태: 승인됨`이다.
- `docs/design/gameplay-loop.md`: M1 루프와 최소 UI 피드백 기준이며 `상태: 승인됨`이다.
- `exec-plans/004-first-playable-loop.md`: 완료된 M1 계획이다.
- `exec-plans/008-m2-readability-regression-check.md`: M2 계획이다.
- `exec-plans/009-m3-verification-loop.md`: 이 계획 파일이다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 Unity 씬, C# 스크립트, 테스트 파일, 검증 문서를 만들거나 수정하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리 상태를 확인한다.
   - M2 Play Mode 검증 완료 상태가 `exec-plans/008-m2-readability-regression-check.md`와 `docs/current-state.md`에서 계속 완료로 유지되어 있는지 확인한다.
   - `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`가 `상태: 승인됨`인지 확인한다.
   - `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`와 `Assets/Scenes/SampleScene.unity`가 존재하는지 확인한다.

3. Play Mode 수동 검증 체크리스트를 문서화한다.
   - 새 폴더 `docs/verification/`를 만든다.
   - 새 문서 `docs/verification/play-mode-checklist.md`를 만든다.
   - 체크리스트에는 진입 조건, 초기 화면 확인, 벽/격자 밖 입력 확인, Clear 경로, Retry 확인, Failed 경로, Console 확인, 기록 방법을 포함한다.
   - 체크리스트는 이미 검증한 M1/M2 루프를 반복하기 위한 절차이며, 새 gameplay 요구사항을 추가하지 않는다.

4. 기존 gameplay 규칙을 테스트 가능한 순수 로직으로 작게 분리한다.
   - `FirstPlayableLoop.cs`에서 grid, wall, turn, pickup, delivery, failed, reset 규칙을 순수 C# 타입으로 이동한다.
   - 새 파일 후보는 `Assets/Scripts/DeliveryBotZero/DeliveryLoopRules.cs` 또는 `Assets/Scripts/DeliveryBotZero/DeliveryLoopState.cs`로 둔다.
   - `FirstPlayableLoop`는 입력, Unity 오브젝트 렌더링, UI 갱신을 계속 담당한다.
   - 분리 후에도 격자 크기, 시작 위치, 물건 위치, 목적지 위치, 막힌 칸, 턴 제한, UI 문구, 입력 동작은 바꾸지 않는다.
   - 테스트 가능성을 위해 필요한 public API는 작고 명시적인 상태 조회와 이동/초기화 메서드로 제한한다.

5. Edit Mode 테스트를 추가한다.
   - 테스트 폴더 후보는 `Assets/Tests/EditMode/DeliveryBotZero/`로 둔다.
   - 필요한 경우 Edit Mode 테스트용 `.asmdef`를 함께 추가한다.
   - 최소 테스트 후보는 다음과 같다.
     - 초기 상태는 시작 위치, 14턴, cargo 없음, running 상태다.
     - 벽 또는 격자 밖 이동은 위치와 남은 턴을 바꾸지 않는다.
     - 유효 이동은 위치를 바꾸고 남은 턴을 1 줄인다.
     - `BOX` 위치에 도착하면 cargo가 loaded 된다.
     - cargo 상태로 `GOAL`에 도착하면 clear 상태가 된다.
     - reset은 시작 상태로 되돌린다.
   - 구현 중 테스트가 지나치게 넓어지면 위 후보 중 핵심 3개 이상만 유지한다.

6. 컴파일과 테스트를 검증한다.
   - `dotnet build codex-harness-dbz-v0.sln`로 C# 컴파일을 확인한다.
   - 가능한 경우 Unity Test Runner 또는 Unity batchmode로 Edit Mode 테스트를 실행한다.
   - 열린 Unity Editor 인스턴스 때문에 batchmode가 중단되면, 중단 메시지를 기록하고 Editor Test Runner에서 실행할 절차와 확인 결과를 기록한다.
   - Play Mode 체크리스트는 문서화된 절차대로 최소 1회 통과했음을 기록한다.

7. 문서를 갱신하고 마무리한다.
   - 구현 결과, 테스트 결과, Play Mode 체크리스트 확인 결과를 이 ExecPlan에 기록한다.
   - `docs/current-state.md`를 M3 구현 상태에 맞게 갱신한다.
   - `docs/complete-log.md`에 M3 완료 기준과 검증 메모를 추가한다.
   - `docs/verification/`를 장기 검증 문서 위치로 유지하기로 결정했다면 `docs/decisions.md`에 기록한다.
   - 완료 후 커밋하고 `git status --short`가 clean인지 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- `docs/verification/play-mode-checklist.md`가 존재하고, M1/M2 루프를 반복 확인할 수 있는 절차를 포함한다.
- Play Mode 체크리스트에는 초기 상태, 벽/격자 밖 입력, Clear 경로, Retry, Failed 경로, Console 확인이 포함된다.
- 기존 M1/M2 gameplay 동작은 바뀌지 않는다.
- `FirstPlayableLoop`는 계속 `SampleScene` Play Mode 시작 시 board와 UI를 구성한다.
- Edit Mode 테스트가 최소 3개 이상 존재한다.
- Edit Mode 테스트는 기존 규칙의 초기화, 이동, invalid move, pickup, delivery, reset 중 핵심 항목을 검증한다.
- `dotnet build codex-harness-dbz-v0.sln`이 경고 또는 오류 없이 통과한다.
- Unity Test Runner 또는 batchmode로 테스트 실행을 시도하고 결과를 기록한다.
- 테스트 실행이 환경 문제로 막히면 원인과 대체 확인 절차를 기록한다.
- 검증 결과가 이 ExecPlan, `docs/current-state.md`, `docs/complete-log.md`에 기록된다.
- 최종 커밋 후 `git status --short`가 clean이다.

현재 검증 결과:

- ExecPlan 생성 전 `git status --short`: 출력 없음. 작업트리 clean.
- 구현 시작 후 `git status --short`: `docs/current-state.md`, `docs/decisions.md`, `exec-plans/009-m3-verification-loop.md` 변경 확인. `docs/decisions.md`는 내용 diff가 없고 해시가 인덱스와 같아 줄바꿈 또는 상태 캐시 잡음으로 판단했다.
- `exec-plans/009-m3-verification-loop.md` 번호가 비어 있음을 확인했다.
- `docs/design/README.md` 존재 확인: True.
- `docs/design/core-beliefs.md` 상태: 승인됨.
- `docs/design/gameplay-loop.md` 상태: 승인됨.
- `Packages/manifest.json`에 `com.unity.test-framework` 1.6.0이 있음을 확인했다.
- `docs/verification/play-mode-checklist.md`를 추가했다. 체크리스트에는 초기 상태, 벽/격자 밖 입력, Clear 경로, Retry, Failed 경로, Console 확인, 기록 위치가 포함되어 있다.
- `Assets/Scripts/DeliveryBotZero/DeliveryLoopState.cs`를 추가해 grid, wall, turn, pickup, delivery, failed, reset 규칙을 순수 상태 로직으로 분리했다.
- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`는 입력, board 오브젝트 동기화, UI 갱신을 담당하고 `DeliveryLoopState`를 사용하도록 수정했다.
- `Assets/Tests/EditMode/DeliveryBotZero/Editor/DeliveryLoopStateTests.cs`를 추가했다. 테스트는 초기 상태, invalid move, valid move, pickup/delivery clear, turn limit failed, reset을 검증한다.
- `dotnet build codex-harness-dbz-v0.sln` 첫 실행: 실패. 원인은 Unity 생성 파일인 `Assembly-CSharp.csproj`가 새 `DeliveryLoopState.cs`를 아직 포함하지 않아 `CS0246`가 발생한 것이었다.
- 로컬 검증을 위해 추적되지 않는 Unity 생성 `Assembly-CSharp.csproj`에 새 런타임 파일과 테스트 파일을 임시 포함한 뒤 `dotnet build codex-harness-dbz-v0.sln`을 다시 실행했다. 결과: 통과. 경고 0개, 오류 0개.
- Unity batchmode Edit Mode 테스트 명령 실행 시도: 열린 Unity Editor 인스턴스 때문에 중단됐다. 출력은 `It looks like another Unity instance is running with this project open.`였고, `Logs/m3-editmode.log`에도 batchmode 실행 인자와 return code 1 종료가 기록됐다.
- 사용자 확인: 열린 Unity Editor의 Edit Mode Test Runner에서 `DeliveryLoopStateTests` 6개 항목이 모두 통과했다.
- 사용자 확인: M3 리팩터 이후 `docs/verification/play-mode-checklist.md`의 모든 항목이 통과했다.
- 최종 커밋 후 `git status --short`: 출력 없음. 작업트리 clean.

## 자체 리뷰

- 공유된 이해 검증 내용과 ExecPlan 내용이 일치한다.
- 목표는 새 기능 추가가 아니라 M1/M2 루프의 반복 검증 가능 상태 정착으로 제한되어 있다.
- 승인된 `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`를 Design 기준으로 명시했다.
- 목표, 포함 범위, 제외 범위, 제약, 검증 방법이 포함되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있다.
- 구현 승인 전에는 테스트 파일, 검증 문서, C# 리팩터를 만들거나 수정하지 않도록 계획에 명시했다.
- Edit Mode 테스트를 위해 필요한 리팩터는 기존 gameplay 동작 변경 없이 순수 규칙 분리로 제한되어 있다.
- 완료 기준은 문서 존재, 컴파일, 테스트, Play Mode 체크리스트, 검증 기록, `git status`로 관찰 가능하다.

## 결정 기록

- 결정: M3는 Play Mode 수동 검증을 다시 발명하지 않고, 이미 통과한 수동 검증 절차를 재사용 가능한 체크리스트로 문서화한다.
  근거: M3의 목적은 새 gameplay 확인이 아니라 반복 검증 루프 정착이다.
  날짜: 2026-05-19

- 결정: M3 자동 테스트의 중심은 Edit Mode 테스트로 둔다.
  근거: Play Mode 수동 검증은 이미 완료되었고, 현재 단계에서는 핵심 규칙을 빠르게 반복 확인하는 작은 자동 테스트가 더 큰 가치를 준다.
  날짜: 2026-05-19

- 결정: Reflection으로 private 메서드를 테스트하지 않고, 기존 규칙을 작은 순수 C# 타입으로 분리한다.
  근거: Reflection 테스트는 구현 세부에 강하게 결합된다. M3는 반복 가능한 검증 기준을 만드는 단계이므로 테스트 대상 API를 작게 드러내는 편이 낫다.
  날짜: 2026-05-19

## 예상 밖 발견

- Unity 생성 `Assembly-CSharp.csproj`가 새 C# 파일을 자동으로 포함하기 전에는 `dotnet build`가 새 런타임 파일을 보지 못해 실패한다. 이번 검증에서는 추적되지 않는 로컬 생성 csproj에 새 파일을 임시 포함해 컴파일을 확인했다. Unity Editor가 프로젝트를 다시 refresh하면 생성 파일은 다시 작성될 수 있다.
- M1/M2와 동일하게 같은 프로젝트를 연 Unity Editor 인스턴스가 있으면 Unity batchmode 테스트 실행이 중단된다. M3 Edit Mode 테스트는 열린 Editor의 Test Runner에서 실행하거나, Editor를 닫은 뒤 batchmode로 다시 실행해야 한다.

## 회고

M3 Verification Loop를 완료했다.

- 완료한 것: Play Mode 수동 검증 체크리스트 문서화, 기존 gameplay 규칙의 `DeliveryLoopState` 분리, Edit Mode 테스트 6개 추가, `FirstPlayableLoop`의 규칙 위임 반영, 검증 결과 문서화.
- 완료하지 못한 것: Unity batchmode 테스트는 열린 Unity Editor 인스턴스 때문에 실행하지 못했다. 대신 열린 Editor의 Edit Mode Test Runner에서 6개 테스트 통과를 사용자 확인으로 기록했다.
- 배운 것: Unity 생성 `Assembly-CSharp.csproj`는 새 C# 파일을 즉시 포함하지 않을 수 있으므로, 명령 기반 `dotnet build`만으로는 Unity refresh 전 상태를 오해할 수 있다.
- 다음에 해야 할 것: M4 Handoff Test를 시작해 repo 문서만 보고 새 세션이 현재 상태와 다음 작업을 정확히 이어받을 수 있는지 검증한다.
- 다음 계획을 시작할 준비가 되었는지 여부: 예. M3 완료로 이 실험은 M0-M3 실질 성공 기준에 도달했다.
