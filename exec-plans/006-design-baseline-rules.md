# Design Baseline 규칙 도입

## 1. 목적

이 계획의 목적은 M1 First Playable Loop를 시작하기 전에 `docs/design` 규약을 하네스에 추가하는 것이다.

완료 후에는 Codex가 승인된 design 기준 없이 player-facing gameplay 규칙을 추론하거나 ExecPlan에 섞어 넣지 못한다. M1 같은 gameplay 작업은 먼저 design baseline과 관련 design 문서를 확인하고, 필요한 경우 사용자에게 design 문서 생성 또는 갱신이 먼저 필요하다고 알린 뒤 진행한다.

이 계획은 design 문서 작성 규약과 실제 design 산출물을 분리한다. `docs/design/README.md`는 `PLANS.md`가 ExecPlan 작성 규약인 것처럼 design 문서 작성 규약이고, `docs/design/*.md` 파일은 `exec-plans/*.md`가 실제 실행 계획인 것처럼 실제 design 산출물이다.

이 계획은 게임플레이 구현 계획이 아니다. Unity 씬, C# 스크립트, gameplay 규칙 구현, M1 First Playable Loop 구현은 포함하지 않는다.

## 2. 진행 상황

- 상태: 저장소 문서 반영 승인 대기
- [x] 사용자와 design baseline 필요성을 논의했다.
- [x] `docs/design`은 마일스톤 문서 폴더가 아니라 승인된 플레이어 경험과 게임 규칙 기준 문서 폴더로 정의하기로 했다.
- [x] `gameplay-loop.md`는 모든 게임의 필수 문서가 아니라 조건부 design 문서 예시로 두기로 했다.
- [x] `core-beliefs.md`만으로는 gameplay ExecPlan을 시작할 수 없다는 규칙을 계획에 포함했다.
- [x] 이 계획 자체는 하네스/문서 규칙 도입 계획이므로 Design Dependency Check 적용 대상이 아님을 계획에 포함했다.
- [x] `docs/design/README.md`는 승인 상태 확인 대상이 아니라 존재 확인 대상으로 두기로 했다.
- [x] `core-beliefs.md`가 초안이면 M1을 아직 시작할 수 없다는 조건을 계획에 포함했다.
- [x] `docs/design/README.md`는 design 문서 작성 규약이고 `docs/design/core-beliefs.md`는 그 규약에 따라 생성되는 실제 design 산출물임을 계획에 포함했다.
- [ ] 사용자에게 이 ExecPlan 검토용 요약을 제공한다.
- [ ] 사용자에게 저장소 문서 반영 승인 여부를 확인한다.
- [ ] 승인 후 design baseline 규칙을 저장소 문서에 반영한다.
- [ ] 검증 절차를 수행하고 결과를 기록한다.
- [ ] 회고를 작성한다.

## 3. 맥락

현재 저장소는 `Codex Harness v0 — Delivery Bot Zero`이다. M0는 완료되었고, M1 First Playable Loop 시작 전이다.

현재 장기 상태 문서는 다음 경로를 사용한다.

- `docs/current-state.md`
- `docs/decisions.md`

`docs/project/` 구조는 현재 저장소에 없다. 따라서 이 계획에서는 `docs/project/current-state.md`나 `docs/project/decisions.md`를 만들지 않는다.

기존 규칙에 따르면 M1 같은 사소하지 않은 작업은 논의, `grill-me` 방식 인터뷰, 공유된 이해 검증, ExecPlan 생성 승인, ExecPlan 자체 리뷰, 구현 승인 게이트를 거친다.

기존 장기 결정에 따라 M1 First Playable Loop ExecPlan 파일은 다음 경로로 예약되어 있다.

- `exec-plans/004-first-playable-loop.md`

이 계획은 M1 구현 계획이 아니라 M1 이전 하네스 보강 계획이다. 따라서 `004`를 사용하지 않고 다음 사용 가능한 번호인 `006`을 사용한다.

이 계획에서 도입하는 design 문서 구조는 ExecPlan 구조와 대응된다.

- `PLANS.md`: ExecPlan 작성 규약.
- `exec-plans/*.md`: 실제 실행 계획.
- `docs/design/README.md`: design 문서 작성 규약.
- `docs/design/*.md`: 실제 design 산출물.

## 4. 계획

1. `docs/design/README.md`를 추가한다.
   - `docs/design`의 역할을 설명한다.
   - design 문서는 마일스톤 문서가 아니라 승인된 플레이어 경험, 게임 방향, 게임 규칙 기준 문서임을 명시한다.
   - `docs/design/README.md` 자체는 player-facing gameplay design 문서가 아니라 design 문서 작성 규약 파일이므로 존재 여부만 확인 대상으로 둔다.
   - `docs/design/README.md`는 `PLANS.md`가 ExecPlan 작성 규약인 것과 같은 역할을 한다고 명시한다.
   - `docs/design/*.md` 파일은 `exec-plans/*.md`가 실제 실행 계획인 것처럼 실제 design 산출물이라고 명시한다.
   - design 문서 상태 값을 정의한다.
     - `상태: 초안`
     - `상태: 승인됨`
     - `상태: 수정 필요`
   - 새 design 문서는 항상 `상태: 초안`으로 시작하고, `상태: 승인됨`은 사용자 명시 승인 후에만 사용할 수 있음을 명시한다.
   - 새 design 문서를 조용히 만들지 않는 규칙을 추가한다.
   - 새 design 문서 생성 또는 갱신 필요성을 판단할 때 다음 분류를 사용한다.
     - `D0`: design 문서가 필요 없음.
     - `D1`: 필수 baseline 생성 또는 승인 필요.
     - `D2`: 기존 design 문서 갱신 필요.
     - `D3`: 새 조건부 design 문서 생성 필요.
   - Codex가 `D1`, `D2`, `D3`가 필요하다고 판단하면 먼저 사용자에게 다음을 보고한다.
     - 기존 문서로 충분하지 않은 이유.
     - 막혀 있는 player-facing 결정.
     - 필요한 조치 수준.
     - 생성 또는 수정할 파일.
     - 사용자에게 먼저 물어야 할 질문.
   - player-facing gameplay 결정 예시를 포함한다.
     - 플레이어 입력 방식.
     - 이동 규칙.
     - 성공 조건.
     - 실패 조건.
     - Retry/reset 규칙.
     - UI 피드백.
     - 레벨 목표.
     - 플레이어가 볼 수 있는 상태 변화.
   - player-facing gameplay 결정이 아닌 예시를 포함한다.
     - C# 파일명.
     - private 메서드 구조.
     - 임시 오브젝트 이름.
     - 내부 코드 분리 방식.
     - git 커밋 메시지.
   - baseline 문서와 조건부 design 문서의 짧은 템플릿을 포함한다.
   - `core-beliefs.md` 템플릿은 최소한 다음 항목을 포함한다.
     - 제목.
     - 상태.
     - 목적.
     - 핵심 원칙.
     - 초기 마일스톤에서 하지 않을 것.
     - 승인 체크리스트.
   - 조건부 design 문서 템플릿은 최소한 다음 항목을 포함한다.
     - 제목.
     - 상태.
     - 목적.
     - 적용 범위.
     - 제외 범위.
     - 결정 사항.
     - 열린 질문.
     - 승인 체크리스트.

2. `docs/design/core-beliefs.md`를 추가한다.
   - `docs/design/README.md`의 템플릿과 규칙에 따라 생성되는 첫 번째 실제 프로젝트 design 산출물로 둔다.
   - 처음 상태는 `상태: 초안`으로 둔다.
   - 사용자 명시 승인 전에는 player-facing gameplay ExecPlan의 승인 기준으로 사용할 수 없다고 명시한다.
   - Delivery Bot Zero가 유지해야 할 핵심 방향을 기록한다.
   - 이 프로젝트가 작은 Unity 2D 게임으로 Codex 기반 개발 워크플로우를 검증한다는 점을 기록한다.
   - 초기 작업은 작고 Play Mode에서 관찰 가능해야 한다는 점을 기록한다.
   - Codex가 승인되지 않은 player-facing gameplay 규칙을 만들지 않는다는 점을 기록한다.
   - 구체적인 M1 규칙, 좌표, 수치, 씬 구조, 스크립트 이름은 넣지 않는다.

3. `AGENTS.md`에 `Design Baseline Check`를 추가한다.
   - player-facing gameplay 설계, ExecPlan, 구현을 시작하기 전에 `docs/design/README.md`가 존재하는지 확인하도록 한다.
   - player-facing gameplay 설계, ExecPlan, 구현을 시작하기 전에 `docs/design/core-beliefs.md`가 존재하고 `상태: 승인됨`인지 확인하도록 한다.
   - `docs/design/README.md`가 없거나 `docs/design/core-beliefs.md`가 없거나 `core-beliefs.md`가 `상태: 승인됨`이 아니면 gameplay ExecPlan이나 구현을 멈추고 사용자에게 design baseline 생성 또는 승인이 먼저 필요하다고 알리도록 한다.
   - 하네스, 문서 구조, workflow 규칙 도입 작업에는 이 체크가 적용되지 않는다고 명시한다.
   - 단, 하네스 또는 문서 작업 중 player-facing gameplay 규칙을 정의하기 시작하면 Design Gate로 전환한다고 명시한다.

4. `PLANS.md`에 `Design Dependency Check`와 `승인된 Design 기준` 규칙을 추가한다.
   - player-facing gameplay ExecPlan은 승인된 `docs/design/core-beliefs.md`와 해당 작업의 플레이어 경험 또는 게임 규칙을 정의하는 승인된 design 문서 최소 1개를 함께 참조해야 한다.
   - `core-beliefs.md`만으로는 gameplay ExecPlan을 시작할 수 없다고 명시한다.
   - gameplay ExecPlan에는 다음 섹션을 포함하도록 한다.

```md
## 승인된 Design 기준

- `docs/design/core-beliefs.md` 상태: 승인됨
- `docs/design/<relevant-design-doc>.md` 상태: 승인됨
```

   - 관련 승인 design 문서가 없으면 ExecPlan 작성을 멈추고 design 확인을 요청하도록 한다.
   - ExecPlan은 새로운 player-facing 규칙을 발명하지 않고, 승인된 design 문서를 구현 방법으로 옮기는 역할만 한다고 명시한다.

5. `docs/decisions.md`를 갱신한다.
   - `docs/design`은 마일스톤 문서 폴더가 아니라 승인된 플레이어 경험과 게임 규칙 기준 문서 폴더라는 결정을 기록한다.
   - design 문서는 기본적으로 마일스톤명이 아니라 개념, 규칙, 시스템, 플레이어 경험 기준으로 이름 붙인다는 결정을 기록한다.
   - player-facing gameplay ExecPlan은 승인된 baseline과 관련 design 문서 없이는 만들지 않는다는 결정을 기록한다.

6. `docs/current-state.md`를 갱신한다.
   - M1 시작 전 design baseline 규칙 도입이 선행 준비 단계임을 기록한다.
   - 활성 계획을 `exec-plans/006-design-baseline-rules.md`로 표시한다.
   - M1 First Playable Loop는 아직 시작하지 않았고 `exec-plans/004-first-playable-loop.md`는 계속 예약 상태이며, 이번 작업에서는 생성하거나 수정하지 않는다고 기록한다.
   - 이 계획이 끝난 직후에도 `docs/design/core-beliefs.md`가 `상태: 초안`이면 M1은 아직 시작할 수 없고, M1 시작 전 사용자 검토와 명시 승인이 필요하다고 기록한다.
   - 다음 단계는 `core-beliefs.md` 사용자 승인 이후 M1에 필요한 조건부 design 문서가 필요한지 판단하는 것이라고 기록한다.

7. 자체 리뷰를 수행한다.
   - `AGENTS.md`, `PLANS.md`, `docs/design/README.md`, `docs/design/core-beliefs.md`, `docs/decisions.md`, `docs/current-state.md`가 서로 충돌하지 않는지 확인한다.
   - `docs/design/README.md`가 design 문서 작성 규약이고 `docs/design/core-beliefs.md`가 실제 design 산출물이라는 구분이 명확한지 확인한다.
   - Design Dependency Check가 이 계획 자체를 막지 않도록 예외가 명확한지 확인한다.
   - `core-beliefs.md`만으로 gameplay ExecPlan을 시작할 수 없다는 규칙이 명확한지 확인한다.
   - `gameplay-loop.md`가 필수 파일처럼 고정되지 않았는지 확인한다.

## 5. 검증

검증은 다음 방식으로 수행한다.

1. 파일 존재 확인
   - `docs/design/README.md`
   - `docs/design/core-beliefs.md`
   - `exec-plans/006-design-baseline-rules.md`

2. 문서 내용 확인
   - `AGENTS.md`에 `Design Baseline Check`가 있다.
   - `PLANS.md`에 `Design Dependency Check`와 `승인된 Design 기준` 섹션 규칙이 있다.
   - `docs/decisions.md`에 design baseline 장기 결정이 있다.
   - `docs/current-state.md`가 M1 전 상태와 활성 계획을 정확히 설명한다.
   - `docs/design/README.md`는 존재 확인 대상이고, `docs/design/core-beliefs.md`는 존재와 승인 상태 확인 대상이라는 차이가 문서에 반영되어 있다.
   - `docs/design/README.md`는 design 문서 작성 규약이고 `docs/design/*.md`는 실제 design 산출물이라는 대응 관계가 문서에 반영되어 있다.
   - `D0`, `D1`, `D2`, `D3` 분류가 문서 생성 또는 갱신 판단 기준으로 반영되어 있다.
   - `docs/design/README.md`에 player-facing gameplay 결정 예시와 비예시가 있다.
   - `docs/design/README.md`에 `core-beliefs.md`와 조건부 design 문서의 최소 템플릿 항목이 있다.

3. 범위 확인
   - Unity 씬을 변경하지 않았다.
   - C# 스크립트를 추가하거나 수정하지 않았다.
   - gameplay 구현 파일을 변경하지 않았다.
   - `exec-plans/004-first-playable-loop.md`를 생성하거나 수정하지 않았다.
   - M1 조건부 design 문서인 `gameplay-loop.md`를 이번 작업에서 만들지 않았다.

4. 상태 확인
   - 모든 새 문서와 수정 문서가 한글로 작성되어 있다.
   - 저장소 문서에 개인의 경력, 가족, 재정, 고용주 관련 민감 정보가 포함되어 있지 않다.
   - `docs/design/core-beliefs.md`는 처음 생성 시 `상태: 초안`이다.
   - 사용자의 명시 승인 없이는 `docs/design/core-beliefs.md`를 `상태: 승인됨`으로 변경하지 않았다.
   - `docs/design/core-beliefs.md`가 `상태: 초안`으로 남아 있으면 M1을 아직 시작할 수 없다는 점이 기록되어 있다.
   - `git status --short` 결과를 확인한다.
   - 커밋 후 `git status`가 clean인 상태를 목표로 한다.

## 6. 결정 기록

- 결정: `docs/design`은 마일스톤 문서 폴더가 아니라 승인된 플레이어 경험과 게임 규칙 기준 문서 폴더로 정의한다.
  근거: 마일스톤은 언제 구현할 것인지를 다루고, design 문서는 무엇을 만들 것인지와 어떤 규칙을 지킬 것인지를 다룬다.
  날짜: 2026-05-18

- 결정: 필수 design baseline은 `docs/design/README.md`와 `docs/design/core-beliefs.md`로 시작한다.
  근거: 하네스 v0에서는 문서 체계를 크게 만들기보다 Codex가 임의로 gameplay 방향을 발명하지 못하게 하는 최소 기준이 필요하다.
  날짜: 2026-05-18

- 결정: `gameplay-loop.md`는 모든 게임의 필수 문서가 아니라 조건부 design 문서 예시로 둔다.
  근거: 모든 게임이 루프 중심은 아니며, 하네스가 특정 장르나 설계 형태를 강제하면 안 된다.
  날짜: 2026-05-18

- 결정: `core-beliefs.md`만으로는 player-facing gameplay ExecPlan을 시작할 수 없다.
  근거: `core-beliefs.md`는 프로젝트 방향 기준이고, 실제 gameplay ExecPlan에는 해당 작업의 플레이어 경험 또는 게임 규칙을 정의하는 승인 문서가 별도로 필요하다.
  날짜: 2026-05-18

- 결정: 이 계획은 Design Dependency Check 적용 대상이 아니다.
  근거: 이 계획은 gameplay ExecPlan이 아니라 design baseline 규칙 자체를 도입하는 하네스/문서 구조 변경 계획이다.
  날짜: 2026-05-18

- 결정: `docs/design/README.md`는 승인 상태 확인 대상이 아니라 존재 확인 대상으로 둔다.
  근거: `README.md`는 플레이어 경험이나 게임 규칙을 승인하는 design 문서가 아니라 design 문서 작성 규약 파일이다.
  날짜: 2026-05-18

- 결정: `docs/design/core-beliefs.md`가 `상태: 초안`이면 M1을 시작할 수 없다.
  근거: player-facing gameplay ExecPlan은 승인된 design baseline을 필요로 하며, 초안 상태의 baseline은 구현 기준으로 사용할 수 없다.
  날짜: 2026-05-18

- 결정: `docs/design/README.md`는 design 문서 작성 규약이고, `docs/design/*.md`는 실제 design 산출물이다.
  근거: `PLANS.md`가 ExecPlan 작성 규약이고 `exec-plans/*.md`가 실제 실행 계획인 것처럼, design도 규약과 산출물을 분리해야 하네스를 재사용 가능한 방식으로 유지할 수 있다.
  날짜: 2026-05-19

## 7. 예상 밖 발견

- 아직 없음.

## 8. 회고

아직 작성하지 않는다. 이 계획이 구현, 검증, 문서 갱신까지 완료된 뒤 다음을 기록한다.

- 완료한 것
- 완료하지 못한 것
- 배운 것
- 다음에 해야 할 것
- M1을 시작할 준비가 되었는지 여부
