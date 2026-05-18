# ExecPlan 저장 위치 규칙

## 1. 목적

이 계획의 목적은 이 저장소에서 ExecPlan을 어디에 만들고 어떤 이름으로 유지할지 명확히 정하는 것입니다.

완료 후에는 Codex나 사람 개발자가 사소하지 않은 작업을 시작할 때 ExecPlan을 저장소 루트의 `exec-plans/` 아래에 일관된 파일명으로 만들 수 있습니다.

## 2. 진행 상황

- [x] 현재 `AGENTS.md`와 `PLANS.md`의 ExecPlan 규칙을 확인했다.
- [x] `AGENTS.md`에 ExecPlan 저장 위치 규칙을 추가했다.
- [x] `PLANS.md`에 저장 위치와 파일 이름 규칙을 추가했다.
- [x] `docs/complete-log.md`에 문서 상태를 갱신했다.
- [x] 변경 사항을 검증했다.

## 3. 맥락

현재 저장소에는 `AGENTS.md`, `PLANS.md`, `docs/complete-log.md`가 있습니다.

기존 `AGENTS.md`와 `PLANS.md`는 ExecPlan을 사용해야 하는 조건과 작성 방식은 설명하지만, ExecPlan을 반드시 어느 폴더에 저장해야 하는지는 명시하지 않았습니다.

`docs/current-state.md`와 `docs/decisions.md`는 아직 없습니다.

## 4. 계획

1. `AGENTS.md`의 읽기 순서와 실행 계획 섹션에 `exec-plans/` 위치 규칙을 추가한다.
2. `PLANS.md`에 ExecPlan 저장 위치와 파일 이름 형식을 설명하는 섹션을 추가한다.
3. `docs/complete-log.md`에 M0 문서 상태 갱신 내용을 기록한다.
4. 변경된 문서를 읽고 `git diff`, `git status`로 검증한다.
5. 커밋 후 작업 트리가 clean인지 확인한다.

## 5. 검증

- `AGENTS.md`에 `exec-plans/` 위치 규칙이 있는지 확인했다.
- `PLANS.md`에 `NNN-short-kebab-title.md` 파일명 규칙이 있는지 확인했다.
- `docs/complete-log.md`에 문서 상태 갱신 항목이 있는지 확인했다.
- `git status --short`로 커밋 후 작업 트리가 clean인지 확인한다.

## 6. 결정 기록

- 결정: ExecPlan은 저장소 루트의 `exec-plans/` 아래에 저장한다.
- 근거: 위치가 고정되어야 새 계획 파일이 루트, `docs/`, 임의 경로로 흩어지지 않는다.
- 날짜: 2026-05-18

- 결정: ExecPlan 파일 이름은 `NNN-short-kebab-title.md` 형식을 사용한다.
- 근거: 번호로 순서를 보존하고 짧은 kebab-case 제목으로 내용을 식별하기 쉽다.
- 날짜: 2026-05-18

## 7. 예상 밖 발견

- 기존 문서는 ExecPlan 사용 조건과 필수 섹션은 충분히 설명했지만 저장 위치는 강제하지 않았다.

## 8. 회고

- 완료한 것: ExecPlan 저장 위치와 파일 이름 규칙을 문서화했다.
- 완료하지 못한 것: 없음.
- 배운 것: 프로젝트별 ExecPlan 위치 규칙은 원문 기본 규칙과 별도로 저장소 문서에 명시해야 한다.
- 다음에 해야 할 것: M1부터 새 ExecPlan은 `exec-plans/` 아래에 만든다.
- 다음 계획을 시작할 준비: 준비됨.
