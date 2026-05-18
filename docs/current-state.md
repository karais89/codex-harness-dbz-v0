# 현재 상태

## 프로젝트

Codex Harness v0 — Delivery Bot Zero

## 현재 단계

M0 완료. M1 First Playable Loop 진행 중.

M1 게임 브리프는 `docs/game-brief.md`에 있고, 활성 ExecPlan은 `exec-plans/004-first-playable-loop.md`다.

첫 번째 수직 슬라이스로 5x5 보드, Start/Pickup/Delivery 표시, Start 위치의 로봇, WASD/방향키 한 칸 이동, 그리드 경계 차단을 구현했다.

## 활성 계획

`exec-plans/004-first-playable-loop.md`

현재 완료한 슬라이스:

- 보드와 이동 슬라이스

남은 M1 슬라이스:

- Pickup 위치에서 package 보유 상태로 전환
- package 보유 상태 표시
- Delivery 위치에서 Result 상태 진입
- Result 상태에서 Retry로 시작 상태 복귀

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
- M1 게임 브리프를 `docs/game-brief.md`에 작성했다.
- M1 First Playable Loop ExecPlan을 `exec-plans/004-first-playable-loop.md`에 생성했다.
- `Assets/Scripts/DeliveryBotZero/FirstPlayableLoop.cs`를 추가해 Play Mode 진입 시 첫 번째 슬라이스 보드와 로봇 이동을 생성하도록 했다.
- Unity 참조 어셈블리와 Input System 어셈블리를 사용한 로컬 Roslyn 컴파일에서 `FirstPlayableLoop.cs`가 오류와 경고 없이 컴파일되는 것을 확인했다.

## 다음 단계

Unity Editor에서 `Assets/Scenes/SampleScene.unity`를 열고 Play Mode로 첫 번째 슬라이스를 수동 검증한다.

수동 검증 절차:

1. Play Mode를 시작한다.
2. 5x5 보드와 Start/Pickup/Delivery 라벨이 보이는지 확인한다.
3. 로봇이 Start 위치에서 시작하는지 확인한다.
4. WASD와 방향키 입력 한 번에 로봇이 한 칸씩 이동하는지 확인한다.
5. 보드 가장자리에서 바깥 방향 입력을 눌러 로봇이 그리드 밖으로 나가지 않는지 확인한다.
6. Console에 컴파일 오류나 런타임 오류가 없는지 확인한다.

그 다음 Pickup package 획득 슬라이스를 구현한다.

## 아직 하지 않음

- 실제 Unity Editor Play Mode 수동 조작 검증
- Pickup package 획득
- Delivery Result
- Retry
- Unity MCP
- 사용자 정의 skill
- hook
- subagent
- 서드파티 패키지

## 알려진 제한 사항과 리스크

- Unity batchmode 검증은 같은 프로젝트가 이미 다른 Unity Editor 인스턴스에서 열려 있어 실행하지 못했다.
- Codex는 실제 Play Mode 입력 조작을 수행하지 못했으므로, 첫 번째 슬라이스의 최종 동작 확인은 Unity Editor 수동 검증이 필요하다.
- 현재 구현은 M1 전체 루프가 아니라 첫 번째 슬라이스다. package 획득, Delivery 완료, Result, Retry는 아직 동작하지 않는다.
