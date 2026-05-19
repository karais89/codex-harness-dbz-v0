# 하네스 회고

## 목적

이 문서는 `Codex Harness v0 — Delivery Bot Zero` 실험을 마무리하며, Codex 기반 Unity 개발 워크플로우에서 작동한 규칙과 다음 프로젝트에서 조정할 규칙을 정리한다.

이 회고는 gameplay 설계 문서가 아니다. 새 기능, 새 레벨, 새 규칙을 제안하지 않고, M0-M5 동안 검증한 하네스와 협업 절차만 다룬다.

## 실험 판정

판정: 완전 성공.

M0-M3에서 실질 성공 기준에 도달했고, M4에서 새 Codex 세션이 저장소 문서만 읽고 현재 상태를 이어받을 수 있음을 확인했다. M5에서는 외부 독자가 실험 목적, 실행 방법, M1-M4 결과, 하네스 회고, 공개 저장소 점검 결과를 읽을 수 있게 문서 패키지를 정리했다.

Delivery Bot Zero 자체는 작은 Play Mode 루프다. 이 실험의 핵심 결과는 작은 Unity 작업에서도 Codex가 문서 기반 상태 관리, 승인된 design 기준, ExecPlan, 검증 기록을 따라가며 작업할 수 있다는 점이다.

## M1-M4 요약

### M1 First Playable Loop

`Assets/Scenes/SampleScene.unity`에서 runtime으로 5 x 5 격자, `BOT`, `BOX`, `GOAL`, 막힌 칸, 턴 제한, Retry 버튼을 구성했다. Play Mode에서 물건을 주워 목적지에 배달하는 최소 루프를 확인했다.

### M2 Readability and Regression Check

목표 문구, `Turns Left`, `Cargo`, `Status`, `Retry Level` 라벨을 추가하거나 조정해 플레이 상태를 더 읽기 쉽게 만들었다. M1 동작이 유지되는지 수동으로 회귀 검증했다.

### M3 Verification Loop

`docs/verification/play-mode-checklist.md`를 추가해 수동 검증 절차를 반복 가능한 문서로 고정했다. 기존 gameplay 규칙은 `DeliveryLoopState`로 분리했고, Edit Mode 테스트 6개로 순수 로직을 확인했다.

### M4 Handoff Test

새 Codex 세션이 `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, design 문서, 검증 체크리스트, 완료된 ExecPlan만 읽고 현재 상태를 요약할 수 있음을 확인했다. 판정은 Pass였다.

## 잘 작동한 것

- `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`를 먼저 읽는 규칙은 세션 간 맥락 손실을 줄였다.
- 사소하지 않은 작업에서 인터뷰, 공유된 이해 검증, ExecPlan 생성 승인, 구현 승인을 분리한 흐름은 범위 확장을 막는 데 효과적이었다.
- `docs/design/core-beliefs.md`와 조건부 design 문서의 승인 상태를 확인하는 규칙은 gameplay 작업에서 Codex가 새 규칙을 임의로 만들지 않게 하는 장치가 됐다.
- ExecPlan을 살아 있는 문서로 유지하니 검증 실패, 사용자 수동 확인, 남은 제한을 한 곳에 기록할 수 있었다.
- `docs/verification/play-mode-checklist.md`와 Edit Mode 테스트를 함께 두니 사람의 Play Mode 확인과 반복 가능한 로직 검증이 역할을 나눌 수 있었다.
- M4 Handoff Test는 하네스가 실제로 다음 세션에 전달 가능한지 확인하는 좋은 마감 검증이었다.

## 마찰이 있었던 것

- Unity batchmode 검증은 열린 Unity Editor 인스턴스와 충돌할 수 있었다. 이 프로젝트에서는 일부 Unity 검증을 사용자의 열린 Editor 확인으로 대체하고 기록했다.
- 작은 문서 변경과 사소하지 않은 워크플로우 변경의 경계가 매번 명확하지 않았다.
- ExecPlan 절차는 안정적이지만, 아주 작은 문서 보강까지 같은 무게로 다루면 진행이 느려질 수 있다.
- design baseline 규칙은 유용했지만, gameplay가 아닌 하네스 작업과 player-facing gameplay 작업의 경계를 문서에 명확히 적어야 했다.
- README가 M5 전까지는 내부 상태 메모에 가까웠고, 외부 독자가 읽을 포트폴리오 진입점으로는 부족했다.

## Codex가 실수하기 쉬운 지점

- 사용자의 일반적인 동의 표현을 ExecPlan 생성 승인이나 구현 승인으로 과하게 해석할 수 있다.
- 승인되지 않은 design 문서를 근거로 gameplay 작업을 시작하려 할 수 있다.
- 하네스 작업을 하다가 player-facing gameplay 규칙을 슬쩍 정의하는 방향으로 범위를 넓힐 수 있다.
- 문서 정리 중 오래 유지할 결정과 일시적인 회고를 같은 장소에 기록할 수 있다.
- Unity 검증 실패가 환경 문제인지 실제 코드 문제인지 분리하지 않고 결론을 서두를 수 있다.

## 사람이 맡아야 했던 Unity 검증

- 열린 Unity Editor에서 Play Mode를 실행하고 UI 겹침, 표식 가독성, Console Warning/Error 여부를 확인했다.
- M1/M2 수동 검증에서 실제 화면이 의도대로 보이는지 확인했다.
- M3에서 Unity Test Runner의 Edit Mode 테스트 6개가 모두 통과했는지 확인했다.
- batchmode가 열린 Editor 인스턴스 때문에 중단된 경우, 사람이 Editor 상태와 로그를 기준으로 검증 결과를 보완했다.

## 다음 프로젝트에 가져갈 규칙

- 작업 전 `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`를 읽는다.
- 사소하지 않은 작업은 인터뷰와 공유된 이해 검증을 거친 뒤 ExecPlan을 만든다.
- ExecPlan 생성 승인과 구현 승인을 분리한다.
- 새 ExecPlan은 기본적으로 `구현 승인 대기`에서 시작한다.
- gameplay 작업은 승인된 `docs/design/core-beliefs.md`와 관련 design 문서 없이는 시작하지 않는다.
- 현재 상태와 장기 결정을 `docs/current-state.md`, `docs/decisions.md`로 분리한다.
- 반복 가능한 수동 검증은 `docs/verification/`에 둔다.
- 검증 실패나 환경 제한은 ExecPlan의 검증 결과와 예상 밖 발견에 남긴다.
- M4 같은 handoff test를 마일스톤 후반에 넣어 문서만으로 이어받을 수 있는지 확인한다.

## 다음 프로젝트에서 버리거나 완화할 규칙

- 작은 오타, 작은 서식 수정, 명확한 한 줄 보정에는 ExecPlan을 요구하지 않는다.
- 검토 보조 문서는 사용자가 요청하거나 계획이 복잡할 때만 만든다.
- 모든 회고 내용을 `docs/decisions.md`에 올리지 않는다. 오래 유지할 규칙만 결정 문서에 남긴다.
- 실제로 두 번째 프로젝트에 옮겨 보기 전에는 `template/` 폴더를 만들지 않는다.
- Play Mode 영상이나 GIF는 기본 완료 조건이 아니라 별도 공개 작업으로 둔다.

## 아직 보류할 도구

- Unity MCP: 현재 실험에서는 최소 하네스와 사람의 Editor 확인만으로 충분했다. 반복적인 Editor 자동화 마찰이 확인되면 다시 검토한다.
- custom skill: 규칙이 아직 빠르게 변하고 있어, 먼저 문서 규칙으로 안정화한다.
- hooks: 자동 강제보다 사람이 읽을 수 있는 상태 문서와 ExecPlan 기록을 우선한다.
- subagent: 작은 Unity 실험에서는 병렬 작업보다 단일 흐름의 상태 보존이 더 중요했다.
- 외부 패키지: M5는 공개 문서 패키징 단계이므로 새 패키지를 추가하지 않는다.

## 다음에 시도할 만한 것

- 이 하네스를 두 번째 작은 Unity 프로젝트에 옮겨 보고 `docs/harness-reuse-guide.md`가 충분한지 확인한다.
- Unity 검증에서 batchmode와 열린 Editor 검증을 어떻게 나눌지 더 명확한 운영 규칙을 만든다.
- 반복되는 public repo 점검 항목이 안정되면 체크리스트 템플릿으로 승격할지 검토한다.
