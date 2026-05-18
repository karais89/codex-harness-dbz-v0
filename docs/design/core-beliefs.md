# Core Beliefs

상태: 초안

## 목적

이 문서는 Delivery Bot Zero의 첫 번째 실제 design 산출물이다.

이 문서는 프로젝트가 유지해야 할 큰 방향을 기록한다. 아직 `상태: 초안`이므로 player-facing gameplay ExecPlan이나 구현의 승인 기준으로 사용할 수 없다.

사용자가 명시적으로 승인하기 전까지 Codex는 이 문서의 상태를 `상태: 승인됨`으로 바꾸지 않는다.

## 핵심 원칙

- Delivery Bot Zero는 작은 Unity 2D 퍼즐 게임을 통해 Codex 기반 개발 워크플로우가 실제로 작동하는지 검증한다.
- 초기 작업은 작고 Play Mode에서 관찰 가능해야 한다.
- 플레이어가 보는 규칙, 목표, 피드백, 상태 변화는 승인된 design 문서에서 먼저 결정한다.
- Codex는 승인되지 않은 player-facing gameplay 규칙을 추론해서 ExecPlan이나 구현에 섞지 않는다.
- 각 마일스톤은 검증 가능한 수직 단위로 유지하고, 구현 범위가 design 승인 범위를 넘지 않게 한다.

## 초기 마일스톤에서 하지 않을 것

- 이 문서만으로 M1 First Playable Loop의 구체적인 gameplay 규칙을 결정하지 않는다.
- 이동, pickup, deliver, result, retry의 구체 규칙을 이 문서에서 정하지 않는다.
- 좌표, 수치, 씬 구조, C# 스크립트 이름을 이 문서에서 정하지 않는다.
- 사용자 승인 없이 조건부 design 문서나 gameplay ExecPlan을 생성하지 않는다.
- 승인되지 않은 player-facing gameplay 아이디어를 구현 편의상 추가하지 않는다.

## 승인 체크리스트

- [ ] 사용자가 이 문서의 상태를 `승인됨`으로 바꾸라고 명시했다.
- [ ] M1 시작 전에 이 baseline이 프로젝트 방향 기준으로 충분한지 확인했다.
- [ ] M1에 필요한 조건부 design 문서가 있는지 별도로 판단했다.
