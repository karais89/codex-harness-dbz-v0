# 현재 상태

## 프로젝트

Codex Harness v0 — Delivery Bot Zero

## 현재 단계

M0 완료. M1 First Playable Loop 시작 전 워크플로우 재논의 대기.

## 활성 계획

없음. M1을 시작하면 `exec-plans/004-first-playable-loop.md`를 생성한다.

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

## 다음 단계

M1을 다시 시작하기 전에 ExecPlan 생성 전 사용자 인터뷰, 범위 합의, 승인 흐름을 어떻게 둘지 논의한다.

논의가 끝나면 합의된 워크플로우 규칙을 문서에 반영한 뒤 M1 범위 정의와 ExecPlan 생성을 다시 진행한다.

## 아직 하지 않음

- 게임플레이 구현
- 게임 명세
- M1 범위 합의
- Unity MCP
- 사용자 정의 skill
- hook
- subagent
- 서드파티 패키지
