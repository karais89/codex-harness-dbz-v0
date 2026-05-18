# M1 First Playable Loop Draft Notes

This is not an ExecPlan.

These notes capture candidate scope, behavior, and prompts for M1. Actual M1 implementation must start from a new ExecPlan under `exec-plans/` that follows `PLANS.md`.

Because existing ExecPlans already use `000` through `003`, the likely M1 ExecPlan path is:

```text
exec-plans/004-first-playable-loop.md
```

## Goal

M1: First Playable Loop

Completion statement:

> Unity Play Mode에서 로봇을 움직여 픽업 지점에 도착하고, 배달 지점에 도착하면 Clear가 뜨며, 턴 제한을 넘기면 Failed가 뜨고, Retry가 가능하다.

Core loop:

```text
Start -> Move -> Pickup -> Deliver -> Result -> Retry
```

M1 should stay small. It should prove a thin playable Unity loop, not produce a polished game or broad architecture.

## Proposed M1 Slices

```text
M1-1. M1 ExecPlan 생성
M1-2. 최소 게임 규칙 문서 작성
M1-3. Unity 씬에 placeholder 보드 구성
M1-4. Robot 이동 구현
M1-5. Pickup / Deliver 판정 구현
M1-6. Turn Limit / Failed 판정 구현
M1-7. Clear / Failed / Retry UI 구현
M1-8. Play Mode 수동 검증
M1-9. M1 결과 기록 및 커밋
```

M1-3부터 Unity 화면에 보이는 결과가 생겨야 한다. 문서만 많이 만들지 않는다.

## Candidate Scope

Included:

- One scene
- One level
- Placeholder visuals
- Keyboard input
- Grid movement
- Pickup tile
- Delivery tile
- Turn count
- Turn limit
- Clear result
- Failed result
- Retry by key or button

Not included:

- Art polish
- Sound
- Animation
- Level editor
- Save/load
- Multiple levels
- Mobile input
- Architecture refactor
- External packages
- Unity MCP
- custom skills
- hooks
- subagents

## Candidate Game Rules

The level contains:

- Robot start position
- Pickup position
- Delivery position
- Turn limit

The player moves the robot one grid cell per valid input.

When the robot reaches the pickup position, the package is picked up.

When the robot reaches the delivery position while carrying the package, the level is cleared.

Each valid move consumes one turn.

If the robot has not cleared the level after using the final allowed turn, the level fails.

After Clear or Failed, the player can retry.

## Candidate Unity Structure

Scene objects:

```text
GridRoot
Robot
StartTile
PickupTile
DeliveryTile
UIRoot
  TurnText
  StatusText
  RetryButton
```

Potential files:

```text
Assets/
  Scenes/
    Main.unity
  _Project/
    Scripts/
      DeliveryBotGameController.cs
      RobotGridMover.cs
```

If one script is enough for M1, `DeliveryBotGameController.cs` alone is acceptable. The important outcome is the playable loop.

## Candidate Validation

M1 is complete when this can be manually verified in Unity Play Mode:

1. Press Play.
2. Robot appears at the start position.
3. Robot moves with keyboard input.
4. Turn count increases after valid moves.
5. Robot reaches pickup tile and package state changes.
6. Robot reaches delivery tile after pickup and Clear appears.
7. If the player uses the final allowed turn before delivery, Failed appears.
8. Retry resets the level.

## Candidate M1 Start Prompt

```text
Goal:
Implement M1: First Playable Loop for Delivery Bot Zero.

Context:
Read these files first:
- README.md
- AGENTS.md
- PLANS.md
- docs/current-state.md
- docs/decisions.md
- docs/game-spec.md
- exec-plans/004-first-playable-loop.md

Constraints:
- Keep M1 small.
- Use placeholder visuals only.
- Do not add third-party packages.
- Do not add Unity MCP, custom skills, hooks, or subagents.
- Do not introduce Clean Architecture yet.
- Do not create multiple levels.
- Do not add save/load, sound, animation, mobile input, or level editor.
- Prefer the smallest implementation that works in Unity Play Mode.
- Update the ExecPlan Progress section as work proceeds.

Required behavior:
- Robot starts on a grid.
- Player can move the robot one tile per valid keyboard input.
- Each valid move increases turn count.
- Robot picks up package when reaching the pickup tile.
- Robot clears the level when reaching the delivery tile while carrying the package.
- Level fails when the turn limit is reached before delivery.
- Player can retry after Clear or Failed.

Done when:
- Unity opens without compile errors.
- Main scene can be played.
- Clear path can be manually verified.
- Failed path can be manually verified.
- Retry can be manually verified.
- Verification results are written in exec-plans/004-first-playable-loop.md.
- docs/current-state.md is updated.
```

## Candidate M1 Review Prompt

```text
Review M1 implementation against exec-plans/004-first-playable-loop.md.

Do not add new features.

Check:
1. Is the M1 scope respected?
2. Does the project implement Start -> Move -> Pickup -> Deliver -> Result -> Retry?
3. Are there any unnecessary abstractions?
4. Are there any missing verification steps?
5. Can the clear path be manually tested?
6. Can the failed path be manually tested?
7. Does retry reset all required state?
8. Are docs/current-state.md and the ExecPlan updated?
9. Is there any scope drift toward M2?

Return:
- Pass / Needs Work
- Missing behavior
- Risky implementation choices
- Exact fixes required before M1 can be considered done
```

## Success Criteria

```text
[ ] Unity Play Mode에서 Robot이 보인다.
[ ] 키보드로 Robot을 움직일 수 있다.
[ ] Pickup 지점에 가면 package 상태가 바뀐다.
[ ] Delivery 지점에 가면 Clear가 뜬다.
[ ] 제한 턴을 넘기면 Failed가 뜬다.
[ ] Retry가 된다.
[ ] ExecPlan에 검증 결과가 적혀 있다.
[ ] current-state.md가 갱신되어 있다.
[ ] GitHub에 push되어 있다.
```

M1은 구조 좋은 코드가 아니라 Codex로 만든 첫 번째 플레이 가능한 증거를 만드는 단계다.
