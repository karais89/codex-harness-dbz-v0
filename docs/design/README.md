# Design 문서 작성 규약

## 역할

`docs/design`은 승인된 플레이어 경험, 게임 방향, 게임 규칙 기준을 보관하는 폴더다.

이 폴더는 마일스톤 문서 폴더가 아니다. 마일스톤은 언제 무엇을 구현할지 다루고, design 문서는 플레이어가 무엇을 경험해야 하는지와 어떤 게임 규칙을 지켜야 하는지를 다룬다.

`docs/design/README.md`는 player-facing gameplay design 문서가 아니라 design 문서 작성 규약이다. 따라서 `docs/design/README.md`는 승인 상태 확인 대상이 아니라 존재 확인 대상이다.

`docs/design/*.md` 파일은 실제 design 산출물이다. `PLANS.md`가 ExecPlan 작성 규약이고 `exec-plans/*.md`가 실제 실행 계획인 것처럼, `docs/design/README.md`는 design 문서 작성 규약이고 `docs/design/*.md`는 실제 design 산출물이다.

## 문서 상태

실제 design 산출물은 문서 상단에 다음 상태 중 하나를 적는다.

- `상태: 초안`: 아직 사용자 승인 전이다. gameplay ExecPlan이나 구현의 승인 기준으로 사용할 수 없다.
- `상태: 승인됨`: 사용자가 명시적으로 승인했다. 관련 gameplay ExecPlan의 design 기준으로 사용할 수 있다.
- `상태: 수정 필요`: 기존 승인이 더 이상 충분하지 않다. 다시 승인되기 전까지 gameplay ExecPlan이나 구현 기준으로 사용할 수 없다.

새 design 문서는 항상 `상태: 초안`으로 시작한다. Codex는 사용자 명시 승인 없이 design 문서 상태를 `상태: 승인됨`으로 바꾸지 않는다.

## Design 문서 생성과 갱신 분류

Codex는 gameplay 관련 요청을 처리하기 전에 기존 design 문서로 충분한지 판단한다.

- `D0`: design 문서가 필요 없음. 문서 정리, 내부 구현 세부 조정, 하네스 규칙 도입처럼 player-facing gameplay 결정을 만들지 않는 작업이다.
- `D1`: 필수 baseline 생성 또는 승인 필요. `docs/design/core-beliefs.md`가 없거나 `상태: 승인됨`이 아니다.
- `D2`: 기존 design 문서 갱신 필요. 승인된 문서가 있지만 요청이 그 범위를 바꾸거나 오래된 결정을 수정한다.
- `D3`: 새 조건부 design 문서 생성 필요. 요청한 gameplay 작업을 설명하는 승인 design 문서가 아직 없다.

`D1`, `D2`, `D3`가 필요하다고 판단하면 Codex는 먼저 사용자에게 다음을 보고하고, design 문서 생성 또는 갱신 방향을 확인한다.

- 기존 문서로 충분하지 않은 이유.
- 막혀 있는 player-facing 결정.
- 필요한 조치 수준.
- 생성 또는 수정할 파일.
- 사용자에게 먼저 물어야 할 질문.

Codex는 새 design 문서를 조용히 만들지 않는다. 사용자와 범위를 확인한 뒤 `상태: 초안`으로 생성한다.

## Player-Facing Gameplay 결정 예시

다음은 design 문서에서 다뤄야 하는 player-facing gameplay 결정이다.

- 플레이어 입력 방식.
- 이동 규칙.
- 성공 조건.
- 실패 조건.
- Retry 또는 reset 규칙.
- UI 피드백.
- 레벨 목표.
- 플레이어가 볼 수 있는 상태 변화.

다음은 player-facing gameplay 결정이 아니다.

- C# 파일명.
- private 메서드 구조.
- 임시 오브젝트 이름.
- 내부 코드 분리 방식.
- git 커밋 메시지.

## Gameplay ExecPlan과 Design 기준

Player-facing gameplay ExecPlan은 승인된 `docs/design/core-beliefs.md`와 해당 작업의 플레이어 경험 또는 게임 규칙을 정의하는 승인된 design 문서 최소 1개를 함께 참조해야 한다.

`core-beliefs.md`만으로는 gameplay ExecPlan을 시작할 수 없다. `core-beliefs.md`는 프로젝트 방향 기준이고, 실제 gameplay 작업에는 해당 작업의 플레이어 경험이나 게임 규칙을 정의하는 별도 승인 문서가 필요하다.

조건부 design 문서는 작업이 필요로 할 때만 만든다. 예를 들어 gameplay loop를 구체화해야 하는 작업에서는 `gameplay-loop.md` 같은 문서가 필요할 수 있지만, 모든 게임이나 모든 마일스톤의 필수 문서는 아니다.

## Baseline 문서 템플릿

`docs/design/core-beliefs.md`는 다음 항목을 최소로 포함한다.

```md
# Core Beliefs

상태: 초안

## 목적

이 문서가 어떤 프로젝트 방향 기준을 제공하는지 설명한다.

## 핵심 원칙

- 프로젝트가 유지해야 하는 player-facing 방향을 적는다.
- Codex가 임의로 바꾸면 안 되는 기준을 적는다.

## 초기 마일스톤에서 하지 않을 것

- 초기 범위에서 제외할 design 방향을 적는다.

## 승인 체크리스트

- [ ] 사용자가 이 문서의 상태를 `승인됨`으로 바꾸라고 명시했다.
- [ ] 이 문서가 gameplay ExecPlan의 baseline 기준으로 충분한지 확인했다.
```

## 조건부 Design 문서 템플릿

조건부 design 문서는 다음 항목을 최소로 포함한다.

```md
# 문서 제목

상태: 초안

## 목적

이 문서가 어떤 player-facing gameplay 결정 기준을 제공하는지 설명한다.

## 적용 범위

이 문서가 다루는 플레이어 경험, 게임 규칙, 화면 상태를 적는다.

## 제외 범위

이 문서가 일부러 결정하지 않는 항목을 적는다.

## 결정 사항

- 승인할 gameplay 결정을 적는다.

## 열린 질문

- 아직 승인되지 않은 질문을 적는다.

## 승인 체크리스트

- [ ] 사용자가 이 문서의 상태를 `승인됨`으로 바꾸라고 명시했다.
- [ ] 관련 gameplay ExecPlan이 새 규칙을 발명하지 않고 이 문서를 참조한다.
```
