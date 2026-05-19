# 현재 상태

## 프로젝트

Codex Harness v0 — Delivery Bot Zero

## 현재 단계

M0 완료. M1 First Playable Loop 완료. M2 Readability and Regression Check 완료. M3 Verification Loop 완료. M4 Handoff Test 완료. M5 공개 포트폴리오와 회고 패키지 완료. 이 실험은 M0-M3 실질 성공 기준에 도달했고, M5까지 완료해 완전 성공 기준에 도달했다.

M1 시작 전에 전체 시험 범위를 쉽게 확인할 수 있도록 `docs/milestone-roadmap.html`을 추가했다. 이 문서는 M0-M5 마일스톤, 최소/실질/완전 성공 기준, 실패 신호를 시각화한 검토 보조 문서다.

M1 시작 전 design baseline 규칙 도입을 선행 준비 단계로 진행했다. `docs/design/README.md`는 design 문서 작성 규약이다.

006 이후 `core-beliefs.md` 초안 자격 조건을 보강했다. 2026-05-19 사용자 인터뷰와 공유된 이해 검증을 거쳐 `docs/design/core-beliefs.md`를 `상태: 초안`으로 작성했고, 이후 사용자가 명시 승인해 `상태: 승인됨`으로 전환했다.

M1 gameplay loop 인터뷰와 공유된 이해 검증을 거쳐 `docs/design/gameplay-loop.md`를 `상태: 초안`으로 작성했고, 이후 사용자가 명시 승인해 `상태: 승인됨`으로 전환했다. 사용자가 M1 ExecPlan 생성을 승인해 `exec-plans/004-first-playable-loop.md`를 `구현 승인 대기` 상태로 생성했고, 이후 구현을 승인했다.

`Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`는 Play Mode 시작 시 `SampleScene`에 작은 5 x 5 격자, `BOT` 표식의 로봇, `BOX` 표식의 물건, `GOAL` 표식의 목적지, 막힌 칸, 최소 UI, Retry 버튼을 runtime으로 구성한다. M2에서는 목표 문구, `Turns Left`, `Cargo`, `Status`, `Retry Level` 라벨로 UI 읽기성을 개선했다. 수동 검증 중 Failed 상태의 Status 문구가 너무 길어 보드 위에 출력되는 문제가 발견되어 상태 문구를 더 짧게 줄였다. `dotnet build codex-harness-dbz-v0.sln`은 수정 후에도 경고 0개, 오류 0개로 통과했다. Unity batchmode 검증은 열린 Unity Editor 인스턴스 때문에 중단됐고, 열린 Editor 로그에서는 assembly reload 성공과 새 C# 컴파일 오류 없음이 확인됐다. 사용자가 열린 Unity Editor에서 M2 Play Mode 수동 검증을 진행했고, M2 읽기성 확인과 M1 회귀 동작, Console 오류 확인이 모두 통과했다.

## 활성 계획

없음. M5 공개 포트폴리오와 회고 패키지 계획 `exec-plans/012-m5-portfolio-retrospective-package.md`는 완료되었다. 이 계획은 Delivery Bot Zero를 완성 게임처럼 확장하지 않고, Codex 기반 Unity 워크플로우 실험 사례로 외부에 보여줄 수 있도록 README, 실행/조작 방법, M1-M4 결과 요약, 하네스 회고, public repo 점검, 다음 프로젝트 규칙 정리를 문서 중심으로 패키징한 작업이다. 플레이 영상 또는 GIF 준비 항목, 새 gameplay 기능, 새 레벨, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가는 범위에서 제외했다.

하네스 재사용 가이드 작성 계획 `exec-plans/011-harness-reuse-guide.md`는 완료되었다. 이 계획은 다른 프로젝트에서 이 하네스를 재사용할 때 필요한 파일, 초기화할 파일, 제외할 파일, `core-beliefs.md` 초기 상태, bootstrap ExecPlan 사용법을 `docs/harness-reuse-guide.md`로 정리한 문서 보강 작업이다.

M4 Handoff Test는 완료되었다. 새 Codex 세션 관점에서 `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, `docs/design/README.md`, `docs/design/core-beliefs.md`, `docs/design/gameplay-loop.md`, `docs/verification/play-mode-checklist.md`, 완료된 ExecPlan을 읽고 현재 프로젝트 상태를 요약할 수 있음을 확인했다. 판정은 Pass다.

Design 템플릿 강화 계획 `exec-plans/010-design-template-strengthening.md`는 완료되었다. 이 계획은 `docs/design/README.md`의 Core Beliefs 템플릿과 조건부 design 문서 템플릿을 강화하고, 강화된 템플릿을 신규 또는 갱신 design 문서부터 적용하도록 명확히 한 하네스 규약 보강 작업이다.

M3 Verification Loop 계획 `exec-plans/009-m3-verification-loop.md`는 완료되었다. M3는 Play Mode 수동 검증 절차를 재사용 가능한 체크리스트로 고정하고, 기존 M1/M2 gameplay 규칙을 작은 순수 로직으로 분리해 Edit Mode 테스트로 반복 검증할 수 있게 만든 단계다.

`docs/verification/play-mode-checklist.md`를 추가했고, `Assets/Scripts/DeliveryBotZero/DeliveryLoopState.cs`로 기존 gameplay 규칙을 분리했으며, `Assets/Tests/EditMode/DeliveryBotZero/Editor/DeliveryLoopStateTests.cs`에 Edit Mode 테스트 6개를 추가했다. `dotnet build codex-harness-dbz-v0.sln`은 로컬 Unity 생성 csproj에 새 파일을 임시 포함한 뒤 경고 0개, 오류 0개로 통과했다. Unity batchmode Edit Mode 테스트는 열린 Unity Editor 인스턴스 때문에 중단됐지만, 사용자가 열린 Unity Editor의 Edit Mode Test Runner에서 6개 테스트 항목이 모두 통과했다고 확인했다. 이후 사용자가 `docs/verification/play-mode-checklist.md`의 모든 항목이 통과했다고 확인했다.

M2 Readability and Regression Check 계획 `exec-plans/008-m2-readability-regression-check.md`는 완료되었다.

M1 First Playable Loop 계획 `exec-plans/004-first-playable-loop.md`는 완료되었다.

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
- 표식 추가 후 글자가 칸을 침범한다는 사용자 피드백을 반영해 표식 크기를 줄였다.
- 사용자가 Unity Play Mode에서 M1 수동 검증 10단계를 모두 통과했다고 확인했다.
- `exec-plans/004-first-playable-loop.md`를 `완료됨` 상태로 전환했다.
- 사용자가 M2 ExecPlan 생성을 승인해 `exec-plans/008-m2-readability-regression-check.md`를 생성했다.
- 사용자가 M2 ExecPlan 구현을 승인했다.
- M2 UI 읽기성 개선으로 목표 문구, `Turns Left`, `Cargo`, `Status`, `Retry Level` 라벨을 반영했다.
- M2 수동 검증 중 긴 Status 문구가 보드 위에 출력되는 문제를 발견했고, 상태 문구를 더 짧게 수정했다.
- 사용자가 Unity Play Mode에서 M2 읽기성 확인과 M1 회귀 검증을 모두 통과했다고 확인했다.
- `exec-plans/008-m2-readability-regression-check.md`를 `완료됨` 상태로 전환했다.
- 사용자가 M3 ExecPlan 생성을 승인해 `exec-plans/009-m3-verification-loop.md`를 생성했다.
- 사용자가 M3 ExecPlan 구현 시작을 승인했다.
- `docs/verification/play-mode-checklist.md`를 추가했다.
- `Assets/Scripts/DeliveryBotZero/DeliveryLoopState.cs`와 Unity `.meta` 파일을 추가했다.
- `FirstPlayableLoop.cs`가 기존 gameplay 규칙을 `DeliveryLoopState`로 위임하도록 수정했다.
- `Assets/Tests/EditMode/DeliveryBotZero/Editor/DeliveryLoopStateTests.cs`와 테스트 폴더 `.meta` 파일을 추가했다.
- `dotnet build codex-harness-dbz-v0.sln`은 로컬 Unity 생성 csproj 갱신 후 경고 0개, 오류 0개로 통과했다.
- Unity batchmode Edit Mode 테스트는 열린 Unity Editor 인스턴스 때문에 중단됐다.
- 사용자가 열린 Unity Editor의 Edit Mode Test Runner에서 `DeliveryLoopStateTests` 6개 항목이 모두 통과했다고 확인했다.
- 사용자가 M3 리팩터 후 `docs/verification/play-mode-checklist.md`의 모든 항목이 통과했다고 확인했다.
- `exec-plans/009-m3-verification-loop.md`를 `완료됨` 상태로 전환했다.
- 사용자가 design 템플릿 강화 계획 생성을 승인해 `exec-plans/010-design-template-strengthening.md`를 생성했다.
- 사용자가 design 템플릿 강화 계획 구현 시작을 승인했다.
- `docs/design/README.md`의 Core Beliefs 템플릿에 프로젝트 정체성, 플레이어 경험 방향, 성공과 실패 판단 기준, Codex가 임의로 확정하지 않을 것, 아직 정하지 않을 것 섹션을 추가했다.
- `docs/design/README.md`의 조건부 design 문서 템플릿에 플레이어 경험 기준, 검증 기준, Codex 금지 사항 섹션을 추가했다.
- 강화된 design 템플릿은 신규 또는 갱신 design 문서부터 적용하고, 기존 승인 design 문서에는 자동 소급 적용하지 않는다고 명시했다.
- 강화된 design 템플릿 적용 방식을 `docs/decisions.md`에 장기 결정으로 기록했다.
- `exec-plans/010-design-template-strengthening.md`를 `완료됨` 상태로 전환했다.
- 사용자가 하네스 재사용 가이드 작성 계획 생성을 승인해 `exec-plans/011-harness-reuse-guide.md`를 생성했다.
- 사용자가 하네스 재사용 가이드 작성 계획 구현 시작을 승인했다.
- `docs/harness-reuse-guide.md`를 추가해 다른 프로젝트에서 사용할 최소 하네스 파일 트리, 초기화할 파일, 제외할 파일, 새 프로젝트에서 치환할 값, `core-beliefs.md` 초기 상태, bootstrap ExecPlan 사용법을 정리했다.
- 실제 `template/` 폴더는 아직 만들지 않고, 먼저 `docs/harness-reuse-guide.md`를 재사용 기준 문서로 유지하기로 했다.
- 하네스 재사용 기준을 문서 가이드로 유지하는 결정을 `docs/decisions.md`에 기록했다.
- `exec-plans/011-harness-reuse-guide.md`를 `완료됨` 상태로 전환했다.
- M4 Handoff Test에서 저장소 문서만으로 현재 상태, 완료된 마일스톤, Unity Play Mode 동작, 승인된 design 기준, ExecPlan 없이 진행하면 안 되는 작업, 검증 위치, 다음 추천 작업, 문서상 누락을 요약할 수 있음을 확인했다.
- M4 Handoff Test 판정을 Pass로 기록했다.
- 사용자가 M5 ExecPlan 생성을 승인해 `exec-plans/012-m5-portfolio-retrospective-package.md`를 생성했다.
- 사용자가 M5 ExecPlan 구현 시작을 승인했다.
- `README.md`를 외부 공개 기준에서 Codex 기반 Unity 워크플로우 실험 사례를 설명하는 문서로 개선했다.
- README에 Unity 6000.4.1f1 실행 방법, `Assets/Scenes/SampleScene.unity` 진입, Play Mode 시작, `WASD`/방향키 조작, `Retry Level` 버튼 사용법을 정리했다.
- README에 M1-M5 마일스톤 결과와 주요 문서 구조를 정리했다.
- `docs/harness-retrospective.md`를 추가해 M1-M4 요약, 잘 작동한 규칙, 마찰, Codex가 실수하기 쉬운 지점, 사람이 맡아야 했던 Unity 검증, 다음 프로젝트에 가져갈 규칙과 완화할 규칙을 정리했다.
- `docs/public-repo-checklist.md`를 추가해 민감 정보, 로컬 전용 정보, Unity 생성물, M5 범위 준수 여부를 점검했다.
- M5에서 플레이 영상 또는 GIF 준비 항목, 새 gameplay 기능, 새 레벨, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가를 하지 않았다.

## 다음 단계

이 실험의 M0-M5 마일스톤은 완료되었다.

다음 작업은 이 저장소 안의 새 gameplay 확장이 아니라, 필요할 때 별도 계획으로 진행할 수 있다. 후보는 두 번째 작은 Unity 프로젝트에 하네스를 옮겨 보기, 실제 GitHub 공개 전 라이선스 결정, 선택적 플레이 GIF 추가 여부 검토다.

## 아직 하지 않음

- 게임 명세
- Unity MCP
- 사용자 정의 skill
- hook
- subagent
- 별도 template 폴더
- 서드파티 패키지
