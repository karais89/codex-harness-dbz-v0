# M2 Readability and Regression Check

## 목적

이 ExecPlan의 목적은 M1 First Playable Loop의 기존 동작을 유지한 채, 플레이어가 목표, 현재 상태, 결과, Retry 의미를 더 쉽게 읽을 수 있도록 최소 UI 표현을 개선하는 것이다.

완료 후에는 플레이어가 `Assets/Scenes/SampleScene.unity`를 열고 Play Mode를 시작했을 때 `BOX`를 주워 `GOAL`로 배달해야 한다는 목표, 남은 턴, 화물 보유 상태, 진행 또는 결과 상태, Retry 버튼의 의미를 더 명확하게 읽을 수 있다.

이 계획은 새 gameplay 기능 추가 계획이 아니다. M1에서 검증한 이동, Pickup, Deliver, Result, Retry 규칙과 단일 고정 레벨은 그대로 유지한다.

## 승인된 Design 기준

- `docs/design/core-beliefs.md` 상태: 승인됨
- `docs/design/gameplay-loop.md` 상태: 승인됨

M2는 위 두 문서가 이미 승인한 최소 UI 피드백과 Retry 규칙의 읽기성을 개선하는 작업이다. 새 player-facing gameplay 규칙, 새 상태 체계, 새 퍼즐 요소를 추가하지 않으므로 design 문서 갱신은 필요하지 않다.

## 진행 상황

상태: 구현 승인 대기

- [x] M1 완료 상태를 확인했다.
- [x] M2 범위를 논의했다.
- [x] design 문서 갱신이 필수인지 검토했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공했다.
- [ ] 사용자가 구현 시작을 승인했다.
- [ ] 구현 시작 후 상태를 `진행 중`으로 갱신한다.
- [ ] M2 UI 읽기성 개선을 적용한다.
- [ ] 명령 기반 C# 컴파일 검증을 완료한다.
- [ ] Unity Play Mode에서 M1 회귀 검증과 M2 읽기성 검증을 완료한다.
- [ ] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록한다.
- [ ] `docs/current-state.md`를 M2 구현 결과에 맞게 갱신한다.
- [ ] 구현 완료 커밋 후 `git status`가 clean임을 확인한다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

M1 First Playable Loop는 완료되었다. `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`는 Play Mode 시작 시 `SampleScene`에 5 x 5 격자, `BOT` 로봇, `BOX` 물건, `GOAL` 목적지, 막힌 칸, 최소 UI, Retry 버튼을 runtime으로 구성한다.

M1 완료 당시 Unity Play Mode 수동 검증에서 다음 핵심 동작이 통과했다.

- 방향키와 WASD로 한 칸 이동한다.
- 벽과 격자 밖 입력은 이동하지 않고 턴도 소모하지 않는다.
- `BOX` 칸에 도착하면 자동 Pickup된다.
- `BOX`를 가진 상태로 `GOAL`에 도착하면 Clear가 된다.
- 배달하지 못한 채 턴이 0이 되면 Failed가 된다.
- Clear 또는 Failed 이후 이동 입력은 잠긴다.
- Retry 버튼은 같은 레벨을 시작 상태로 되돌린다.
- Play Mode 중 새 Error와 새 Warning이 없다.

현재 UI는 `Turns`, `Cargo`, `State`, `Retry` 중심의 최소 표현이다. M2는 같은 정보를 더 플레이어 친화적으로 읽히게 만드는 change request다.

관련 파일과 폴더는 다음과 같다.

- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`: M1 gameplay와 runtime UI를 구성하는 단일 스크립트.
- `Assets/Scenes/SampleScene.unity`: M1 Play Mode 검증 대상 씬.
- `docs/design/core-beliefs.md`: 상위 design baseline이며 `상태: 승인됨`이다.
- `docs/design/gameplay-loop.md`: M1 루프와 최소 UI 피드백 기준이며 `상태: 승인됨`이다.
- `exec-plans/004-first-playable-loop.md`: 완료된 M1 계획이다.
- `exec-plans/008-m2-readability-regression-check.md`: 이 계획 파일이다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 Unity 씬, C# 스크립트, gameplay 파일을 만들거나 수정하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리 상태를 확인한다.
   - `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`가 `상태: 승인됨`인지 확인한다.
   - `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`와 `Assets/Scenes/SampleScene.unity`가 존재하는지 확인한다.
   - M2 시작 전 예상 밖 변경이 있으면 이 계획에 기록한다.

3. M1 runtime UI 표현만 작게 개선한다.
   - `FirstPlayableLoop.cs`의 UI 생성과 UI 갱신 코드를 중심으로 수정한다.
   - Play Mode 시작 시 목표 문구가 보이게 한다.
   - 남은 턴, 화물 보유, 상태 문구를 플레이어가 더 바로 이해할 수 있는 라벨로 바꾼다.
   - 성공과 실패 결과 문구를 M1 규칙 안에서 더 명확하게 바꾼다.
   - Retry 버튼 라벨을 같은 레벨 재시작 의미가 드러나게 바꾼다.
   - 텍스트 크기, 위치, RectTransform 크기를 조정해 기본 Game View에서 겹치지 않게 한다.

4. M1 gameplay 동작은 유지한다.
   - 격자 크기, 시작 위치, 물건 위치, 목적지 위치, 막힌 칸, 턴 제한을 바꾸지 않는다.
   - 이동 규칙, Pickup 규칙, Deliver 규칙, Failed 규칙, Retry 초기화 규칙을 바꾸지 않는다.
   - 새 입력, 새 레벨, 새 튜토리얼, 힌트 시스템, 실패 이유 분기, 점수, 애니메이션, 외부 에셋을 추가하지 않는다.
   - UI 읽기성 개선에 꼭 필요하지 않은 코드 리팩터링을 하지 않는다.

5. 컴파일과 Play Mode를 검증한다.
   - `dotnet build codex-harness-dbz-v0.sln`로 C# 컴파일을 확인한다.
   - Unity Editor에서 `Assets/Scenes/SampleScene.unity`를 열고 Play Mode를 시작한다.
   - M2 읽기성 검증과 M1 회귀 검증을 수행한다.
   - Console에 새 Error와 새 Warning이 없는지 확인한다.

6. 문서를 갱신하고 마무리한다.
   - 구현 결과, 검증 절차, 검증 결과를 이 ExecPlan에 기록한다.
   - 프로젝트 상태가 바뀌었으므로 `docs/current-state.md`를 갱신한다.
   - 오래 유지해야 하는 결정이 새로 생긴 경우에만 `docs/decisions.md`를 갱신한다.
   - 완료 후 커밋하고 `git status --short`가 clean인지 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- `dotnet build codex-harness-dbz-v0.sln`이 경고 또는 오류 없이 통과한다.
- `Assets/Scenes/SampleScene.unity`가 존재하고 Play Mode를 시작할 수 있다.
- Play Mode 시작 시 목표 문구가 보인다.
- UI에서 남은 턴, 화물 보유 상태, 현재 진행 또는 결과 상태가 M1보다 명확하게 읽힌다.
- Retry 버튼의 라벨이 같은 레벨 재시작 의미를 더 분명히 전달한다.
- UI 텍스트가 기본 Game View에서 서로 겹치지 않는다.
- 로봇은 파란색 `BOT`, 물건은 노란색 `BOX`, 목적지는 초록색 `GOAL`로 계속 구분된다.
- 방향키와 WASD로 유효한 인접 칸 이동이 가능하다.
- 유효 이동 1회마다 남은 턴이 1 줄어든다.
- 막힌 칸 또는 격자 밖으로 이동하려는 입력은 로봇 위치와 남은 턴을 바꾸지 않는다.
- 로봇이 물건 칸에 올라가면 자동으로 물건 보유 상태가 된다.
- 물건 보유 상태로 목적지 칸에 올라가면 성공 상태가 된다.
- 성공 상태가 되면 추가 이동 입력이 무시된다.
- 물건을 배달하지 못한 채 남은 턴이 0이 되면 실패 상태가 된다.
- 실패 상태가 되면 추가 이동 입력이 무시된다.
- Retry 버튼을 누르면 같은 레벨이 시작 상태로 돌아간다.
- Console에 새 Error와 새 Warning이 없다.
- 검증 결과가 이 ExecPlan과 `docs/current-state.md`에 기록된다.
- 최종 커밋 후 `git status --short`가 clean이다.

현재 검증 결과:

- 구현 승인 전이므로 아직 M2 구현 검증을 수행하지 않았다.

## 자체 리뷰

- 사용자와 합의한 목표가 `M1 루프를 유지한 채 목표/상태/결과/Retry가 더 잘 읽히도록 개선하고, 기존 동작이 깨지지 않았는지 검증`으로 반영되어 있다.
- design 문서 갱신이 필요하지 않은 이유가 승인된 `core-beliefs.md`와 `gameplay-loop.md`의 범위 안에서 설명되어 있다.
- 목표, 포함 범위, 제외 범위, 제약, 검증 방법이 포함되어 있다.
- 새 gameplay 규칙, 새 레벨, 새 힌트 시스템, 새 실패 분기, 새 외부 도구가 범위 밖으로 명시되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있고, 구현 단계는 승인 이후로만 배치되어 있다.
- 완료 기준은 컴파일, Unity Play Mode 관찰, M1 회귀 체크, 문서 갱신, `git status` 확인으로 관찰 가능하다.

## 결정 기록

- 결정: M2에서는 design 문서를 갱신하지 않는다.
  근거: M2는 승인된 M1 루프의 최소 UI 피드백을 더 잘 읽히게 만드는 작업이며, 새 player-facing gameplay 규칙을 추가하지 않는다.
  날짜: 2026-05-19

- 결정: M2는 `FirstPlayableLoop.cs`의 runtime UI 표현을 중심으로 작은 change request로 진행한다.
  근거: M1 구현은 하나의 스크립트가 runtime board와 UI를 구성한다. 읽기성 개선을 같은 위치에서 작게 처리하면 기존 gameplay 동작을 건드릴 위험이 낮다.
  날짜: 2026-05-19

- 결정: M2 검증은 M1 회귀 검증을 포함한다.
  근거: M2의 핵심 목적은 새 기능 추가가 아니라 기존 M1 루프를 유지하면서 표현만 개선하는 것이므로, 기존 이동, Pickup, Deliver, Failed, Retry 동작이 그대로 통과해야 한다.
  날짜: 2026-05-19

## 예상 밖 발견

- 없음. 구현 중 새 사실이 발견되면 이 섹션에 기록한다.

## 회고

구현 완료 후 작성한다.
