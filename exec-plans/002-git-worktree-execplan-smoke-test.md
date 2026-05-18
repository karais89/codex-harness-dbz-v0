# Git worktree + ExecPlan smoke test

## 1. 목적

이 계획의 목적은 이 저장소에서 `git worktree`를 사용하는 작업 흐름과 ExecPlan 갱신 절차가 함께 작동하는지 작은 문서 중심 변경으로 확인하는 것입니다.

완료 후에는 저장소 루트의 `.worktree/` 아래에 테스트 worktree를 만들 수 있고, 그 보관 폴더가 Git 추적 대상에서 제외되며, smoke test 결과가 프로젝트 상태 문서와 이 ExecPlan에 남아 있습니다.

## 2. 진행 상황

- [x] `README.md`, `AGENTS.md`, `PLANS.md`, 현재 `exec-plans/001-execplan-storage-convention.md`를 읽었다.
- [x] `docs/current-state.md`가 아직 없음을 확인했다.
- [x] 기존 worktree 목록과 `test/execplan-smoke` 브랜치 존재 여부를 확인했다.
- [x] 이 ExecPlan을 구현 전에 생성했다.
- [x] `.gitignore`에 `.worktree/` 보관 폴더 규칙을 추가한다.
- [x] `docs/current-state.md`에 `.worktree/` 관례와 smoke test 결과를 기록한다.
- [x] 테스트용 worktree를 생성한다.
- [x] 요구된 검증 명령을 실행한다.
- [x] 실제 결과를 이 ExecPlan에 반영한다.
- [x] 변경 사항을 커밋하고 루트 작업 트리가 clean인지 확인한다.

## 3. 맥락

현재 저장소는 Unity 2D 퍼즐 게임 `Delivery Bot Zero`의 최소 Codex 하네스 검증용 저장소입니다.

현재 문서와 계획 상태:

- `README.md`는 M0 단계와 아직 포함하지 않는 항목을 설명한다.
- `AGENTS.md`는 파일 변경 전 필수 읽기 순서와 ExecPlan 사용 규칙을 정의한다.
- `PLANS.md`는 ExecPlan 필수 섹션, 갱신 방식, 완료 기준을 정의한다.
- `docs/current-state.md`는 처음에는 없었고, 이 작업에서 생성했다.
- `exec-plans/001-execplan-storage-convention.md`는 ExecPlan 저장 위치와 파일 이름 규칙을 완료한 이전 계획이다.

초기 확인 결과:

- `git worktree list`에는 루트 worktree만 있었다.
- `git status --short` 출력은 비어 있었다.
- `git branch --list test/execplan-smoke` 출력은 비어 있었다.

실행 결과:

- `git worktree add .worktree/execplan-smoke -b test/execplan-smoke`가 성공했다.
- `git worktree list`에는 루트 worktree `main`과 `.worktree/execplan-smoke` worktree `test/execplan-smoke`가 표시되었다.
- 루트의 `git status --short`는 커밋 전 기대한 문서 변경만 표시했다.
- `.worktree/execplan-smoke` 내부의 `git status --short`는 비어 있었다.
- 커밋 후 루트의 `git status --short`는 비어 있었다.

이 작업은 워크플로우 smoke test이므로 게임플레이, Unity 씬, Unity 스크립트, MCP, custom skill, hook, subagent, 외부 패키지를 추가하지 않는다.

## 4. 계획

1. `.gitignore`에 저장소 루트 기준 `.worktree/` 규칙을 추가한다.
2. `docs/current-state.md`를 생성하고 `.worktree/` 보관 관례, 테스트 목적, 예상 검증 절차를 기록한다.
3. `git worktree add .worktree/execplan-smoke -b test/execplan-smoke`를 실행한다.
4. 요구된 검증 명령을 실행한다.
   - `git worktree list`
   - 루트의 `git status --short`
   - `.worktree/execplan-smoke` 내부의 `git status --short`
5. 실제 명령 결과와 발견 사항을 `docs/current-state.md`와 이 ExecPlan에 반영한다.
6. 변경 사항을 커밋한다.
7. 커밋 후 루트의 `git status --short`가 clean인지 확인한다.

## 5. 검증

계획 완료는 다음 관찰 가능한 결과로 검증한다.

- `.gitignore`에 `.worktree/`가 있다. 결과: 확인됨.
- `.worktree/execplan-smoke` worktree가 존재한다. 결과: `git worktree add` 성공.
- `git worktree list`에 루트 worktree와 `.worktree/execplan-smoke`가 표시된다. 결과: 확인됨.
- 루트의 `git status --short`가 커밋 전에는 문서 변경만 보여 준다. 결과: `.gitignore`, `docs/current-state.md`, `exec-plans/002-git-worktree-execplan-smoke-test.md`만 표시됨.
- 루트의 `git status --short`가 커밋 후에는 비어 있다. 결과: 확인됨.
- `.worktree/execplan-smoke` 내부의 `git status --short`가 비어 있다. 결과: 확인됨.
- `docs/current-state.md`와 이 ExecPlan에 smoke test 결과가 기록되어 있다. 결과: 확인됨.

## 6. 결정 기록

- 결정: 테스트 worktree 보관 위치는 요청된 저장소 루트 아래 `.worktree/`를 사용한다.
- 근거: 루트 아래에 위치를 고정하고 `.gitignore`로 제외하면 임시 worktree가 프로젝트 파일 추적과 섞이지 않는다.
- 날짜: 2026-05-18

- 결정: 테스트 worktree 경로는 `.worktree/execplan-smoke`, 브랜치는 `test/execplan-smoke`를 우선 사용한다.
- 근거: 초기 확인에서 동일 경로 worktree와 동일 브랜치가 없어 충돌 없는 요청 이름을 그대로 사용할 수 있다.
- 날짜: 2026-05-18

## 7. 예상 밖 발견

- Codex PowerShell 샌드박스 실행이 `CreateProcessAsUserW failed: 5`로 실패해, 읽기와 검증 명령은 승인된 escalated 실행으로 진행했다.
- `.gitignore`에 `.worktree/`를 추가한 뒤 루트 `git status --short`에는 `.worktree/`가 나타나지 않았고, 기대한 문서 변경만 표시되었다.

## 8. 회고

- 완료한 것: 구현 전 ExecPlan을 만들고, `.worktree/` ignore 규칙을 추가하고, 테스트 worktree를 생성하고, 루트와 worktree 상태를 검증하고, 변경 사항을 커밋했다.
- 완료하지 못한 것: 없음.
- 배운 것: 요청된 worktree 경로와 브랜치가 비어 있으면 별도 대체 이름 없이 smoke test를 재현할 수 있다.
- 다음에 해야 할 것: 실제 기능 작업에서 worktree를 사용할 때도 같은 충돌 확인과 ExecPlan 갱신 절차를 따른다.
- 다음 계획을 시작할 준비: 준비됨.
