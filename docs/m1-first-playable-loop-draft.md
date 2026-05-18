# m1

> **M1은 “사람이 단계별 문서를 만드는 과정”이 아니라, Codex가 한 번의 목표 프롬프트를 받고 ExecPlan을 생성한 뒤, 그 ExecPlan을 따라 자동으로 구현·기록·검증까지 진행하는 수직 슬라이스**여야 합니다.

공식 ExecPlan 문서 기준으로도 ExecPlan은 “design to implementation”에 쓰는 문서이고, 구현 중에는 사용자에게 “다음 단계”를 묻지 말고 다음 milestone으로 진행하며, Progress / Decision Log / Discoveries를 계속 갱신해야 한다고 되어 있습니다. ([OpenAI Developers][1]) 또한 ExecPlan은 자기완결적인 living document여야 하고, 현재 working tree와 단일 ExecPlan만으로도 작업을 재개할 수 있어야 합니다. ([OpenAI Developers][1])

그래서 M1의 핵심은 이겁니다.

```text
사용자:
M1 목표, 제약, 완료 기준을 한 번 제공한다.

Codex:
ExecPlan 생성 → 구현 → 진행 기록 갱신 → 검증 방법 기록 → 결과 요약

사용자:
Unity Play Mode에서 최종 검증한다.
```

---

# M1 정의

```text
M1: First Playable Loop
```

M1 완료 문장:

> **Unity Play Mode에서 로봇을 움직여 픽업 지점에 도착하고, 배달 지점에 도착하면 Clear가 뜨며, 제한 턴 안에 배달하지 못하면 Failed가 뜨고, Retry로 다시 시작할 수 있다.**

핵심 루프:

```text
Start → Move → Pickup → Deliver → Result → Retry
```

M1은 “좋은 구조의 게임”이 아니라 **Codex 자동 실행으로 완성된 첫 플레이어블 증거**입니다.

---

# M1에서 사용자가 하는 일

M1에서 당신이 직접 하는 일은 딱 이 정도입니다.

```text
1. M0 상태를 확인한다.
2. Codex에게 M1 자동 실행 프롬프트를 준다.
3. Codex가 끝났다고 하면 Unity Play Mode에서 확인한다.
4. 실패하면 실패 관찰 결과만 다시 전달한다.
5. 성공하면 M1 완료로 기록한다.
```

사용자가 하지 않는 일:

```text
- ExecPlan 직접 작성
- ExecPlan 중간 검토/승인
- game-spec.md 직접 작성
- 세부 구현 단계별 승인
- Unity 코드 직접 작성
- 아키텍처 설계 개입
```

공식 Best Practices도 좋은 프롬프트에는 Goal, Context, Constraints, Done when을 넣으라고 설명합니다. ([OpenAI Developers][2]) M1 프롬프트는 이 네 가지를 강하게 넣고, 이후는 Codex가 실행하게 하는 방식으로 가면 됩니다.

---

# M1 전체 흐름

M1은 사용자 관점에서는 5단계입니다.

```text
M1-0. M0 완료 상태 확인
M1-1. M1 자동 실행 프롬프트 입력
M1-2. Codex 자동 실행 대기
M1-3. Unity Play Mode 최종 검증
M1-4. 실패 시 repair prompt / 성공 시 완료 처리
```

Codex 내부적으로는 아래 수직 슬라이스를 수행해야 합니다.

```text
M1-A. ExecPlan 생성
M1-B. Scene Skeleton 구성
M1-C. Robot Movement 구현
M1-D. Pickup / Delivery / Clear 구현
M1-E. Turn Limit / Failed 구현
M1-F. Retry 구현
M1-G. 검증 기록 / current-state 갱신
```

중요한 건, **M1-A부터 M1-G까지 사용자가 하나씩 시키는 게 아니라 Codex가 ExecPlan 안에서 milestone으로 나누고 실행해야 한다는 점**입니다. 공식 문서도 milestone은 각 단계가 독립적으로 검증 가능하고 전체 목표를 점진적으로 구현해야 한다고 설명합니다. ([OpenAI Developers][1])

---

# M1-0. 시작 전 확인

M0가 끝난 상태는 이 정도면 충분합니다.

```text
codex-harness-dbz-v0/
  Assets/
  Packages/
  ProjectSettings/

  .gitignore
  README.md
  AGENTS.md
  PLANS.md

  docs/
    current-state.md
    decisions.md

  exec-plans/
    000-bootstrap.md
```

현재 저장소에는 `001`-`003` ExecPlan이 이미 있으므로, M1 First Playable Loop ExecPlan은 `exec-plans/004-first-playable-loop.md`를 사용합니다.

확인:

```bash
git status
git remote -v
```

M1 시작 조건:

```text
[x] Unity 프로젝트가 열린다.
[x] README.md가 있다.
[x] AGENTS.md가 있다.
[x] PLANS.md가 있다.
[x] docs/current-state.md가 있다.
[x] docs/decisions.md가 있다.
[x] exec-plans/000-bootstrap.md가 있다.
[x] git status가 clean이다.
```

---

# M1-1. Codex에게 줄 자동 실행 프롬프트

이 프롬프트 하나로 시작하면 됩니다.

```text
README.md, AGENTS.md, PLANS.md, docs/current-state.md, docs/decisions.md, exec-plans/000-bootstrap.md를 읽어라.

M1 First Playable Loop를 진행해라.

Goal:
Unity Play Mode에서 Delivery Bot Zero의 첫 플레이어블 루프가 동작해야 한다.

필수 루프:
Start -> Move -> Pickup -> Deliver -> Result -> Retry

플레이어는 키보드 입력으로 로봇을 한 칸씩 움직인다.
로봇이 Pickup 지점에 도착하면 package를 얻는다.
package를 가진 상태로 Delivery 지점에 도착하면 Clear 상태가 된다.
제한 턴 안에 배달하지 못하면 Failed 상태가 된다.
Clear 또는 Failed 후 Retry가 가능해야 한다.

Context:
- 현재 repo는 Codex Harness v0 실험이다.
- M0에서는 Unity 프로젝트, GitHub repo, README.md, AGENTS.md, PLANS.md, docs/current-state.md, docs/decisions.md, exec-plans/000-bootstrap.md를 만들었다.
- M1의 목적은 게임을 크게 만드는 것이 아니라, Codex가 ExecPlan 기반으로 첫 플레이어블 루프를 자동 설계/구현/기록할 수 있는지 검증하는 것이다.

Required workflow:
1. PLANS.md를 따라 M1 ExecPlan을 생성한다.
2. ExecPlan 파일은 exec-plans/004-first-playable-loop.md에 만든다.
3. ExecPlan을 생성한 뒤 사용자에게 다음 단계를 묻지 말고, 그 ExecPlan에 따라 바로 구현을 진행한다.
4. 구현 중 Progress, Decision Log, Surprises & Discoveries, Outcomes & Retrospective를 계속 갱신한다.
5. 각 milestone은 독립적으로 검증 가능한 수직 슬라이스여야 한다.
6. 구현이 끝나면 docs/current-state.md를 갱신한다.
7. 최종 응답에는 변경 파일 목록, Unity Play Mode 검증 방법, 남은 리스크, 다음 M2 후보를 요약한다.

Constraints:
- M1 범위를 작게 유지한다.
- 한 개 씬, 한 개 레벨만 만든다.
- placeholder visual만 사용한다.
- 외부 패키지를 추가하지 마라.
- Unity MCP를 추가하지 마라.
- custom skill, hook, subagent를 추가하지 마라.
- Clean Architecture, VContainer, UniRx, UniTask, asmdef를 도입하지 마라.
- Save/load, sound, animation, mobile input, level editor, multiple levels는 만들지 마라.
- 과한 폴더 구조를 만들지 마라.
- 필요한 파일만 추가하라.
- docs/game-spec.md 같은 추가 문서는 꼭 필요할 때만 만들고, 만든다면 ExecPlan에 이유를 기록하라.
- 구현이 불가능하거나 Unity Editor 수동 조작이 필요한 부분은, 가능한 코드/씬 구성 대안을 적용하고 정확히 어떤 수동 확인이 필요한지 기록하라.

Expected internal milestones:
- M1-A: Create ExecPlan
- M1-B: Create visible scene skeleton
- M1-C: Implement robot movement
- M1-D: Implement pickup, delivery, clear
- M1-E: Implement turn limit and failed state
- M1-F: Implement retry
- M1-G: Record verification and update current-state

Done when:
- exec-plans/004-first-playable-loop.md가 존재한다.
- Main scene에서 Robot, Pickup, Delivery, Turn UI, Status UI가 보인다.
- Robot이 키보드 입력으로 한 칸씩 움직인다.
- 유효 이동마다 turn count가 증가한다.
- Pickup 지점에 도착하면 package 상태가 바뀐다.
- Pickup 없이 Delivery에 도착해도 Clear되지 않는다.
- Pickup 후 Delivery에 도착하면 Clear된다.
- 제한 턴까지 Clear하지 못하면 Failed된다.
- Clear 또는 Failed 후 Retry가 가능하다.
- ExecPlan의 Progress, Decision Log, Surprises & Discoveries, Outcomes & Retrospective가 최신 상태다.
- docs/current-state.md가 M1 결과를 반영한다.
- Unity에서 사람이 수동 검증할 수 있는 절차가 ExecPlan에 기록되어 있다.
```

이 프롬프트에서 가장 중요한 문장은 이것입니다.

```text
ExecPlan을 생성한 뒤 사용자에게 다음 단계를 묻지 말고, 그 ExecPlan에 따라 바로 구현을 진행한다.
```

이 문장이 없으면 Codex가 “계획만 만들고 멈추는” 쪽으로 갈 수 있습니다.

---

# Codex 내부 수직 슬라이스

아래는 **사용자가 직접 수행하는 단계가 아니라**, Codex가 ExecPlan 안에서 milestone으로 나눠 실행해야 하는 구조입니다.

---

## M1-A. ExecPlan 생성

결과물:

```text
exec-plans/004-first-playable-loop.md
```

이 milestone의 완료 기준:

```text
[ ] M1 목표가 명확하다.
[ ] Start -> Move -> Pickup -> Deliver -> Result -> Retry가 명시되어 있다.
[ ] Scope / Non-goals가 있다.
[ ] Progress가 있다.
[ ] Validation이 있다.
[ ] Decision Log가 있다.
[ ] Surprises & Discoveries가 있다.
[ ] Outcomes & Retrospective가 있다.
```

여기서 멈추면 안 됩니다.
이건 **실행 전 준비물**일 뿐이고, Codex는 바로 M1-B로 넘어가야 합니다.

---

## M1-B. Scene Skeleton

목표:

> Play Mode에서 게임의 최소 구성물이 화면에 보인다.

결과:

```text
Robot placeholder
Pickup placeholder
Delivery placeholder
Turn text
Status text
Retry affordance
```

예상 파일:

```text
Assets/Scenes/Main.unity
Assets/_Project/Scripts/DeliveryBotGameController.cs
```

Unity Editor에서 직접 씬 오브젝트를 만드는 방식이 어려우면, Codex가 런타임에서 placeholder를 생성하는 스크립트 방식으로 시작해도 됩니다. M1의 목적은 “씬을 예쁘게 구성”이 아니라 **Play Mode에서 루프를 검증**하는 것입니다.

완료 기준:

```text
[ ] Play Mode에서 Robot이 보인다.
[ ] Pickup 위치가 보인다.
[ ] Delivery 위치가 보인다.
[ ] Turn UI가 보인다.
[ ] Status UI가 보인다.
```

---

## M1-C. Robot Movement

목표:

> 키보드 입력으로 로봇이 한 칸씩 움직인다.

동작:

```text
Arrow / WASD 입력
→ Robot one-tile movement
→ valid move마다 turn count 증가
```

완료 기준:

```text
[ ] 방향키 또는 WASD로 이동한다.
[ ] 한 번 입력에 한 칸 이동한다.
[ ] 유효 이동마다 turn count가 증가한다.
[ ] 이동 후 UI가 갱신된다.
```

M1에서는 부드러운 이동, 애니메이션, 경로 탐색은 필요 없습니다.

---

## M1-D. Pickup / Delivery / Clear

목표:

> 픽업 후 배달하면 Clear가 된다.

상태:

```text
hasPackage
isFinished
```

동작:

```text
Robot reaches Pickup
→ hasPackage = true
→ Status = Picked Up

Robot reaches Delivery while hasPackage
→ Status = Clear
→ input disabled
```

완료 기준:

```text
[ ] Pickup 지점에 도착하면 package 상태가 바뀐다.
[ ] Pickup 없이 Delivery에 가면 Clear되지 않는다.
[ ] Pickup 후 Delivery에 가면 Clear된다.
[ ] Clear 후 추가 이동이 막힌다.
```

---

## M1-E. Turn Limit / Failed

목표:

> 제한 턴 안에 배달하지 못하면 Failed가 된다.

추천 규칙:

```text
turnCount >= turnLimit && !cleared
→ Failed
```

단, 마지막 턴에 Delivery에 도착하는 경우는 Clear가 우선이어야 합니다.

즉 판정 우선순위는:

```text
1. 이동 처리
2. Pickup / Delivery 판정
3. Clear 여부 확인
4. Clear가 아니고 turnCount >= turnLimit이면 Failed
```

완료 기준:

```text
[ ] 제한 턴이 UI에 표시된다.
[ ] 마지막 턴에 배달 성공하면 Clear된다.
[ ] 마지막 턴까지 배달 실패하면 Failed된다.
[ ] Failed 후 추가 이동이 막힌다.
```

이 판정 우선순위를 프롬프트에 명확히 넣는 게 중요합니다. 안 그러면 마지막 턴 Clear/Failed가 꼬일 수 있습니다.

---

## M1-F. Retry

목표:

> Clear 또는 Failed 후 다시 시작할 수 있다.

최소 구현:

```text
R key retry
```

가능하면:

```text
Retry Button
```

M1에서는 R 키만 있어도 충분합니다. UI 버튼은 Codex가 쉽게 만들 수 있으면 추가하되, 막히면 R 키로 완료 처리해도 됩니다.

완료 기준:

```text
[ ] Clear 후 Retry 가능
[ ] Failed 후 Retry 가능
[ ] Robot 위치 초기화
[ ] turn count 초기화
[ ] hasPackage 초기화
[ ] Status가 Playing으로 복귀
```

---

## M1-G. 기록 / 검증 / 상태 갱신

목표:

> 구현 결과가 repo 문서에 남는다.

Codex가 갱신해야 하는 파일:

```text
exec-plans/004-first-playable-loop.md
docs/current-state.md
```

필수 기록:

```text
- 어떤 파일을 만들었는가
- Play Mode에서 어떻게 검증하는가
- Clear 경로 검증 방법
- Failed 경로 검증 방법
- Retry 검증 방법
- 남은 리스크
- 다음 M2 후보
```

완료 기준:

```text
[ ] ExecPlan Progress가 최신이다.
[ ] Decision Log가 있다.
[ ] Surprises & Discoveries가 있다.
[ ] Outcomes & Retrospective가 작성되어 있다.
[ ] docs/current-state.md가 M1 완료 또는 검증 대기 상태를 반영한다.
```

---

# M1 최종 예상 폴더 구조

이건 **M1 시작 전에 만드는 구조가 아니라**, M1이 끝났을 때 자연스럽게 생길 수 있는 결과입니다.

```text
codex-harness-dbz-v0/
  Assets/
    Scenes/
      Main.unity
    _Project/
      Scripts/
        DeliveryBotGameController.cs

  Packages/
  ProjectSettings/

  .gitignore
  README.md
  AGENTS.md
  PLANS.md

  docs/
    current-state.md
    decisions.md

  exec-plans/
    000-bootstrap.md
    001-execplan-storage-convention.md
    002-git-worktree-execplan-smoke-test.md
    003-state-doc-routing-rules.md
    004-first-playable-loop.md
```

만약 Codex가 스크립트를 두 개로 나눴다면 이것도 허용 가능합니다.

```text
Assets/_Project/Scripts/
  DeliveryBotGameController.cs
  RobotGridMover.cs
```

하지만 M1 기준에서는 스크립트 하나로 끝나도 됩니다.
중요한 건 파일 구조가 아니라 **Play Mode에서 루프가 돈다는 것**입니다.

---

# 사용자가 직접 검증할 체크리스트

Codex가 끝났다고 하면 Unity에서 아래만 확인하세요.

```text
[ ] Unity 프로젝트가 compile error 없이 열린다.
[ ] Main scene을 열 수 있다.
[ ] Play 버튼을 누르면 Robot, Pickup, Delivery, UI가 보인다.
[ ] 방향키 또는 WASD로 Robot이 한 칸씩 움직인다.
[ ] 이동할 때 turn count가 증가한다.
[ ] Pickup 지점에 가면 package 상태가 바뀐다.
[ ] Pickup 없이 Delivery에 가도 Clear되지 않는다.
[ ] Pickup 후 Delivery에 가면 Clear된다.
[ ] 마지막 허용 턴에 Delivery에 도착하면 Clear가 우선된다.
[ ] 제한 턴까지 배달하지 못하면 Failed된다.
[ ] Clear 후 이동이 막힌다.
[ ] Failed 후 이동이 막힌다.
[ ] R 키 또는 Retry 버튼으로 초기화된다.
[ ] Retry 후 Robot 위치, turn count, package state, status가 초기화된다.
[ ] exec-plans/004-first-playable-loop.md가 갱신되어 있다.
[ ] docs/current-state.md가 갱신되어 있다.
```

이 체크리스트를 통과하면 M1 완료입니다.

---

# 실패했을 때 repair prompt

중간에 계획을 다시 짜지 말고, **관찰 결과만 전달**하세요.

예시:

```text
M1 Play Mode 검증 실패.

관찰 결과:
- Unity compile error는 없다.
- Robot, Pickup, Delivery는 보인다.
- WASD 입력 시 Robot이 움직이지 않는다.
- Turn count도 증가하지 않는다.
- Console error는 없다.

exec-plans/004-first-playable-loop.md를 읽고, M1 범위 안에서 문제를 수정해라.

제약:
- 새 기능을 추가하지 마라.
- 외부 패키지를 추가하지 마라.
- Unity MCP, custom skill, hook, subagent를 추가하지 마라.
- Clean Architecture 등 구조 변경을 하지 마라.
- M1의 Start -> Move -> Pickup -> Deliver -> Result -> Retry 루프만 고쳐라.

수정 후:
- 변경 파일을 요약해라.
- ExecPlan의 Progress와 Surprises & Discoveries를 갱신해라.
- Unity Play Mode에서 다시 검증할 절차를 적어라.
```

실패 사례별로는 이렇게 말하면 됩니다.

```text
Robot이 안 움직인다.
Pickup 상태가 안 바뀐다.
Delivery에서 Clear가 안 뜬다.
마지막 턴에 Clear 대신 Failed가 뜬다.
Retry 후 hasPackage가 초기화되지 않는다.
```

이런 식으로 **증상만 정확히 주는 것**이 좋습니다.

---

# M1에서 절대 하지 말아야 할 것

M1에서 아래가 나오면 scope drift입니다.

```text
- 두 번째 레벨
- 장애물
- 레벨 에디터
- ScriptableObject 레벨 데이터
- 저장/불러오기
- 모바일 입력
- DOTween
- UniRx / UniTask
- VContainer
- asmdef
- Clean Architecture 계층
- MCP 설치
- custom skill 작성
- hook 작성
- subagent 작성
- 예쁜 아트 / 애니메이션
```

이 중 하나라도 Codex가 추가하려고 하면 M1에는 과합니다.

---

# M1 완료 기준 한 줄

M1은 이 문장이 참이면 완료입니다.

> **Codex가 ExecPlan을 만들고, 그 ExecPlan에 따라 Unity에서 Start → Move → Pickup → Deliver → Result → Retry 루프를 구현했으며, 그 결과를 ExecPlan과 current-state에 기록했다.**

더 짧게는:

```text
M1 완료 = 플레이 가능한 1레벨 + 자동 생성/갱신된 ExecPlan + 수동 검증 가능 상태
```

이제 M1은 “문서 만드는 단계”가 아니라, **Codex 자동 설계-구현-기록 루프를 검증하는 첫 번째 실제 게임 수직 슬라이스**로 정리하면 됩니다.

[1]: https://developers.openai.com/cookbook/articles/codex_exec_plans/ "Using PLANS.md for multi-hour problem solving"
[2]: https://developers.openai.com/codex/learn/best-practices/ "Best practices – Codex | OpenAI Developers"
