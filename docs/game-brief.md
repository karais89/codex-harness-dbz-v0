# M1 게임 브리프

## 목적

Delivery Bot Zero의 M1 First Playable Loop 범위를 정의한다.

이 문서는 구현 계획이 아니다. 이후 `exec-plans/004-first-playable-loop.md`를 작성할 때 참조할 게임 명세다.

## 핵심 경험

플레이어는 5x5 탑다운 그리드에서 로봇을 한 칸씩 이동시킨다.

로봇은 Start에서 시작해 Pickup으로 이동하여 package를 얻고, Delivery로 이동해 package를 배달한다. 배달 결과를 확인한 뒤 Retry로 같은 루프를 다시 시작할 수 있다.

M1의 목표 루프는 다음과 같다.

`Start -> Move -> Pickup -> Deliver -> Result -> Retry`

## 기본 규칙

- 보드는 5x5 탑다운 그리드다.
- 로봇은 Start 타일에서 시작한다.
- Pickup 타일에 도착하면 로봇이 package를 얻는다.
- package를 가진 상태로 Delivery 타일에 도착하면 배달이 완료된다.
- 조작은 WASD와 방향키를 지원한다.
- 입력 한 번은 상하좌우 한 칸 이동으로 처리한다.
- 로봇은 그리드 밖으로 이동할 수 없다.
- package를 얻기 전 상태와 얻은 후 상태는 구분되어야 한다.
- 배달 완료 후 Result 상태로 진입한다.
- Result 상태에서 Retry를 선택하면 시작 상태로 돌아간다.

## M1 화면 피드백

- Start, Pickup, Delivery 위치를 플레이어가 구분할 수 있어야 한다.
- 로봇의 현재 위치를 플레이어가 확인할 수 있어야 한다.
- package 획득 여부를 플레이어가 확인할 수 있어야 한다.
- 배달 완료 Result를 플레이어가 확인할 수 있어야 한다.
- Retry 동작이 가능한 상태임을 플레이어가 확인할 수 있어야 한다.

## M1 범위 밖

- 여러 package
- 여러 Delivery 지점
- 장애물, 스위치, 문, 적, 턴 제한 같은 추가 퍼즐 규칙
- 점수, 타이머, 등급, 레벨 선택
- 저장, 설정, 진행도 관리
- 애니메이션, 사운드, 커스텀 아트
- Unity MCP, 사용자 정의 skill, hook, subagent, 외부 패키지

## 구현 전제

- 이 브리프는 구현을 포함하지 않는다.
- M1 구현은 별도 ExecPlan에서 다룬다.
- ExecPlan은 이 브리프의 루프와 범위를 넘기지 않는다.

## 검증 기준

문서 작업 자체의 검증 기준은 다음과 같다.

- `docs/game-brief.md`가 존재한다.
- M1 목표 루프가 `Start -> Move -> Pickup -> Deliver -> Result -> Retry`로 기록되어 있다.
- 5x5 탑다운 그리드, Pickup package 획득, Delivery 배달, Retry가 명시되어 있다.
- 구현 파일이나 Unity 씬 변경이 포함되지 않는다.

이후 M1 구현 검증 기준은 다음과 같다.

- Play Mode에서 로봇이 Start 위치에서 시작한다.
- WASD와 방향키 입력 한 번에 한 칸씩 이동한다.
- 로봇이 그리드 밖으로 이동하지 않는다.
- Pickup 위치에서 package 획득 상태가 된다.
- package를 가진 상태로 Delivery 위치에 도착하면 Result 상태가 된다.
- Retry 후 다시 Start 상태에서 루프를 시작할 수 있다.
