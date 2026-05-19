# Codex Harness v0 — Delivery Bot Zero

Delivery Bot Zero는 작은 Unity 2D 퍼즐 게임을 이용해 Codex 기반 Unity 개발 워크플로우를 검증한 실험 저장소입니다.

이 저장소의 중심 산출물은 큰 게임이 아니라, Codex가 문서 읽기, 사용자 인터뷰, ExecPlan 작성, 구현 승인, Unity 구현, 수동/자동 검증, 다음 세션 인수인계를 따라갈 수 있는지 확인한 기록입니다.

## 현재 상태

M5 공개 포트폴리오와 회고 패키지까지 완료한 상태입니다.

현재 Play Mode에서는 5 x 5 격자에서 `BOT`이 `BOX`를 주워 `GOAL`까지 배달하는 최소 루프를 플레이할 수 있습니다. 막힌 칸과 턴 제한이 있으며, 성공/실패 상태와 Retry 버튼을 확인할 수 있습니다.

## 실행 방법

1. Unity 6000.4.1f1에서 저장소 루트 폴더를 엽니다.
2. `Assets/Scenes/SampleScene.unity`를 엽니다.
3. Unity Editor에서 Play Mode를 시작합니다.
4. 화면에 `BOT`, `BOX`, `GOAL`, 막힌 칸, 목표 문구, `Turns Left`, `Cargo`, `Status`, `Retry Level` 버튼이 보이는지 확인합니다.

## 조작 방법

- 이동: `WASD` 또는 방향키
- 목표: `BOX`를 주운 뒤 `GOAL`로 이동
- 재시작: `Retry Level` 버튼
- 턴 제한: 시작 시 14턴

기준 Clear 경로는 다음과 같습니다.

```text
W W D D S S D D W W W W
```

반복 검증 절차는 `docs/verification/play-mode-checklist.md`에 있습니다.

## 마일스톤 결과

| 마일스톤 | 결과 |
| --- | --- |
| M0 Bootstrap | Unity 프로젝트, Git 저장소, 최소 Codex 하네스 문서를 준비하고 검증했습니다. |
| M1 First Playable Loop | `SampleScene`에서 최소 배송 루프를 runtime으로 구성하고 Play Mode 수동 검증을 완료했습니다. |
| M2 Readability and Regression Check | UI 문구와 표식을 읽기 쉽게 조정하고 M1 동작 회귀를 확인했습니다. |
| M3 Verification Loop | Play Mode 체크리스트와 `DeliveryLoopState` Edit Mode 테스트를 추가했습니다. |
| M4 Handoff Test | 새 Codex 세션이 저장소 문서만 읽고 현재 상태를 이어받을 수 있음을 확인했습니다. |
| M5 Portfolio & Retrospective Package | 공개용 README, 하네스 회고, public repo 점검 문서를 정리했습니다. |

M3까지 완료하면 실질 성공, M5까지 완료하면 완전 성공으로 보는 실험 기준을 사용했습니다.

## 문서 구조

- `AGENTS.md`: Codex가 이 저장소에서 따라야 하는 작업 규칙입니다.
- `PLANS.md`: ExecPlan 작성, 승인, 검증, 완료 기준입니다.
- `docs/current-state.md`: 현재 프로젝트 상태와 활성 계획입니다.
- `docs/decisions.md`: 오래 유지할 프로젝트 결정입니다.
- `docs/design/`: 승인된 player-facing design 기준과 작성 규약입니다.
- `docs/verification/play-mode-checklist.md`: 현재 Play Mode 루프의 수동 검증 절차입니다.
- `docs/harness-reuse-guide.md`: 이 하네스를 다른 프로젝트에 옮길 때의 기준입니다.
- `docs/harness-retrospective.md`: 이번 하네스 실험의 회고입니다.
- `docs/public-repo-checklist.md`: 공개 저장소 기준 점검 결과입니다.
- `exec-plans/`: 각 사소하지 않은 작업의 자기완결적 실행 계획과 결과입니다.

## 이번 실험에서 확인한 것

- 사소하지 않은 작업은 인터뷰와 공유된 이해 검증 뒤 ExecPlan으로 시작하는 편이 범위 이탈을 줄였습니다.
- `docs/current-state.md`와 `docs/decisions.md`가 있으면 새 Codex 세션이 이전 채팅 없이도 맥락을 이어받기 쉬웠습니다.
- Gameplay 작업은 승인된 design 기준과 ExecPlan 게이트가 있을 때 Codex가 임의로 규칙을 발명할 위험이 줄었습니다.
- Unity batchmode가 열린 Editor 인스턴스와 충돌할 수 있어, 작은 프로젝트라도 사람의 Editor 기반 확인과 기록이 필요했습니다.

자세한 회고는 `docs/harness-retrospective.md`에 정리했습니다.

## 아직 포함하지 않는 것

- 새 gameplay 기능
- 새 레벨
- 완성 게임용 콘텐츠 확장
- Unity MCP
- custom skills
- hooks
- subagents
- external packages 추가
- 실제 `template/` 폴더
- 플레이 영상 또는 GIF
