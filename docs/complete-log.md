# 마일 스톤 작업 체크 리스트

## M0-1. 프로젝트 생성

[x] Unity Hub에서 프로젝트 생성
[x] 프로젝트 이름은 codex-harness-dbz-v0
[x] Unity Editor에서 정상으로 열린다

## M0-2. Git 초기화

[x] git init 완료
[x] Unity용 .gitignore 추가
[x] 첫 커밋 생성
[x] git status clean

## M0-3. GitHub repo 연결

[x] GitHub repo 생성 완료 - https://github.com/karais89/codex-harness-dbz-v0
[x] origin remote 연결 완료
[x] main 브랜치 push 완료
[x] GitHub 웹에서 repo 확인 가능

## M0-4. README.md 작성

[x] README.md가 있다
[x] 프로젝트 목적이 설명되어 있다
[x] 현재 단계가 M0로 표시되어 있다
[x] 아직 하지 않을 것이 명시되어 있다

## M0-5. AGENTS.md 작성

[x] AGENTS.md가 있다
[x] Codex read order가 있다
[x] 금지사항이 있다
[x] Done 기준이 있다
[x] ExecPlan 사용 규칙이 한국어로 작성되어 있다

## M0-6. PLANS.md 작성

[x] PLANS.md가 있다
[x] ExecPlan의 목적이 설명되어 있다
[x] 필수 섹션이 있다
[x] 자기완결성 원칙이 있다
[x] ExecPlan 저장 위치와 파일 이름 규칙이 명시되어 있다

## M0-7. 최소 상태 문서와 갱신 규칙 추가

[x] docs/current-state.md가 있다
[x] docs/current-state.md에 Current Stage, Active Plan, Next Step이 있다
[x] docs/decisions.md가 있다
[x] docs/decisions.md에 초기 장기 결정이 기록되어 있다
[x] AGENTS.md에 docs/current-state.md와 docs/decisions.md를 읽는 규칙이 있다
[x] AGENTS.md에 두 파일을 언제 업데이트해야 하는지 규칙이 있다
[x] PLANS.md에 ExecPlan 결정 기록과 docs/decisions.md의 관계가 설명되어 있다

## M0-8. Codex로 exec-plans/000-bootstrap.md 생성 및 기존 ExecPlan 정리 기준 확인

[x] exec-plans/000-bootstrap.md가 존재한다.
[x] PLANS.md의 필수 섹션을 따른다.
[x] M0가 bootstrap 검증 단계임을 설명한다.
[x] M1과 M0의 범위를 분리한다.
[x] 기존 exec-plans 파일들을 삭제하지 않았다.
[x] 기존 exec-plans 파일이 있다면 마지막 보고에 목록화했다.
[x] docs/current-state.md의 Active Plan을 exec-plans/000-bootstrap.md로 맞추는 조건을 포함한다.
[x] M1 시작 조건이 명확하다.
[x] git / Unity / 문서 존재 여부를 검증하는 방법이 구체적이다.

## M0-9. M0 전체가 M1을 시작할 수 있는 상태인지 검증만 하는 단계

[x] Unity Editor 로그에서 프로젝트 로딩 완료를 확인했다.
[x] GitHub origin remote를 확인했다.
[x] M0 필수 문서와 canonical bootstrap ExecPlan 존재를 확인했다.
[x] M0와 M1 범위가 분리되어 있고, 아직 게임플레이 구현이 없음을 확인했다.

## M1-0. M0 완료 상태 확인

[x] Unity 프로젝트가 열린다.
[x] README.md가 있다.
[x] AGENTS.md가 있다.
[x] PLANS.md가 있다.
[x] docs/current-state.md가 있다.
[x] docs/decisions.md가 있다.
[x] exec-plans/000-bootstrap.md가 있다.
[x] git status가 clean이다.

검증 메모:

- Unity 6000.4.1f1 Editor 로그에서 `Loaded scene 'Assets/Scenes/SampleScene.unity'`와 `[Project] Loading completed`를 확인했다.
- batchmode 검증은 같은 프로젝트를 연 Unity 인스턴스가 이미 실행 중이라 중단되었다.
- M1 ExecPlan은 기존 `000`-`003` 번호를 피해서 `exec-plans/004-first-playable-loop.md`를 사용한다.

## M1-0a. M1 시작 전 마일스톤 로드맵 문서 추가

[x] `docs/milestone-roadmap.html`이 있다.
[x] M0-M5 마일스톤 범위가 시각화되어 있다.
[x] 최소 성공, 실질 성공, 완전 성공 기준이 문서에 있다.
[x] 실패 신호가 문서에 있다.
[x] 장기 마일스톤 범위 결정이 `docs/decisions.md`에 기록되어 있다.
[x] 현재 프로젝트 상태가 `docs/current-state.md`에 갱신되어 있다.

검증 메모:

- 정적 HTML 문서로 작성했다.
- 민감 정보는 문서에 포함하지 않았다.

## M1 - 완료 기준

[ ] exec-plans/004-first-playable-loop.md 상태가 완료됨이다.
[ ] 구현 승인 후 상태가 진행 중 → 완료됨으로 갱신됐다.
[ ] M1 gameplay 스크립트가 추가됐다.
[ ] Unity 프로젝트가 컴파일 오류 없이 열린다.
[ ] SampleScene에서 Play Mode를 시작할 수 있다.
[ ] 작은 격자, 로봇, 물건, 목적지, 막힌 칸이 보인다.
[ ] 로봇은 BOT, 물건은 BOX, 목적지는 GOAL 표식으로 구분된다.
[ ] 방향키/WASD로 한 칸 이동이 가능하다.
[ ] 벽/격자 밖 입력은 이동하지 않고 턴도 소모하지 않는다.
[ ] 물건 칸에 도착하면 자동 Pickup 된다.
[ ] 물건 보유 상태로 목적지에 도착하면 Clear 된다.
[ ] 턴 제한 안에 배달하지 못하면 Failed 된다.
[ ] Clear/Failed 후 입력이 잠긴다.
[ ] Retry로 같은 레벨이 초기화된다.
[ ] UI에 남은 턴, 물건 보유 여부, 결과 상태, Retry가 표시된다.
[ ] Console에 새 오류가 없다.
[ ] 검증 결과가 exec-plans/004-first-playable-loop.md에 기록됐다.
[ ] docs/current-state.md가 M1 완료 상태로 갱신됐다.
[ ] 필요한 경우 docs/decisions.md에 장기 결정이 기록됐다.
[ ] 구현 완료 커밋이 있다.
[ ] git status --short 결과가 비어 있다.
