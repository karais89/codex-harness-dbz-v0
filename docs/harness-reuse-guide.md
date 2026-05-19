# Codex Harness 재사용 가이드

## 목적

이 문서는 `Codex Harness v0 — Delivery Bot Zero`에서 검증한 최소 Codex 주도 Unity 워크플로우를 다른 프로젝트에 옮길 때 필요한 파일과 초기화 기준을 정리한다.

이 문서는 실제 template 산출물이 아니다. 현재 단계에서는 복사 기준을 문서로 고정하고, 실제 `template/` 폴더는 다른 프로젝트에 한 번 이상 옮겨 본 뒤 반복 복사 대상이 확정되면 만든다.

## 확실히 필요한 파일 트리

다른 Unity 프로젝트에서 최소 Codex 하네스만 재사용하려면 다음 구조를 기준으로 시작한다.

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

이 트리는 문서 하네스의 최소 기준이다. Unity 프로젝트 자체를 복제하는 기준이 아니므로 `Assets/`, `Packages/`, `ProjectSettings/`는 여기의 필수 하네스 파일에 포함하지 않는다.

## 그대로 복사해도 되는 파일

다음 파일은 새 프로젝트에서 큰 구조 변경 없이 가져갈 수 있다. 다만 프로젝트 이름이나 현재 단계 같은 고유 값은 아래 초기화 기준에 따라 바꾼다.

- `.gitignore`: Unity 생성물, `.worktree/`, 로그, 임시 파일 제외 규칙으로 재사용한다.
- `AGENTS.md`: Codex 작업 규칙, 읽기 순서, Design Baseline Check, ExecPlan 흐름을 재사용한다.
- `PLANS.md`: ExecPlan 작성, 승인, 검증, 완료 기준을 재사용한다.
- `docs/design/README.md`: design 문서 상태, Core Beliefs 작성 절차, 강화된 design 템플릿 규약을 재사용한다.

`AGENTS.md`와 `PLANS.md`는 새 프로젝트에서도 하네스의 중심 규칙이다. 단, 프로젝트명, 목표, Unity가 아닌 다른 런타임을 쓰는 경우의 검증 문구는 새 프로젝트에 맞게 조정한다.

## 복사 후 반드시 초기화할 파일

다음 파일은 구조만 재사용하고 내용은 새 프로젝트 기준으로 초기화한다.

- `README.md`
  - 프로젝트 이름과 목표를 새 프로젝트로 바꾼다.
  - 현재 단계는 새 프로젝트의 실제 시작 단계로 바꾼다.
  - 아직 포함하지 않는 도구나 범위를 새 프로젝트 기준으로 다시 적는다.

- `docs/current-state.md`
  - 기존 Delivery Bot Zero 진행 이력은 모두 제거한다.
  - 현재 단계, 활성 계획, 완료됨, 다음 단계, 아직 하지 않음을 새 프로젝트 기준으로 다시 쓴다.
  - 활성 계획은 보통 `exec-plans/000-bootstrap.md`를 가리키게 시작한다.

- `docs/decisions.md`
  - DBZ 전용 결정은 제거한다.
  - 유지할 결정은 문서 언어, ExecPlan 사용, 상태/결정 문서 관리, design 기준 폴더, 사용자 승인 없는 design 승인 금지 같은 하네스 규칙으로 제한한다.
  - 새 프로젝트의 이름 규칙, 도구 채택 또는 보류, 검증 전략은 새로 기록한다.

- `docs/design/core-beliefs.md`
  - 기존 승인본을 그대로 쓰지 않는다.
  - 새 프로젝트에서는 `상태: 작성 전` placeholder로 시작한다.
  - 사용자 인터뷰와 공유된 이해 검증을 거친 뒤에만 `상태: 초안`으로 작성한다.
  - 사용자가 명시적으로 승인하기 전까지 `상태: 승인됨`으로 바꾸지 않는다.

- `exec-plans/000-bootstrap.md`
  - Bootstrap 검증 계획의 구조는 재사용한다.
  - 프로젝트 이름, 저장소 이름, GitHub remote, Unity 버전, 필수 문서 상태, 검증 결과는 새 프로젝트 기준으로 다시 쓴다.
  - 새 프로젝트의 M0 또는 bootstrap 검증이 끝나기 전에는 gameplay 구현을 포함하지 않는다.

## 복사하지 않을 파일

다음 파일은 현재 프로젝트의 이력, 예시, Unity 구현 또는 로컬 생성물이다. 최소 하네스 재사용 목록에는 넣지 않는다.

- `docs/complete-log.md`
- `docs/workflow-plan.md`
- `docs/milestone-roadmap.html`
- `docs/design/gameplay-loop.md`
- `docs/verification/play-mode-checklist.md`
- `exec-plans/001-*.md` 이후의 완료된 ExecPlan들
- `Assets/Scripts/DeliveryBotZero/`
- `Assets/Tests/EditMode/DeliveryBotZero/`
- `.git/`
- `.worktree/`
- `Library/`
- `Temp/`
- `Logs/`
- `UserSettings/`
- Unity가 생성한 `*.csproj`, `*.sln`

`docs/design/gameplay-loop.md`나 완료된 ExecPlan은 참고 예시로 읽을 수는 있지만, 새 프로젝트의 기준 문서로 복사하지 않는다. 새 프로젝트의 player-facing gameplay 기준은 새 사용자 인터뷰와 공유된 이해 검증을 거쳐 별도 design 문서로 만든다.

## 새 프로젝트에서 치환할 값

복사 후 다음 값은 반드시 새 프로젝트 기준으로 바꾼다.

- 프로젝트 이름
- 저장소 이름과 GitHub remote
- Unity 버전
- 현재 마일스톤과 다음 단계
- 활성 ExecPlan
- 아직 포함하지 않을 도구와 범위
- `docs/design/core-beliefs.md`의 상태와 본문
- bootstrap 검증 결과
- 장기 결정의 날짜와 내용

개인의 경력, 가족, 재정, 고용주 관련 민감 정보는 어떤 저장소 문서에도 넣지 않는다.

## `core-beliefs.md` 초기 상태

새 프로젝트의 `docs/design/core-beliefs.md`는 처음에 다음 상태로 둔다.

```md
# Core Beliefs

상태: 작성 전
```

`상태: 작성 전`은 파일이 있어도 design 산출물이 아니라는 뜻이다. Codex는 이 상태의 문서를 gameplay ExecPlan이나 gameplay 구현 기준으로 사용할 수 없다.

Core Beliefs를 작성하려면 먼저 사용자 인터뷰를 진행한다. 질문은 한 번에 하나씩 하고, 각 질문에는 Codex의 추천 답안을 포함한다. 인터뷰 후에는 목표, 성공 기준, 포함 범위, 제외 범위, 제약, 검증 방법, 위험한 가정, 남은 열린 질문, 되돌리기 비싼 결정을 요약해 공유된 이해를 검증한다.

사용자가 공유된 이해가 맞다고 확인한 뒤에만 `상태: 초안`으로 작성한다. 사용자가 명시적으로 승인한 뒤에만 `상태: 승인됨`으로 바꾼다.

## Bootstrap ExecPlan 사용법

새 프로젝트에서 `exec-plans/000-bootstrap.md`는 첫 기준 계획이다.

이 계획은 다음을 확인한다.

- Unity 프로젝트가 존재하고 열리는지.
- Git 저장소와 remote가 준비되었는지.
- `README.md`, `AGENTS.md`, `PLANS.md`가 존재하는지.
- `docs/current-state.md`와 `docs/decisions.md`가 존재하는지.
- `docs/design/README.md`와 `docs/design/core-beliefs.md` placeholder가 존재하는지.
- 작업트리가 clean이거나 남은 변경이 명확히 기록되어 있는지.
- bootstrap 단계에서 gameplay 구현, Unity 씬 변경, 새 패키지, MCP, custom skill, hook, subagent를 추가하지 않았는지.

Bootstrap ExecPlan은 새 프로젝트의 시작 상태를 검증하는 문서다. 첫 gameplay 작업을 시작하려면 bootstrap 검증을 마친 뒤, 승인된 design 기준과 별도 gameplay ExecPlan이 필요하다.

## `template/` 폴더로 승격할 조건

지금은 실제 `template/` 폴더를 만들지 않는다.

다음 조건을 만족하면 나중에 `template/` 폴더 승격을 검토한다.

- 이 가이드 기준으로 두 번째 프로젝트를 실제로 시작해 봤다.
- 복사해야 하는 파일과 초기화해야 하는 파일이 반복적으로 동일하다는 점을 확인했다.
- 루트 문서와 template 복제본이 서로 어긋나지 않게 유지할 방법이 생겼다.
- `template/` 폴더 생성 자체가 다음 프로젝트 시작 시간을 실제로 줄인다는 근거가 있다.

그 전까지는 이 문서를 기준으로 필요한 파일을 새 프로젝트에 옮기고, 새 프로젝트의 상태와 결정은 그 프로젝트의 문서에서 다시 시작한다.
