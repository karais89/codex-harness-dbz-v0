# 하네스 재사용 가이드 작성

## 목적

이 ExecPlan의 목적은 현재까지 검증한 Codex Harness v0 문서 구조를 다른 프로젝트에서 재사용할 때 필요한 기준을 `docs/harness-reuse-guide.md`로 정리하는 것이다.

완료 후에는 새 프로젝트에서 어떤 파일을 확실히 가져가야 하는지, 어떤 파일은 초기화해야 하는지, 어떤 파일은 가져가지 않아야 하는지, `core-beliefs.md`와 bootstrap ExecPlan을 어떤 상태로 시작해야 하는지 한 문서에서 확인할 수 있다.

이 계획은 실제 `template/` 폴더를 만들거나, 하네스 파일을 복제하거나, Unity 코드와 씬을 수정하는 계획이 아니다. 현재 단계에서는 재사용 기준을 Markdown 문서로 고정하고, 실제 템플릿 폴더 승격은 이후 다른 프로젝트에 옮겨 본 뒤 검토한다.

## 진행 상황

상태: 완료됨

- [x] M3 완료와 design 템플릿 강화 완료 상태를 확인했다.
- [x] 하네스 재사용 정리 방식으로 Markdown 문서가 적절한지 논의했다.
- [x] 공유된 이해 검증을 완료했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공한다.
- [x] 사용자가 구현 시작을 승인했다.
- [x] 구현 시작 후 상태를 `진행 중`으로 갱신했다.
- [x] 작업 전 `git status --short`를 재확인했다.
- [x] `docs/harness-reuse-guide.md`를 추가했다.
- [x] 가이드에 확실히 필요한 하네스 파일 트리를 정리했다.
- [x] 그대로 복사 가능한 파일과 복사 후 초기화할 파일을 구분했다.
- [x] 복사하지 않을 파일과 실제 `template/` 폴더 생성을 보류하는 이유를 정리했다.
- [x] 새 프로젝트에서 치환할 값과 `core-beliefs.md` 초기 상태를 정리했다.
- [x] bootstrap ExecPlan 사용법을 정리했다.
- [x] `docs/current-state.md`를 구현 결과에 맞게 갱신했다.
- [x] 필요한 경우 `docs/decisions.md`에 재사용 가이드 유지 결정을 기록했다.
- [x] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록했다.
- [x] 구현 완료 커밋 후 `git status --short`가 clean임을 확인한다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

M3 Verification Loop는 완료되었고, 이 실험은 M0-M3 실질 성공 기준에 도달했다. 이후 `exec-plans/010-design-template-strengthening.md`를 통해 `docs/design/README.md`의 Core Beliefs 템플릿과 조건부 design 문서 템플릿을 강화했다.

사용자는 이 하네스를 다른 곳에서 사용할 때 재사용 가능한 파일 목록을 쉽게 확인할 수 있는 정리 문서를 원한다. 이전 논의에서 확실히 필요한 하네스 구조는 다음으로 좁혔다.

```text
codex-harness-template/
├─ .gitignore
├─ README.md
├─ AGENTS.md
├─ PLANS.md
├─ docs/
│  ├─ current-state.md
│  ├─ decisions.md
│  └─ design/
│     ├─ README.md
│     └─ core-beliefs.md
└─ exec-plans/
   └─ 000-bootstrap.md
```

이 목록은 실제 복제 폴더가 아니라 다른 프로젝트에 옮길 때의 기준이다. `docs/complete-log.md`, `docs/workflow-plan.md`, `docs/milestone-roadmap.html`, `docs/design/gameplay-loop.md`, 완료된 `exec-plans/001` 이후 파일들은 현재 프로젝트의 이력 또는 예시로 보고 필수 재사용 목록에서 제외한다.

관련 파일과 폴더는 다음과 같다.

- `docs/harness-reuse-guide.md`: 새로 만들 가이드 문서다.
- `docs/current-state.md`: 활성 계획과 완료 결과를 기록한다.
- `docs/decisions.md`: 재사용 가이드를 문서로 유지하고 `template/` 폴더 생성을 보류하는 결정이 장기 규칙이면 기록한다.
- `docs/design/README.md`: 강화된 design 템플릿 규약이 들어 있다.
- `exec-plans/011-harness-reuse-guide.md`: 이 계획 파일이다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 `docs/harness-reuse-guide.md`를 만들지 않고, 기존 하네스 문서를 복제하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리 상태를 확인한다.
   - `docs/design/README.md`, `docs/current-state.md`, `docs/decisions.md`, `exec-plans/010-design-template-strengthening.md`가 존재하는지 확인한다.
   - 이전 논의에서 제외하기로 한 문서들이 재사용 필수 트리에 들어가지 않도록 확인한다.

3. `docs/harness-reuse-guide.md`를 작성한다.
   - 문서는 한글 Markdown으로 작성한다.
   - 다음 섹션을 포함한다.
     - 목적
     - 확실히 필요한 파일 트리
     - 그대로 복사해도 되는 파일
     - 복사 후 반드시 초기화할 파일
     - 복사하지 않을 파일
     - 새 프로젝트에서 치환할 값
     - `core-beliefs.md` 초기 상태
     - bootstrap ExecPlan 사용법
     - 나중에 `template/` 폴더로 승격할 조건
   - 가이드가 실제 template 산출물이 아니라 재사용 기준 문서임을 명시한다.

4. 현재 상태와 장기 결정을 갱신한다.
   - `docs/current-state.md`에 `docs/harness-reuse-guide.md` 추가와 계획 완료 상태를 기록한다.
   - 재사용 가이드를 문서로 유지하고 실제 `template/` 폴더는 보류한다는 방향이 장기 결정이면 `docs/decisions.md`에 기록한다.

5. 검증하고 마무리한다.
   - `docs/harness-reuse-guide.md`가 존재하는지 확인한다.
   - 문서에 확실히 필요한 파일 트리와 제외 파일 목록이 모두 있는지 확인한다.
   - 문서에 `template/` 폴더 보류 이유와 승격 조건이 있는지 확인한다.
   - 이 ExecPlan의 진행 상황, 검증 결과, 결정 기록, 회고를 갱신한다.
   - 최종적으로 커밋하고 `git status --short`가 clean인지 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- `docs/harness-reuse-guide.md`가 존재한다.
- 가이드에 확실히 필요한 하네스 파일 트리가 포함된다.
- 가이드가 `docs/complete-log.md`, `docs/workflow-plan.md`, `docs/milestone-roadmap.html`, `docs/design/gameplay-loop.md`, 완료된 추가 ExecPlan들을 필수 재사용 목록에서 제외한다.
- 가이드가 그대로 복사할 파일과 초기화할 파일을 구분한다.
- 가이드가 새 프로젝트에서 치환할 값과 `core-beliefs.md`의 초기 상태를 설명한다.
- 가이드가 `exec-plans/000-bootstrap.md` 사용법을 설명한다.
- 가이드가 지금은 실제 `template/` 폴더를 만들지 않고, 나중에 승격할 조건을 설명한다.
- `docs/current-state.md`가 이번 계획 상태와 다음 단계를 반영한다.
- 필요한 경우 `docs/decisions.md`가 재사용 가이드 유지 결정을 기록한다.
- 이 ExecPlan의 진행 상황, 결정 기록, 예상 밖 발견, 회고가 갱신된다.
- 최종 커밋 후 `git status --short`가 clean이다.

현재 검증 결과:

- ExecPlan 생성 전 `git status --short`: 출력 없음. 작업트리 clean.
- 구현 시작 후 `git status --short`: `README.md`와 `docs/current-state.md`의 기존 M4 완료 반영 변경, `exec-plans/011-harness-reuse-guide.md` 추가가 확인됐다. 기존 M4 완료 반영 변경은 되돌리지 않고 보존했다.
- `docs/current-state.md`는 M3 완료와 `exec-plans/010-design-template-strengthening.md` 완료를 기록한다.
- `docs/decisions.md`는 강화된 design 템플릿 적용 방식을 장기 결정으로 기록한다.
- `docs/harness-reuse-guide.md`를 추가했다.
- `docs/harness-reuse-guide.md`에 확실히 필요한 하네스 파일 트리, 그대로 복사해도 되는 파일, 초기화할 파일, 복사하지 않을 파일, 새 프로젝트에서 치환할 값, `core-beliefs.md` 초기 상태, bootstrap ExecPlan 사용법, `template/` 폴더 승격 조건을 포함했다.
- `docs/harness-reuse-guide.md`는 `docs/complete-log.md`, `docs/workflow-plan.md`, `docs/milestone-roadmap.html`, `docs/design/gameplay-loop.md`, `docs/verification/play-mode-checklist.md`, 완료된 추가 ExecPlan들을 최소 하네스 재사용 목록에서 제외한다고 명시한다.
- `docs/current-state.md`에 `exec-plans/011-harness-reuse-guide.md` 완료와 다음 마일스톤 M5를 기록했다.
- `docs/decisions.md`에 하네스 재사용 기준은 먼저 문서 가이드로 유지하고 실제 `template/` 폴더 생성은 보류한다는 결정을 기록했다.
- 최종 커밋에는 기존 M4 문서 상태 반영 변경과 이번 하네스 재사용 가이드 변경을 함께 포함했다.
- 최종 커밋 후 `git status --short`: 출력 없음. 작업트리 clean.

## 자체 리뷰

- 공유된 이해 검증 내용과 ExecPlan 내용이 일치한다.
- 목표는 하네스 재사용 기준을 Markdown 문서로 정리하는 것으로 제한되어 있다.
- 포함 범위는 `docs/harness-reuse-guide.md`, `docs/current-state.md`, 필요한 경우 `docs/decisions.md`, 이 ExecPlan 갱신으로 제한되어 있다.
- 제외 범위는 실제 `template/` 폴더 생성, HTML 문서 생성, 기존 하네스 파일 복제, Unity 코드/씬 변경, gameplay 설계 변경, M4 시작으로 명시되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있다.
- 구현 승인 전에는 새 가이드 문서 생성을 시작하지 않도록 계획에 명시했다.
- 완료 기준은 문서 존재, 필수 트리와 제외 목록 포함, 상태/결정 문서 갱신, `git status` 확인으로 관찰 가능하다.

## 결정 기록

- 결정: 하네스 재사용 정리는 지금 단계에서 실제 `template/` 폴더가 아니라 `docs/harness-reuse-guide.md` 문서로 시작한다.
  근거: 아직 두 번째 프로젝트에 실제로 옮겨 보지 않았으므로, 루트 문서와 template 복제본을 동시에 유지하면 문서가 어긋날 위험이 있다. 먼저 재사용 기준을 문서로 고정하고, 반복 복사할 파일이 확인되면 template 폴더 승격을 검토하는 편이 작고 검증 가능하다.
  날짜: 2026-05-19

## 예상 밖 발견

- 구현 시작 시 `README.md`와 `docs/current-state.md`에 M4 Handoff Test 완료를 반영한 기존 변경이 이미 있었다. 이번 계획에서는 해당 변경을 되돌리지 않고, 하네스 재사용 가이드 작성 상태를 그 위에 이어서 반영했다.

## 회고

하네스 재사용 가이드 작성을 완료했다.

- 완료한 것: `docs/harness-reuse-guide.md`를 추가해 최소 하네스 파일 트리, 초기화할 파일, 제외할 파일, 새 프로젝트 치환값, `core-beliefs.md` 초기 상태, bootstrap ExecPlan 사용법, `template/` 폴더 승격 조건을 정리했다.
- 완료하지 못한 것: 없음. 실제 `template/` 폴더, HTML 문서, 기존 하네스 파일 복제, Unity 코드와 씬 변경은 의도적으로 하지 않았다.
- 배운 것: 현재 단계에서는 복제 가능한 산출물보다 재사용 판단 기준을 문서로 고정하는 편이 유지보수 위험이 낮다.
- 다음에 해야 할 것: M5 공개 가능한 포트폴리오 패키징 범위를 논의한다.
- 다음 계획을 시작할 준비가 되었는지 여부: 예. M5는 별도 논의와 ExecPlan 승인 뒤 시작한다.
