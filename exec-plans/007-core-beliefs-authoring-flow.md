# Core Beliefs 작성 절차 보강

## 1. 목적

이 계획의 목적은 `docs/design/core-beliefs.md`가 Codex 추론만으로 승인 가능한 초안처럼 작성되지 않도록 design 문서 작성 절차를 보강하는 것이다.

완료 후에는 `core-beliefs.md`를 만들거나 초안으로 전환하기 전에 사용자 인터뷰와 공유된 이해 검증이 필요하다는 규칙이 저장소 문서에 명확히 남는다. 현재 `core-beliefs.md`는 승인 가능한 design 기준이 아니라 `상태: 작성 전` placeholder로 전환된다.

이 계획은 006 Design Baseline 규칙 도입의 보완이다. 006은 완료된 기록으로 유지하고, 이 계획에서는 006 이후 발견된 보완점만 다룬다.

이 계획은 gameplay 구현 계획이 아니다. Unity 씬, C# 스크립트, gameplay 규칙 구현, `exec-plans/004-first-playable-loop.md`, `docs/design/gameplay-loop.md`는 범위 밖이다.

## 2. 진행 상황

- 상태: 완료
- [x] 기존 저장소 지침과 현재 상태 문서를 읽었다.
- [x] 관련 완료 계획인 `exec-plans/006-design-baseline-rules.md`를 읽었다.
- [x] 사용자 제공 계획을 이 작업의 구현 의도로 확인했다.
- [x] `docs/design/README.md`에 Core Beliefs 작성 절차와 상태 정의 보강을 반영한다.
- [x] `docs/design/core-beliefs.md`를 `상태: 작성 전` placeholder로 전환한다.
- [x] `AGENTS.md`와 `PLANS.md`에 승인된 실제 design 문서만 gameplay 기준이 된다는 규칙을 보강한다.
- [x] `docs/current-state.md`와 `docs/decisions.md`에 현재 상태와 장기 결정을 반영한다.
- [x] 검증 절차를 수행하고 결과를 기록한다.
- [x] 회고를 작성한다.

## 3. 맥락

현재 저장소는 `Codex Harness v0 — Delivery Bot Zero`이다. M0는 완료되었고, M1 First Playable Loop는 아직 시작하지 않았다.

006 계획을 통해 `docs/design/README.md`와 `docs/design/core-beliefs.md`가 추가되었다. 006 완료 시점의 `core-beliefs.md`는 `상태: 초안`으로 작성되었지만, 사용자 인터뷰와 공유된 이해 검증을 거쳐 작성된 초안은 아니었다.

이 상태는 006에서 도입한 Design Baseline Check의 의도와 충돌할 수 있다. `core-beliefs.md`가 승인 전 초안처럼 보이면 사용자가 문서 내용의 출처와 초안 자격을 혼동할 수 있기 때문이다.

따라서 이 계획은 `core-beliefs.md`의 초안 자격 조건을 명확히 하고, 현재 파일을 design 기준이 아닌 작성 전 placeholder로 전환한다.

현재 장기 상태 문서는 다음 경로를 사용한다.

- `docs/current-state.md`
- `docs/decisions.md`

M1 First Playable Loop ExecPlan 파일은 기존 결정대로 다음 경로를 사용하지만, 이 계획에서는 생성하거나 수정하지 않는다.

- `exec-plans/004-first-playable-loop.md`

## 4. 계획

1. `docs/design/README.md`를 보강한다.
   - `상태: 작성 전`을 design 문서 상태로 추가한다.
   - `상태: 초안`은 인터뷰와 공유된 이해 검증 후에만 사용할 수 있다고 정의한다.
   - `상태: 승인됨`만 gameplay ExecPlan이나 구현 기준으로 사용할 수 있다고 명시한다.
   - `Core Beliefs 작성 절차` 섹션을 추가한다.
   - `core-beliefs.md`는 Codex가 추론해서 바로 쓰지 않는다고 명시한다.
   - 질문은 한 번에 하나씩 하고, 각 질문에는 Codex 추천 답안을 포함한다고 명시한다.
   - 인터뷰 주제를 게임 정체성, 플레이어 경험 방향, 초기 마일스톤에서 하지 않을 것, 성공/실패 판단 기준, Codex가 임의로 만들면 안 되는 design 결정으로 제한한다.
   - M1 세부 규칙, 좌표, 수치, 씬 구조, C# 스크립트 이름, 구현 방식은 `core-beliefs.md` 인터뷰에서 정하지 않는다고 명시한다.
   - 공유된 이해를 검증하고 사용자가 맞다고 확인한 뒤에만 `상태: 초안`으로 작성한다고 명시한다.

2. `docs/design/core-beliefs.md`를 전환한다.
   - 상태를 `상태: 작성 전`으로 바꾼다.
   - 현재 핵심 원칙처럼 보이는 내용을 제거하거나 작성 전 안내로 대체한다.
   - 아직 design 기준이 아니며 인터뷰 후 다시 작성된다고 명시한다.
   - Delivery Bot Zero, Unity 2D, Codex 워크플로우 검증 같은 확인된 사실은 `알려진 프로젝트 사실`로만 기록한다.
   - 사용자 승인 없이 `상태: 승인됨`으로 바꾸지 않는다.

3. 하네스 문서를 맞춘다.
   - `AGENTS.md`에 `core-beliefs.md`가 `작성 전`, `초안`, `수정 필요`이면 gameplay 설계, gameplay ExecPlan, gameplay 구현을 멈추도록 명시한다.
   - `PLANS.md`에 gameplay ExecPlan의 승인된 Design 기준은 `상태: 승인됨`인 실제 design 문서만 가능하다고 명시한다.

4. 프로젝트 상태와 장기 결정을 갱신한다.
   - `docs/current-state.md`에 `core-beliefs.md`가 `상태: 작성 전`이며 M1을 시작할 수 없다고 기록한다.
   - `docs/decisions.md`에 `core-beliefs.md`는 인터뷰와 공유된 이해 검증 후에만 초안이 될 수 있다는 장기 결정을 기록한다.

5. 범위 밖 항목을 유지한다.
   - Unity 씬, C# 스크립트, gameplay 구현 파일은 변경하지 않는다.
   - `exec-plans/004-first-playable-loop.md`는 생성하거나 수정하지 않는다.
   - `docs/design/gameplay-loop.md`는 생성하지 않는다.

## 5. 검증

검증은 다음 방식으로 수행한다.

1. 문서 내용 확인
   - `docs/design/README.md`에 `Core Beliefs 작성 절차`가 있다.
   - `상태: 작성 전`과 `상태: 초안`의 차이가 명확하다.
   - `core-beliefs.md` 생성 전에 인터뷰와 공유된 이해 검증이 필요하다고 적혀 있다.
   - `core-beliefs.md`만으로 M1을 시작할 수 없다는 기존 규칙이 유지된다.

2. 범위 확인
   - Unity 씬, C# 스크립트, gameplay 구현 파일 변경이 없다.
   - `exec-plans/004-first-playable-loop.md`가 생성되거나 수정되지 않았다.
   - `docs/design/gameplay-loop.md`가 생성되지 않았다.

3. 상태 확인
   - `docs/design/core-beliefs.md`는 `상태: 작성 전`이다.
   - `docs/design/core-beliefs.md`를 `상태: 승인됨`으로 바꾸지 않았다.
   - `git diff --check`를 통과한다.
   - 커밋 후 `git status --short` 출력이 없다.

### 검증 결과

2026-05-19에 다음을 확인했다.

- `docs/design/README.md`에 `Core Beliefs 작성 절차`가 있다.
- `docs/design/README.md`에 `상태: 작성 전`과 `상태: 초안`의 차이가 기록되어 있다.
- `docs/design/README.md`에 `core-beliefs.md` 작성 전에 인터뷰와 공유된 이해 검증이 필요하다고 기록되어 있다.
- `docs/design/core-beliefs.md`의 문서 상단 상태는 `상태: 작성 전`이다.
- `docs/design/core-beliefs.md`는 `상태: 승인됨`으로 변경하지 않았다.
- `git diff --check`는 통과했다. Git이 일부 파일의 LF가 다음 처리 시 CRLF로 바뀔 수 있다는 경고를 출력했지만 whitespace error는 없었다.
- `git diff --name-only`에는 `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, `docs/design/README.md`, `docs/design/core-beliefs.md`만 표시되었다.
- `git status --short`에는 위 수정 파일과 새 `exec-plans/007-core-beliefs-authoring-flow.md`만 표시되었다.
- `Test-Path exec-plans/004-first-playable-loop.md`: `False`.
- `Test-Path docs/design/gameplay-loop.md`: `False`.
- Unity 씬, C# 스크립트, gameplay 구현 파일은 변경하지 않았다.

## 6. 결정 기록

- 결정: `docs/design/core-beliefs.md`는 인터뷰와 공유된 이해 검증 전에는 `상태: 작성 전`으로 둔다.
  근거: Codex가 추론한 내용을 승인 가능한 design 초안처럼 보이게 두면 gameplay 기준의 출처가 불명확해진다.
  날짜: 2026-05-19

- 결정: 006 계획은 완료 기록으로 유지하고 007에서 보완점을 다룬다.
  근거: 완료된 계획을 새 범위로 다시 열면 과거 검증 기록과 현재 보완 작업이 섞인다.
  날짜: 2026-05-19

## 7. 예상 밖 발견

- 로컬 명령은 Windows 샌드박스 프로세스 생성 오류가 발생해 승인된 격상 실행으로 수행했다.
- `git diff --check`는 통과했지만, Git이 일부 기존 문서 파일의 LF가 다음 처리 시 CRLF로 바뀔 수 있다는 경고를 출력했다.

## 8. 회고

- 완료한 것: Core Beliefs 작성 절차를 `docs/design/README.md`에 추가하고, `docs/design/core-beliefs.md`를 `상태: 작성 전` placeholder로 전환했다. `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`에 gameplay 기준으로 사용할 수 있는 design 상태와 다음 절차를 반영했다.
- 완료하지 못한 것: 실제 Core Beliefs 인터뷰와 초안 작성은 이 계획 범위가 아니므로 수행하지 않았다. M1 조건부 design 문서와 `exec-plans/004-first-playable-loop.md`도 생성하지 않았다.
- 배운 것: `core-beliefs.md`가 존재한다는 사실과 승인 가능한 design 초안이라는 사실을 분리해야 이후 gameplay ExecPlan의 design 기준이 더 명확해진다.
- 다음에 해야 할 것: 사용자가 Core Beliefs 작성을 원하면 인터뷰를 시작하고, 공유된 이해 검증 후 `core-beliefs.md`를 `상태: 초안`으로 다시 작성한다.
- M1을 시작할 준비가 되었는지 여부: 아직 아니다. `docs/design/core-beliefs.md`가 `상태: 작성 전`이고, M1 gameplay 규칙을 정의하는 승인 design 문서도 아직 없다.
