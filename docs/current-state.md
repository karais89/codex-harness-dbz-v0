# 현재 상태

## 프로젝트

Codex Harness v0 — Delivery Bot Zero

## 현재 단계

M0 완료. M1 First Playable Loop 시작 전 워크플로우 규칙 초안을 승인하고 실제 저장소 규칙에 반영했다.

M1 시작 전에 전체 시험 범위를 쉽게 확인할 수 있도록 `docs/milestone-roadmap.html`을 추가했다. 이 문서는 M0-M5 마일스톤, 최소/실질/완전 성공 기준, 실패 신호를 시각화한 검토 보조 문서다.

M1 시작 전 design baseline 규칙 도입을 선행 준비 단계로 진행했다. `docs/design/README.md`는 design 문서 작성 규약이다.

006 이후 `core-beliefs.md` 초안 자격 조건을 보강했다. 2026-05-19 사용자 인터뷰와 공유된 이해 검증을 거쳐 `docs/design/core-beliefs.md`를 `상태: 초안`으로 작성했고, 이후 사용자가 명시 승인해 `상태: 승인됨`으로 전환했다.

M1 gameplay loop 인터뷰와 공유된 이해 검증을 거쳐 `docs/design/gameplay-loop.md`를 `상태: 초안`으로 작성했고, 이후 사용자가 명시 승인해 `상태: 승인됨`으로 전환했다. 사용자가 M1 ExecPlan 생성을 승인해 `exec-plans/004-first-playable-loop.md`를 `구현 승인 대기` 상태로 생성했고, 이후 구현을 승인했다.

`Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`는 Play Mode 시작 시 `SampleScene`에 작은 5 x 5 격자, `BOT` 표식의 로봇, `BOX` 표식의 물건, `GOAL` 표식의 목적지, 막힌 칸, 최소 UI, Retry 버튼을 runtime으로 구성한다. `dotnet build codex-harness-dbz-v0.sln`은 경고 0개, 오류 0개로 통과했다. Unity batchmode 검증은 같은 프로젝트를 연 Unity Editor 인스턴스가 이미 있어서 중단됐다. 열린 Editor에서 Play Mode 수동 검증은 아직 완료하지 않았다.

## 활성 계획

M1 First Playable Loop 계획 `exec-plans/004-first-playable-loop.md`가 `진행 중` 상태다. M1 gameplay 스크립트와 Unity `.meta` 파일은 추가됐고, 명령 기반 C# 컴파일 검증은 통과했다. Unity Play Mode 수동 검증은 아직 남아 있다.

Core Beliefs 작성 절차 보강 계획 `exec-plans/007-core-beliefs-authoring-flow.md`는 완료되었다.

Design baseline 규칙 도입 계획 `exec-plans/006-design-baseline-rules.md`는 완료되었다.

워크플로우 규칙 반영 계획 `exec-plans/005-workflow-rule-adoption.md`는 완료되었다.

`docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`는 승인됐다. M1 gameplay ExecPlan 파일은 기존 결정대로 `exec-plans/004-first-playable-loop.md`를 사용한다.

## 완료됨

- Unity 프로젝트를 생성했다.
- Git 저장소를 초기화했다.
- GitHub 저장소를 연결했다.
- README.md를 추가했다.
- AGENTS.md를 추가했다.
- PLANS.md를 추가했다.
- ExecPlan 저장 위치와 이름 규칙을 문서화했다.
- Git worktree 스모크 테스트를 완료했다.
- 저장소 루트의 `.worktree/`는 무시되며 로컬 worktree 저장소로 사용한다.
- M0-7 상태 문서와 업데이트 규칙을 `AGENTS.md` 및 `PLANS.md`에 연결했다.
- M0 부트스트랩 검증 ExecPlan을 `exec-plans/000-bootstrap.md`에 생성했다.
- 모든 저장소 문서는 한글로 작성한다는 지침을 `AGENTS.md`와 `docs/decisions.md`에 기록했다.
- M1-0에서 M0 완료 상태를 확인했다.
- Unity 6000.4.1f1 Editor 로그에서 `Assets/Scenes/SampleScene.unity` 로드와 프로젝트 로딩 완료를 확인했다.
- GitHub `origin` remote와 M0 필수 문서 존재를 확인했다.
- `docs/workflow-plan.md` 초안을 `grill-me` 기반 인터뷰, 공유된 이해 검증, ExecPlan 생성 후 자체 리뷰, 구현 승인 게이트 흐름으로 수정했다.
- `docs/workflow-plan.md` 초안을 승인하고 `AGENTS.md`, `PLANS.md`, `docs/decisions.md`, `docs/current-state.md`에 실제 워크플로우 규칙으로 반영했다.
- M0-M5로 실험 마일스톤 범위를 고정하고 `docs/milestone-roadmap.html`에 시각화했다.
- M3까지 완료하면 실질 성공, M5까지 완료하면 완전 성공으로 보는 판정 기준을 기록했다.
- M1 시작 전 Design Baseline Check와 Design Dependency Check 규칙을 `AGENTS.md`와 `PLANS.md`에 반영했다.
- `docs/design/README.md`를 design 문서 작성 규약으로 추가했다.
- `docs/design/core-beliefs.md`를 첫 번째 baseline 후보 파일로 추가했다.
- 006 이후 발견된 보완점에 따라 `core-beliefs.md`는 인터뷰와 공유된 이해 검증 전에는 design 산출물이 아니라는 규칙을 추가하고, 당시 상태를 `상태: 작성 전`으로 전환했다.
- `docs/design/core-beliefs.md` 작성을 위한 사용자 인터뷰와 공유된 이해 검증을 완료했다.
- `docs/design/core-beliefs.md`를 인터뷰와 보강 요청에 따라 `상태: 초안`으로 작성했다.
- 사용자가 `docs/design/core-beliefs.md`를 승인해 `상태: 승인됨`으로 전환했다.
- M1 First Playable Loop에는 별도 조건부 design 문서가 필요하다고 판단했다.
- M1 gameplay loop design 인터뷰와 공유된 이해 검증을 완료했다.
- `docs/design/gameplay-loop.md`를 `상태: 초안`으로 작성했다.
- 사용자가 `docs/design/gameplay-loop.md`를 승인해 `상태: 승인됨`으로 전환했다.
- 사용자가 M1 ExecPlan 생성을 승인해 `exec-plans/004-first-playable-loop.md`를 생성했다.
- 사용자가 M1 ExecPlan 구현을 승인했다.
- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`와 Unity `.meta` 파일을 추가했다.
- `dotnet build codex-harness-dbz-v0.sln`이 경고 0개, 오류 0개로 통과했다.
- Unity batchmode 검증은 열린 Unity Editor 인스턴스 때문에 중단됐다고 기록했다.
- 사용자 수동 검증 중 로봇, 물건, 목적지가 색상으로만 구분된다는 피드백을 반영해 `BOT`, `BOX`, `GOAL` 표식을 추가했다.

## 다음 단계

열려 있는 Unity Editor에서 `Assets/Scenes/SampleScene.unity` Play Mode를 실행해 이동, Pickup, Deliver, 실패, Retry, Console 오류 여부를 수동 검증한다.

007 이후 M1 완료 전까지는 hooks, MCP, custom skills, subagents, 별도 template 폴더 같은 하네스 확장을 하지 않는다. 단, M1 진행 중 실제 실패가 반복되어 진행이 막힐 때만 보강을 검토한다.

승인된 `docs/design/core-beliefs.md`, `docs/design/gameplay-loop.md`, `exec-plans/004-first-playable-loop.md`를 기준으로 남은 Play Mode 검증을 진행한다.

## 아직 하지 않음

- 게임 명세
- Unity Play Mode 검증
- Unity MCP
- 사용자 정의 skill
- hook
- subagent
- 별도 template 폴더
- 서드파티 패키지
