# 워크플로우 규칙 반영

## 1. 목적

이 계획의 목적은 `docs/workflow-plan.md`의 승인된 워크플로우 초안을 실제 저장소 규칙으로 반영하는 것입니다.

완료 후에는 M1 같은 사소하지 않은 작업을 시작하기 전에 사용자 의도 확인, 공유된 이해 검증, ExecPlan 생성 승인, 구현 승인 게이트를 문서 규칙만 보고 재현할 수 있습니다.

이 작업은 문서 워크플로우만 다루며 게임플레이, Unity 씬, Unity 스크립트, MCP, 사용자 정의 skill, hook, subagent, 외부 패키지를 추가하지 않습니다.

## 2. 진행 상황

- 상태: 완료
- [x] `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, `docs/workflow-plan.md`, 관련 ExecPlan을 읽었다.
- [x] `004` 번호는 M1 First Playable Loop용으로 유지하고 이 계획은 `005-workflow-rule-adoption.md`로 생성했다.
- [x] `AGENTS.md`에 요청 분류, ExecPlan 전 인터뷰, 공유된 이해 검증, 승인 게이트 규칙을 반영한다.
- [x] `PLANS.md`에 ExecPlan 생성 전후 게이트와 자체 리뷰 규칙을 반영한다.
- [x] `docs/decisions.md`에 장기 워크플로우 결정을 기록한다.
- [x] `docs/current-state.md`에 활성 계획과 다음 단계를 갱신한다.
- [x] `docs/workflow-plan.md`의 상태를 승인 및 반영 상태로 갱신한다.
- [x] 문서 검증과 `git diff --check`, `git status --short`를 수행한다.
- [x] 변경 사항을 커밋하고 커밋 후 `git status --short`가 비어 있는지 확인한다.

## 3. 맥락

현재 저장소는 `Codex Harness v0 — Delivery Bot Zero`입니다. M0는 완료되었고, M1 First Playable Loop를 다시 시작하기 전에 `docs/workflow-plan.md` 초안의 승인과 실제 문서 반영이 대기 상태였습니다.

`docs/workflow-plan.md`는 M1 진행 중 사용자 합의 없이 `docs/game-brief.md`, `exec-plans/004-first-playable-loop.md`, `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs` 같은 산출물이 만들어졌던 문제를 배경으로 합니다. 이 저장소의 현재 파일 목록에는 해당 산출물이 없으며, 이번 작업은 그 흐름을 반복하지 않도록 문서 규칙을 정하는 일입니다.

기존 장기 결정에 따라 `exec-plans/004-first-playable-loop.md`는 M1 First Playable Loop용으로 예약되어 있습니다. 따라서 이번 문서 반영 계획은 다음 번호인 `005`를 사용합니다.

사용자가 `docs/workflow-plan.md`를 확인하고 구현을 시작하라고 요청했으므로, 이 계획은 초안 승인과 문서 반영 작업 시작 승인을 받은 상태로 진행합니다.

## 4. 계획

1. `AGENTS.md`에 요청 분류 규칙, 작은 변경 예외, 사소하지 않은 작업의 인터뷰 및 공유된 이해 검증 규칙을 추가한다.
2. `AGENTS.md`에 ExecPlan 생성 승인 게이트와 구현 승인 게이트를 분리해서 기록한다.
3. `PLANS.md`에 ExecPlan 생성 전 인터뷰, 생성 후 자체 리뷰, 사용자 검토용 요약, 기본 `구현 승인 대기` 상태를 반영한다.
4. `docs/decisions.md`에 `grill-me` 기반 인터뷰, 공유된 이해 검증, 분리된 승인 게이트, 외부 skill 비도입 원칙을 장기 결정으로 기록한다.
5. `docs/current-state.md`에 현재 활성 계획을 이 ExecPlan으로 갱신하고, 완료 시에는 활성 계획과 다음 단계를 다시 정리한다.
6. `docs/workflow-plan.md`의 상태를 초안에서 승인 및 반영 완료 상태로 바꾸고, 반영 대상 문서가 갱신되었음을 기록한다.
7. 변경된 문서를 다시 읽고 `git diff --check`, `git status --short`로 검증한다.
8. 검증 결과와 회고를 이 ExecPlan에 반영한다.
9. 변경 사항을 커밋하고 커밋 후 `git status --short`가 비어 있는지 확인한다.

## 5. 검증

계획 완료는 다음 결과로 검증합니다.

- `AGENTS.md`에 요청 분류 규칙이 있다. 결과: 확인됨.
- `AGENTS.md`에 ExecPlan 전 인터뷰와 공유된 이해 검증 규칙이 있다. 결과: 확인됨.
- `AGENTS.md`에 ExecPlan 생성 승인과 구현 승인 게이트가 분리되어 있다. 결과: 확인됨.
- `PLANS.md`에 ExecPlan 생성 전후 게이트, 자체 리뷰, 사용자 검토용 요약 규칙이 있다. 결과: 확인됨.
- `docs/decisions.md`에 워크플로우 규칙 채택 결정이 기록되어 있다. 결과: 확인됨.
- `docs/current-state.md`가 워크플로우 규칙 반영 완료 상태와 다음 단계를 설명한다. 결과: 확인됨.
- `docs/workflow-plan.md`가 더 이상 단순 초안 상태로 남아 있지 않다. 결과: 확인됨.
- `git diff --check`에서 공백 오류가 없다. 결과: 확인됨.
- 커밋 후 `git status --short`가 비어 있다. 결과: 확인됨.

## 6. 결정 기록

- 결정: 이번 워크플로우 규칙 반영 ExecPlan은 `005-workflow-rule-adoption.md`를 사용한다.
- 근거: `004` 번호는 이미 M1 First Playable Loop ExecPlan용으로 예약되어 있어 번호 충돌을 만들지 않아야 한다.
- 날짜: 2026-05-18

- 결정: 사용자의 `docs/workflow-plan.md` 확인 및 구현 시작 요청을 초안 승인과 문서 반영 작업 승인으로 해석한다.
- 근거: 현재 작업은 `workflow-plan.md`가 명시한 반영 대상 문서에 규칙을 적용하는 것이며, 게임플레이나 Unity 구현을 포함하지 않는다.
- 날짜: 2026-05-18

## 7. 예상 밖 발견

- `git diff --check`는 공백 오류 없이 통과했지만, 작업 트리 파일의 LF가 Git 처리 시 CRLF로 바뀔 수 있다는 경고가 표시되었다.

## 8. 회고

완료한 것: `docs/workflow-plan.md`의 승인된 흐름을 `AGENTS.md`, `PLANS.md`, `docs/decisions.md`, `docs/current-state.md`에 실제 규칙으로 반영했다. 새 반영 계획은 `exec-plans/005-workflow-rule-adoption.md`에 기록했다.

완료하지 못한 것: 없음.

배운 것: M1 같은 작업을 시작하기 전에는 계획 작성 승인과 구현 승인을 분리해야 사용자가 검토할 수 있는 지점이 명확해진다.

다음에 해야 할 것: M1을 다시 시작할 때 새 규칙에 따라 먼저 인터뷰와 공유된 이해 검증을 진행하고, 합의 뒤 `exec-plans/004-first-playable-loop.md` 생성 여부를 확인한다.

다음 계획을 시작할 준비: 준비됨.
