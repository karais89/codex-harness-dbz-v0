# Design 템플릿 강화

## 목적

이 ExecPlan의 목적은 `docs/design/README.md`에 있는 `core-beliefs.md` 템플릿과 조건부 design 문서 템플릿을 강화해, 다음 프로젝트나 다음 design 작업에서 필요한 섹션이 더 명확한 design 기준으로 작성되게 만드는 것이다.

완료 후에는 Codex가 새 `core-beliefs.md` 또는 조건부 design 문서를 만들 때, 단순한 방향 문서가 아니라 이후 gameplay ExecPlan의 판단 기준으로 쓸 수 있는 섹션을 빠뜨리지 않도록 안내할 수 있다.

이 계획은 gameplay 설계, gameplay 구현, Unity 씬 변경, 테스트 추가 계획이 아니다. 기존 승인된 `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md` 본문은 수정하지 않는다.

## 진행 상황

상태: 완료됨

- [x] M3 완료 상태를 확인했다.
- [x] design 템플릿 강화 범위를 논의했다.
- [x] 공유된 이해 검증을 완료했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공한다.
- [x] 사용자가 구현 시작을 승인했다.
- [x] 구현 시작 후 상태를 `진행 중`으로 갱신했다.
- [x] 작업 전 `git status --short`를 재확인했다.
- [x] `docs/design/README.md`의 Core Beliefs 템플릿을 강화했다.
- [x] `docs/design/README.md`의 조건부 Design 문서 템플릿을 강화했다.
- [x] 강화 템플릿은 신규 또는 갱신 design 문서부터 적용하고, 기존 승인 design 문서에는 소급 적용하지 않는다고 명시했다.
- [x] `docs/decisions.md`에 장기 design 템플릿 적용 결정을 기록했다.
- [x] `docs/current-state.md`를 구현 결과에 맞게 갱신했다.
- [x] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록했다.
- [x] 구현 완료 커밋 후 `git status --short`가 clean임을 확인한다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

M3 Verification Loop는 완료되었다. 현재 `README.md`와 `docs/current-state.md`는 M3 완료와 M4 Handoff Test가 다음 단계임을 기록한다. 이 작업은 M4를 시작하기 전에, 하네스를 다른 프로젝트에 재사용할 때 design 문서 템플릿이 충분히 단단한지 확인하다가 발견된 보강 작업이다.

현재 `docs/design/README.md`에는 다음 규칙이 이미 있다.

- `docs/design/README.md`는 design 문서 작성 규약이고, `docs/design/*.md`는 실제 design 산출물이다.
- `상태: 승인됨`인 실제 design 산출물만 gameplay ExecPlan이나 구현 기준으로 사용할 수 있다.
- `docs/design/core-beliefs.md`는 Codex가 추론해 바로 작성하지 않고, 사용자 인터뷰와 공유된 이해 검증 뒤 `상태: 초안`으로 작성한다.
- Player-facing gameplay ExecPlan은 승인된 `core-beliefs.md`와 관련 승인 design 문서 최소 1개를 함께 참조해야 한다.

다만 현재 템플릿은 최소 골격에 가깝다. 실제 승인된 `docs/design/core-beliefs.md`는 `성공과 실패 판단 기준`, `Codex가 임의로 확정하지 않을 것`, `아직 정하지 않을 것` 같은 유용한 섹션을 갖고 있지만, `docs/design/README.md`의 템플릿은 그 수준을 필수로 안내하지 않는다.

관련 파일과 폴더는 다음과 같다.

- `docs/design/README.md`: 이번 작업의 주 수정 대상이다.
- `docs/design/core-beliefs.md`: 기존 승인 design baseline이다. 이번 작업에서는 본문을 수정하지 않는다.
- `docs/design/gameplay-loop.md`: 기존 승인 조건부 design 문서다. 이번 작업에서는 본문을 수정하지 않는다.
- `docs/decisions.md`: 강화 템플릿 적용 방식이 장기 규칙이 되면 기록한다.
- `docs/current-state.md`: 활성 계획과 구현 결과를 기록한다.
- `exec-plans/010-design-template-strengthening.md`: 이 계획 파일이다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 `docs/design/README.md`, `docs/decisions.md`의 장기 결정, 기존 design 문서 본문을 수정하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리 상태를 확인한다.
   - `docs/design/README.md`, `docs/design/core-beliefs.md`, `docs/design/gameplay-loop.md`, `docs/current-state.md`, `docs/decisions.md`가 존재하는지 확인한다.
   - `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`가 `상태: 승인됨`인지 확인한다.

3. Core Beliefs 템플릿을 강화한다.
   - `docs/design/README.md`의 `Baseline 문서 템플릿`을 갱신한다.
   - 템플릿의 기본 상태는 재사용 가능한 placeholder 기준으로 `상태: 작성 전`을 사용한다.
   - Core Beliefs 템플릿에는 최소한 다음 섹션을 포함한다.
     - 목적
     - 프로젝트 정체성
     - 플레이어 경험 방향
     - 핵심 원칙
     - 초기 마일스톤에서 하지 않을 것
     - 성공과 실패 판단 기준
     - Codex가 임의로 확정하지 않을 것
     - 아직 정하지 않을 것
     - 승인 체크리스트
   - 승인 체크리스트에는 사용자 인터뷰, 공유된 이해 검증, `상태: 초안` 작성, 사용자 명시 승인, 아직 정하지 않을 항목 분리를 포함한다.

4. 조건부 Design 문서 템플릿을 강화한다.
   - `docs/design/README.md`의 `조건부 Design 문서 템플릿`을 갱신한다.
   - 템플릿의 기본 상태는 재사용 가능한 placeholder 기준으로 `상태: 작성 전`을 사용한다.
   - 조건부 design 템플릿에는 최소한 다음 섹션을 포함한다.
     - 목적
     - 적용 범위
     - 제외 범위
     - 플레이어 경험 기준
     - 결정 사항
     - 검증 기준
     - 열린 질문
     - Codex 금지 사항
     - 승인 체크리스트
   - 승인 체크리스트에는 사용자 인터뷰, 공유된 이해 검증, 사용자 명시 승인, 관련 gameplay ExecPlan 참조를 포함한다.

5. 소급 적용 범위를 명확히 한다.
   - 강화된 템플릿은 새 design 문서 또는 기존 design 문서를 다음에 갱신할 때 적용한다고 명시한다.
   - 이미 `상태: 승인됨`인 design 문서는 사용자가 명시적으로 재검토를 요청하거나, 문서 내용이 현재 작업을 뒷받침하지 못한다고 판단될 때만 갱신 대상으로 본다고 명시한다.
   - 이 문구로 기존 `core-beliefs.md`와 `gameplay-loop.md`가 새 템플릿 섹션명과 다르다는 이유만으로 자동 무효화되지 않게 한다.

6. 문서를 갱신하고 검증한다.
   - 강화 템플릿 적용 방식이 장기 규칙이므로 `docs/decisions.md`에 기록한다.
   - `docs/current-state.md`에 이번 하네스 규약 보강의 완료 상태와 다음 단계를 갱신한다.
   - 이 ExecPlan의 진행 상황, 검증 결과, 결정 기록, 회고를 갱신한다.
   - 최종적으로 `git status --short`를 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- `docs/design/README.md`의 Core Beliefs 템플릿에 `프로젝트 정체성`, `플레이어 경험 방향`, `성공과 실패 판단 기준`, `Codex가 임의로 확정하지 않을 것`, `아직 정하지 않을 것`이 포함된다.
- `docs/design/README.md`의 조건부 Design 문서 템플릿에 `플레이어 경험 기준`, `검증 기준`, `Codex 금지 사항`이 포함된다.
- 강화 템플릿은 신규 또는 갱신 design 문서부터 적용하고, 기존 승인 design 문서에는 자동 소급 적용하지 않는다는 문장이 있다.
- 기존 승인 문서인 `docs/design/core-beliefs.md`와 `docs/design/gameplay-loop.md`의 본문은 수정하지 않는다.
- `docs/decisions.md`에 강화된 design 템플릿 적용 방식이 장기 결정으로 기록된다.
- `docs/current-state.md`가 이번 계획 상태와 다음 단계를 반영한다.
- 이 ExecPlan의 진행 상황, 결정 기록, 예상 밖 발견, 회고가 갱신된다.
- 최종 커밋 후 `git status --short`가 clean이다.

현재 검증 결과:

- ExecPlan 생성 전 `git status --short`: 출력 없음. 작업트리 clean.
- 구현 시작 후 `git status --short`: `docs/current-state.md` 수정과 `exec-plans/010-design-template-strengthening.md` 추가만 있었다.
- `README.md`는 M3 완료와 M4 Handoff Test가 다음 단계임을 기록한다.
- `docs/current-state.md`는 활성 계획 없음과 M3 완료를 기록한다.
- `exec-plans/010-design-template-strengthening.md` 번호가 비어 있음을 확인했다.
- `docs/design/README.md`의 Core Beliefs 템플릿에 `프로젝트 정체성`, `플레이어 경험 방향`, `성공과 실패 판단 기준`, `Codex가 임의로 확정하지 않을 것`, `아직 정하지 않을 것`이 포함됨을 확인했다.
- `docs/design/README.md`의 조건부 Design 문서 템플릿에 `플레이어 경험 기준`, `검증 기준`, `Codex 금지 사항`이 포함됨을 확인했다.
- `docs/design/README.md`에 강화 템플릿은 신규 또는 갱신 design 문서부터 적용하고, 기존 승인 design 문서에는 자동 소급 적용하지 않는다는 문장이 있음을 확인했다.
- `git diff --name-only -- docs/design/core-beliefs.md docs/design/gameplay-loop.md`: 출력 없음. 기존 승인 design 문서 본문은 수정하지 않았다.
- `docs/decisions.md`에 강화된 design 템플릿 적용 방식을 장기 결정으로 기록했다.
- `docs/current-state.md`에 `exec-plans/010-design-template-strengthening.md` 완료와 다음 단계 M4 Handoff Test를 기록했다.
- 최종 커밋 후 `git status --short`: 출력 없음. 작업트리 clean.

## 자체 리뷰

- 공유된 이해 검증 내용과 ExecPlan 내용이 일치한다.
- 목표는 design 문서 템플릿 강화로 제한되어 있다.
- 포함 범위는 `docs/design/README.md`, `docs/decisions.md`, `docs/current-state.md`, 이 ExecPlan 갱신으로 제한되어 있다.
- 제외 범위는 기존 승인 design 문서 본문 수정, gameplay design 결정, Unity 코드/씬/테스트 변경, M4 시작으로 명시되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있다.
- 구현 승인 전에는 템플릿 본문과 장기 결정 기록을 수정하지 않도록 계획에 명시했다.
- 완료 기준은 문서 섹션 존재, 소급 적용 제외 문구, 문서 상태 갱신, `git status` 확인으로 관찰 가능하다.

## 결정 기록

- 결정: 강화된 design 템플릿은 신규 design 문서 또는 기존 design 문서를 다음에 갱신할 때 적용하고, 기존 승인 design 문서에는 자동 소급 적용하지 않는다.
  근거: 기존 `core-beliefs.md`와 `gameplay-loop.md`는 이미 승인된 기준이다. 템플릿 강화 때문에 기존 승인 문서가 형식 미달로 오해되면 M3 이후 handoff와 후속 작업에 불필요한 혼란이 생긴다.
  날짜: 2026-05-19

## 예상 밖 발견

- `git diff --name-only` 확인 중 Windows 줄바꿈 처리 경고가 출력됐다. 변경 파일 범위 확인에는 영향이 없었고, 기존 승인 design 문서 본문에는 diff가 없었다.

## 회고

Design 템플릿 강화 작업을 완료했다.

- 완료한 것: `docs/design/README.md`의 Core Beliefs 템플릿과 조건부 design 문서 템플릿을 판단 기준 중심으로 강화했고, 강화 템플릿의 소급 적용 제외 규칙을 명시했다. 장기 결정과 현재 상태도 갱신했다.
- 완료하지 못한 것: 없음. 기존 승인 design 문서 본문, gameplay 설계, Unity 코드와 씬은 의도적으로 수정하지 않았다.
- 배운 것: 실제 승인된 `core-beliefs.md`는 이미 템플릿보다 더 강한 섹션을 갖고 있었으므로, 재사용 가능한 하네스에서는 실제 성공 사례 수준을 템플릿으로 끌어올리는 편이 안전하다.
- 다음에 해야 할 것: M4 Handoff Test를 시작한다.
- 다음 계획을 시작할 준비가 되었는지 여부: 예. M4는 새 Codex 세션이 repo 문서만 읽고 현재 상태를 이어받을 수 있는지 검증한다.
