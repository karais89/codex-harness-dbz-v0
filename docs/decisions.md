# 결정 사항

## 2026-05-18

### 접두어 기반 실험 이름을 사용한다

결정:
`codex-harness-dbz-v0`를 GitHub 저장소 이름과 Unity 프로젝트 폴더 이름으로 사용한다.

근거:
접두어를 사용하면 실험 유형이 먼저 보이며, 여러 실험 저장소를 쉽게 훑어볼 수 있다.

### 최소 Codex 하네스로 시작한다

결정:
README.md, AGENTS.md, PLANS.md, docs/current-state.md, docs/decisions.md, 활성 표준 Bootstrap ExecPlan 하나를 사용한다.

근거:
M0는 작게 유지해야 한다. MCP, 사용자 정의 skill, hook, subagent는 실제 워크플로우 마찰이 생길 때까지 보류한다.

### 상태 문서와 결정 문서를 AGENTS와 PLANS를 통해 관리한다

결정:
`docs/current-state.md`와 `docs/decisions.md`를 워크플로우 문서로 취급하며, `AGENTS.md`와 `PLANS.md`의 읽기 및 업데이트 규칙에 연결한다.

근거:
상태 문서와 결정 문서는 Codex가 언제 읽고 언제 업데이트해야 하는지 알고 있을 때만 신뢰할 수 있다.

### 계획 내부 결정과 장기 프로젝트 결정을 분리한다

결정:
각 ExecPlan의 `Decision Log` 또는 `결정 기록`에는 해당 계획 안에서 내려진 선택을 기록하고, 단일 계획을 넘어 유지되어야 하는 결정은 `docs/decisions.md`에 기록한다.

근거:
이 방식은 임시 실행 맥락과 장기 프로젝트 규칙을 분리한다.

### 000-bootstrap을 표준 M0 검증 계획으로 사용한다

결정:
`exec-plans/000-bootstrap.md`를 표준 M0 Bootstrap 검증 ExecPlan으로 사용한다.

근거:
M1 첫 플레이 가능 루프 작업을 시작하기 전에 Unity 프로젝트 생성, GitHub 연결, 최소 Codex 하네스 준비 상태를 확인할 안정적인 기준 계획이 M0에 하나 있어야 한다.

### 모든 저장소 문서는 한글로 작성한다

결정:
저장소에 작성하거나 갱신하는 모든 문서는 한글로 작성한다.

근거:
프로젝트 문서 언어를 한글로 통일하면 상태, 결정, 계획을 더 일관되게 읽고 유지할 수 있다.
