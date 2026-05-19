# Play Mode 검증 체크리스트

## 목적

이 문서는 Delivery Bot Zero의 현재 M1/M2 플레이어블 루프를 반복 검증하기 위한 수동 Play Mode 체크리스트다.

이 체크리스트는 새 gameplay 요구사항이 아니다. 이미 승인되고 검증된 `Start -> Move -> Pickup -> Deliver -> Result -> Retry` 루프를 같은 절차로 다시 확인하기 위한 기록 기준이다.

## 진입 조건

- `exec-plans/004-first-playable-loop.md` 상태가 `완료됨`이다.
- `exec-plans/008-m2-readability-regression-check.md` 상태가 `완료됨`이다.
- `Assets/Scenes/SampleScene.unity`가 존재한다.
- Unity Editor에서 Console을 비운 뒤 시작한다.
- 가능하면 `dotnet build codex-harness-dbz-v0.sln` 또는 Unity 컴파일 상태가 통과한 뒤 시작한다.

## 초기 화면

- [ ] `Assets/Scenes/SampleScene.unity`를 열고 Play Mode를 시작한다.
- [ ] 5 x 5 보드가 보인다.
- [ ] 파란색 `BOT`, 노란색 `BOX`, 초록색 `GOAL`, 막힌 칸 3개가 보인다.
- [ ] 목표 문구 `Goal: Pick up BOX, then deliver it to GOAL.`가 보인다.
- [ ] `Turns Left: 14`가 보인다.
- [ ] `Cargo: No BOX`가 보인다.
- [ ] `Status: Pick up BOX.`가 보인다.
- [ ] `Retry Level` 버튼이 보인다.
- [ ] UI 텍스트가 보드나 다른 UI와 겹치지 않는다.

## 벽과 격자 밖 입력

시작 위치에서 다음 입력을 확인한다.

- [ ] `D` 또는 오른쪽 방향키를 누르면 막힌 칸 때문에 이동하지 않는다.
- [ ] 위 입력 후 `Turns Left`가 14로 유지된다.
- [ ] `A` 또는 왼쪽 방향키를 누르면 격자 밖이므로 이동하지 않는다.
- [ ] 위 입력 후 `Turns Left`가 14로 유지된다.
- [ ] `S` 또는 아래쪽 방향키를 누르면 격자 밖이므로 이동하지 않는다.
- [ ] 위 입력 후 `Turns Left`가 14로 유지된다.

## Clear 경로

다음 순서로 이동한다.

```text
W W D D S S D D W W W W
```

- [ ] 여덟 번째 이동 후 `BOT`이 `BOX` 위치에 도착한다.
- [ ] `BOX`가 보드에서 사라진다.
- [ ] `Cargo: BOX loaded`가 보인다.
- [ ] `Status: Deliver to GOAL.`가 보인다.
- [ ] 열두 번째 이동 후 `BOT`이 `GOAL` 위치에 도착한다.
- [ ] `Turns Left: 2`가 보인다.
- [ ] `Status: Delivered.`가 보인다.
- [ ] Clear 이후 이동 입력이 무시된다.

## Retry 확인

- [ ] `Retry Level` 버튼을 누른다.
- [ ] `BOT`이 시작 위치로 돌아간다.
- [ ] `BOX`가 다시 보인다.
- [ ] `Turns Left: 14`가 보인다.
- [ ] `Cargo: No BOX`가 보인다.
- [ ] `Status: Pick up BOX.`가 보인다.

## Failed 경로

Retry 이후 다음 순서로 이동한다.

```text
W S W S W S W S W S W S W S
```

- [ ] 열네 번의 유효 이동 후 `Turns Left: 0`이 보인다.
- [ ] `Status: Out of turns.`가 보인다.
- [ ] Failed 이후 이동 입력이 무시된다.
- [ ] UI 텍스트가 보드나 다른 UI와 겹치지 않는다.

## Console 확인

- [ ] Play Mode 동안 새 Error가 없다.
- [ ] Play Mode 동안 새 Warning이 없다.

## 기록 위치

검증 결과는 작업 중인 ExecPlan의 `검증` 섹션에 기록한다.

마일스톤 완료 상태가 바뀌면 다음 문서도 함께 갱신한다.

- `docs/current-state.md`
- `docs/complete-log.md`
