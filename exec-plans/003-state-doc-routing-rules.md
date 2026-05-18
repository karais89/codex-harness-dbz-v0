# 상태 문서 라우팅 규칙

## 1. 목적

이 계획의 목적은 `docs/current-state.md`와 `docs/decisions.md`가 단순한 문서 파일이 아니라 Codex 작업 흐름에서 읽히고 갱신되는 상태 관리 문서가 되도록 규칙을 연결하는 것입니다.

완료 후에는 새 Codex 세션이나 사람 개발자가 현재 프로젝트 상태, 활성 계획, 다음 단계, 장기 결정을 저장소 문서만 보고 파악할 수 있습니다.

## 2. 진행 상황

- [x] `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, 기존 ExecPlan을 읽었다.
- [x] M0-7 범위를 파일 생성에서 상태 문서와 갱신 규칙 추가로 재정의했다.
- [x] `AGENTS.md`에 `docs/decisions.md` 읽기 규칙과 상태 문서 갱신 조건을 추가했다.
- [x] `PLANS.md`에 ExecPlan 결정 기록과 `docs/decisions.md`의 역할 차이를 명시했다.
- [x] `docs/current-state.md`를 현재 상태, 활성 계획, 다음 단계가 드러나도록 갱신했다.
- [x] `docs/decisions.md`에 상태 문서 라우팅 결정을 기록했다.
- [x] `docs/complete-log.md`의 M0-7 완료 기준을 워크플로우 연결 기준으로 갱신했다.
- [x] 변경 사항을 검증하고 이 ExecPlan에 결과를 반영했다.
- [x] 변경 사항을 커밋하고 `git status --short`가 비어 있는지 확인했다.

## 3. 맥락

현재 저장소는 Unity 2D 퍼즐 게임 `Delivery Bot Zero`를 사용해 최소 Codex 하네스 기반 개발 워크플로우를 검증하는 M0 단계입니다.

관련 문서 상태:

- `AGENTS.md`는 파일 변경 전 `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, 현재 ExecPlan을 읽도록 지시하지만 `docs/decisions.md` 읽기 규칙은 빠져 있다.
- `PLANS.md`는 ExecPlan 작성 또는 수정 전 `docs/current-state.md`와 `docs/decisions.md`를 읽도록 지시하고, 완료 기준에도 상태 문서와 결정 문서 갱신 조건을 일부 포함한다.
- `docs/current-state.md`와 `docs/decisions.md`는 존재하지만, 현재 작업 흐름에서 언제 읽고 언제 갱신해야 하는지 `AGENTS.md`에는 충분히 연결되어 있지 않다.
- `docs/complete-log.md`의 M0-7 완료 기준은 파일 존재 중심이라 라우팅 규칙 연결 여부를 검증하지 못한다.

이 작업은 문서 워크플로우 정리만 다룹니다. 게임플레이, Unity 씬, Unity 스크립트, MCP, custom skill, hook, subagent, 외부 패키지를 추가하지 않습니다.

## 4. 계획

1. `AGENTS.md`의 먼저 읽기 순서에 `docs/decisions.md`를 추가한다.
2. `AGENTS.md`에 상태 문서 갱신 조건을 설명하는 문서 갱신 섹션을 추가한다.
3. `PLANS.md`에 ExecPlan 결정 기록과 `docs/decisions.md`의 역할 차이를 명시한다.
4. `docs/current-state.md`에 `Active Plan`, 현재 다음 단계, 아직 하지 않을 일을 정리한다.
5. `docs/decisions.md`에 상태 문서 라우팅과 결정 기록 분리 원칙을 장기 결정으로 기록한다.
6. `docs/complete-log.md`의 M0-7 항목을 파일 존재가 아니라 워크플로우 연결 기준으로 갱신한다.
7. 문서 내용을 다시 읽고 `git diff`, `git status --short`로 검증한다.
8. 변경 사항을 커밋하고 커밋 후 `git status --short`가 비어 있는지 확인한다.

## 5. 검증

계획 완료는 다음 결과로 검증한다.

- `AGENTS.md`에 `docs/current-state.md`와 `docs/decisions.md`를 읽는 규칙이 있다. 결과: 확인됨.
- `AGENTS.md`에 두 상태 문서를 언제 갱신해야 하는지 설명되어 있다. 결과: 확인됨.
- `PLANS.md`에 ExecPlan 결정 기록과 `docs/decisions.md`의 관계가 설명되어 있다. 결과: 확인됨.
- `docs/current-state.md`에 `Current Stage`, `Active Plan`, `Next Step`이 있다. 결과: 확인됨.
- `docs/decisions.md`에 상태 문서 라우팅 관련 장기 결정이 기록되어 있다. 결과: 확인됨.
- `docs/complete-log.md`의 M0-7 완료 기준이 상태 문서와 갱신 규칙을 검증한다. 결과: 확인됨.
- `git diff --check`에서 공백 오류가 없다. 결과: 확인됨.
- `git status --short`가 커밋 후 비어 있다. 결과: 확인됨.

## 6. 결정 기록

- 결정: M0-7은 단순 파일 생성이 아니라 최소 상태 문서와 갱신 규칙을 연결하는 작업으로 정의한다.
- 근거: 상태 문서가 존재해도 읽기와 갱신 조건이 없으면 다음 Codex 세션에서 신뢰할 수 있는 워크플로우 입력이 되지 않는다.
- 날짜: 2026-05-18

- 결정: `docs/current-state.md`에는 현재 단계, 활성 계획, 다음 단계를 명시한다.
- 근거: 새 세션이 현재 어떤 계획을 읽고 무엇을 이어서 해야 하는지 빠르게 판단할 수 있어야 한다.
- 날짜: 2026-05-18

- 결정: ExecPlan의 결정 기록은 해당 계획 내부의 판단을 기록하고, `docs/decisions.md`는 계획을 넘어 지속되는 프로젝트 결정을 기록한다.
- 근거: 두 문서의 역할이 겹치면 장기 규칙과 일회성 계획 판단이 섞인다.
- 날짜: 2026-05-18

## 7. 예상 밖 발견

- 작업 시작 시 `docs/complete-log.md`, `docs/current-state.md`가 수정되어 있었고 `docs/decisions.md`는 아직 Git 추적 대상이 아니었다.
- `docs/current-state.md`의 작업 트리 버전은 이전 worktree smoke test 내용을 포함하지 않는 단순 M0 상태로 바뀌어 있었다.

## 8. 회고

완료한 것: `AGENTS.md`의 읽기 순서와 문서 갱신 규칙을 보강했고, `PLANS.md`에 ExecPlan 결정 기록과 `docs/decisions.md`의 역할 차이를 명시했다. `docs/current-state.md`, `docs/decisions.md`, `docs/complete-log.md`도 M0-7의 실제 완료 기준에 맞게 갱신했다.

완료하지 못한 것: 없음.

배운 것: 상태 문서는 파일 존재보다 라우팅 규칙과 갱신 조건이 중요하다.

다음에 해야 할 것: 다음 사소하지 않은 작업을 시작하기 전에 새 ExecPlan을 만든다.

다음 계획을 시작할 준비: 준비됨.
