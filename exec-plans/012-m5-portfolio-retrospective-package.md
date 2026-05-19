# M5 공개 포트폴리오와 회고 패키지

## 목적

이 ExecPlan의 목적은 Delivery Bot Zero를 완성 게임처럼 확장하지 않고, Codex 기반 Unity 개발 워크플로우 실험 사례로 외부에 보여줄 수 있게 문서 패키지를 정리하는 것이다.

완료 후에는 외부 독자가 `README.md`만 읽어도 프로젝트 목적, 현재 Play Mode 루프, 실행과 조작 방법, M1-M4 결과, Codex 하네스 실험의 의미를 이해할 수 있다. 또한 별도 회고 문서에서 이번 하네스에서 다음 프로젝트에 가져갈 규칙과 버릴 규칙, 공개 저장소 기준 민감 정보 점검 결과를 확인할 수 있다.

이 계획은 새 gameplay 기능, 새 레벨, Unity 씬 변경, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가를 하지 않는다. 플레이 영상 또는 GIF 준비 항목도 M5 완료 범위에서 제외한다.

## 진행 상황

상태: 완료됨

- [x] M5 범위를 실험 사례 중심 공개 패키징으로 논의했다.
- [x] 플레이 영상 또는 GIF 준비 항목을 M5 완료 범위에서 제거하기로 합의했다.
- [x] 공유된 이해 검증을 완료했다.
- [x] 사용자가 이 ExecPlan 생성을 승인했다.
- [x] 이 ExecPlan을 생성했다.
- [x] Codex 자체 리뷰를 완료했다.
- [x] 사용자에게 검토용 요약을 제공한다.
- [x] 사용자가 구현 시작을 승인했다.
- [x] 구현 시작 후 상태를 `진행 중`으로 갱신했다.
- [x] 작업 전 `git status --short`를 재확인했다.
- [x] `README.md`를 공개용 실험 사례 소개 문서로 개선했다.
- [x] 실행과 조작 방법을 README에 정리했다.
- [x] M1-M4 결과 요약을 README와 회고 문서에 정리했다.
- [x] 하네스 회고 문서를 추가했다.
- [x] public repo 기준 민감 정보 점검 내용을 문서화했다.
- [x] 다음 프로젝트에 가져갈 규칙과 버릴 규칙을 문서화했다.
- [x] `docs/current-state.md`를 구현 결과에 맞게 갱신했다.
- [x] 필요한 경우 `docs/decisions.md`에 오래 유지할 결정을 기록했다.
- [x] 검증 결과와 예상 밖 발견을 이 ExecPlan에 기록했다.
- [x] 구현 완료 커밋 후 `git status --short`가 clean임을 확인했다.

## 맥락

저장소는 `Codex Harness v0 — Delivery Bot Zero`이며, 작은 Unity 2D 퍼즐 게임을 사용해 최소 Codex 주도 Unity 개발 워크플로우를 검증하는 실험이다.

현재 전제는 M1-M4가 완료되었다는 것이다.

- M1 First Playable Loop: `SampleScene` Play Mode에서 5 x 5 격자, `BOT`, `BOX`, `GOAL`, 막힌 칸, 턴 제한, Retry 버튼을 갖춘 최소 배송 루프를 만들었다.
- M2 Readability and Regression Check: 목표 문구와 UI 라벨을 읽기 쉽게 조정하고, M1 회귀 동작을 수동 검증했다.
- M3 Verification Loop: 반복 가능한 Play Mode 체크리스트와 `DeliveryLoopState` Edit Mode 테스트를 추가해 검증 루프를 강화했다.
- M4 Handoff Test: 새 Codex 세션이 저장소 문서만 읽고 현재 상태, 완료된 마일스톤, 승인된 design 기준, 검증 위치, 다음 작업을 이어받을 수 있음을 확인했다.

관련 파일과 폴더는 다음과 같다.

- `README.md`: 외부 공개 기준에서 가장 먼저 읽히는 문서다.
- `docs/current-state.md`: 현재 마일스톤, 활성 계획, 다음 단계를 기록한다.
- `docs/decisions.md`: 오래 유지할 프로젝트 결정이 있으면 기록한다.
- `docs/verification/play-mode-checklist.md`: 수동 Play Mode 검증 절차다.
- `docs/harness-reuse-guide.md`: 다른 프로젝트에서 하네스를 재사용할 때의 기준 문서다.
- `exec-plans/012-m5-portfolio-retrospective-package.md`: 이 계획 파일이다.

M5는 player-facing gameplay 설계나 구현 작업이 아니므로 Design Dependency Check의 gameplay 승인 기준을 새로 적용하지 않는다. 단, 작업 중 새 gameplay 규칙을 정의하려는 방향으로 범위가 바뀌면 즉시 멈추고 design gate로 전환해야 한다.

## 계획

1. 구현 승인 게이트를 통과한다.
   - 사용자가 `이 ExecPlan대로 구현을 시작할까요?` 질문에 짧게 긍정하면 구현 승인으로 본다.
   - 승인 전에는 `README.md`, 회고 문서, 공개 점검 문서를 수정하지 않는다.
   - 승인 후 이 파일의 진행 상황을 `상태: 진행 중`으로 갱신한다.

2. 작업 전 상태를 확인한다.
   - `git status --short`로 작업 트리 상태를 확인한다.
   - `README.md`, `docs/current-state.md`, `docs/decisions.md`, `docs/verification/play-mode-checklist.md`, `docs/harness-reuse-guide.md`가 존재하는지 확인한다.
   - 공개 패키징 작업이 gameplay 구현이나 Unity 씬 변경으로 확장되지 않도록 변경 대상 파일을 문서 중심으로 제한한다.

3. `README.md`를 공개용 실험 사례 소개로 개선한다.
   - 프로젝트를 "작은 Unity 2D 퍼즐 게임을 이용한 Codex 기반 Unity 워크플로우 실험"으로 소개한다.
   - 현재 Play Mode에서 가능한 일을 과장 없이 설명한다.
   - 실행 방법, 열어야 할 씬, Play Mode 시작 방법, 조작 방법, Retry 사용법을 정리한다.
   - M1-M4 결과를 짧게 요약한다.
   - 주요 문서와 ExecPlan 위치를 안내한다.
   - 아직 포함하지 않는 것과 M5에서 의도적으로 하지 않는 것을 명시한다.

4. 하네스 회고 문서를 작성한다.
   - 새 문서는 한글 Markdown으로 작성한다.
   - 기본 파일명은 `docs/harness-retrospective.md`를 사용한다.
   - 다음 내용을 포함한다.
     - 실험 목적과 판정
     - M1-M4에서 잘 작동한 것
     - 마찰이 있었던 것
     - Codex가 실수하기 쉬운 지점
     - Unity 검증에서 사람이 맡아야 했던 부분
     - 다음 프로젝트에 가져갈 규칙
     - 다음 프로젝트에서 버리거나 완화할 규칙
     - 아직 보류할 도구와 이유

5. public repo 기준 민감 정보 점검을 문서화한다.
   - 별도 점검 문서는 `docs/public-repo-checklist.md`를 기본 파일명으로 사용한다.
   - 개인의 경력, 가족, 재정, 고용주 관련 민감 정보가 저장소 문서에 들어가지 않았는지 점검한다.
   - 비밀키, 토큰, 인증 정보, 공개하면 안 되는 로컬 정보가 추적 파일에 들어가지 않았는지 점검한다.
   - Unity 생성물과 로컬 전용 폴더가 `.gitignore` 또는 추적 상태 관점에서 공개에 적절한지 확인한다.
   - 점검 결과를 "통과", "주의", "후속 필요"처럼 관찰 가능한 상태로 남긴다.

6. 상태와 필요한 장기 결정을 갱신한다.
   - `docs/current-state.md`에 M5 진행과 완료 결과를 반영한다.
   - 다음 프로젝트에도 가져갈 장기 규칙이 확정되면 `docs/decisions.md`에 기록한다.
   - 단순 회고나 일시적인 감상은 `docs/decisions.md`가 아니라 회고 문서에 둔다.

7. 검증하고 마무리한다.
   - 새 문서들이 존재하는지 확인한다.
   - README 링크와 문서 경로가 맞는지 확인한다.
   - `rg`로 금지 범위인 hooks, MCP, custom skill, subagent, 외부 패키지 추가가 실제 작업으로 들어가지 않았는지 확인한다.
   - 민감 정보 점검 문서가 필수 점검 항목을 포함하는지 확인한다.
   - 이 ExecPlan의 진행 상황, 검증 결과, 결정 기록, 예상 밖 발견, 회고를 갱신한다.
   - 최종적으로 커밋하고 `git status --short`가 clean인지 확인한다.

## 검증

구현 후 다음을 확인해야 한다.

- `README.md`가 프로젝트를 Codex 기반 Unity 워크플로우 실험 사례로 소개한다.
- `README.md`에 실행 방법과 조작 방법이 포함된다.
- `README.md` 또는 회고 문서에 M1-M4 결과 요약이 포함된다.
- `docs/harness-retrospective.md`가 존재한다.
- 회고 문서에 잘 작동한 것, 마찰, Codex가 실수하기 쉬운 지점, 사람이 맡아야 했던 Unity 검증, 가져갈 규칙, 버리거나 완화할 규칙, 보류할 도구가 포함된다.
- `docs/public-repo-checklist.md`가 존재한다.
- public repo 점검 문서에 민감 정보, 비밀키/토큰, 로컬 전용 정보, Unity 생성물과 `.gitignore` 점검이 포함된다.
- 플레이 영상 또는 GIF 준비 항목이 M5 완료 조건으로 추가되지 않았다.
- 새 gameplay 기능, 새 레벨, Unity 씬 변경, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가가 없다.
- `docs/current-state.md`가 이번 계획 상태와 다음 단계를 반영한다.
- 필요한 경우 `docs/decisions.md`가 오래 유지할 결정을 기록한다.
- 이 ExecPlan의 진행 상황, 결정 기록, 예상 밖 발견, 회고가 갱신된다.
- 최종 커밋 후 `git status --short`가 clean이다.

현재 검증 결과:

- ExecPlan 생성 전 `git status --short`: 출력 없음. 작업트리 clean.
- 구현 시작 전 `git status --short`: `docs/current-state.md` 수정, `exec-plans/012-m5-portfolio-retrospective-package.md` 추가가 확인됐다.
- `README.md`를 Codex 기반 Unity 워크플로우 실험 사례 중심으로 개선했다.
- README에 Unity 6000.4.1f1, `Assets/Scenes/SampleScene.unity`, Play Mode 시작, `WASD`/방향키 이동, `Retry Level` 버튼, 기준 Clear 경로를 포함했다.
- README에 M1-M5 결과 요약과 주요 문서 구조를 포함했다.
- `docs/harness-retrospective.md`를 추가했다.
- 회고 문서에 실험 판정, M1-M4 요약, 잘 작동한 것, 마찰, Codex가 실수하기 쉬운 지점, 사람이 맡아야 했던 Unity 검증, 다음 프로젝트에 가져갈 규칙, 버리거나 완화할 규칙, 보류할 도구를 포함했다.
- `docs/public-repo-checklist.md`를 추가했다.
- public repo 점검 문서에 민감 정보, 로컬 전용 정보, Unity 생성물과 패키지, M5 범위 점검을 포함했다.
- `docs/current-state.md`에 M5 완료와 다음 단계를 반영했다.
- `docs/decisions.md`에 M5 공개 패키징 포지셔닝과 플레이 영상/GIF 제외 결정을 기록했다.
- `Test-Path`로 `docs/harness-retrospective.md`, `docs/public-repo-checklist.md`, `docs/verification/play-mode-checklist.md`, `docs/harness-reuse-guide.md` 존재를 확인했다.
- `rg`로 README의 실행 방법, 조작 방법, 마일스톤 결과, 문서 구조, 신규 문서 링크가 있는지 확인했다.
- `rg`로 하네스 회고와 public repo 점검 문서의 필수 섹션이 있는지 확인했다.
- 민감 정보 키워드 검색 결과는 민감 정보를 기록하지 말라는 규칙 문장만 발견했고, 비밀키/토큰/개인 환경 절대 경로는 발견하지 못했다.
- `git diff --check`는 공백 오류 없이 통과했다. Git은 일부 기존 Markdown 파일이 다음 Git 처리 때 CRLF로 바뀔 수 있다는 줄바꿈 경고만 출력했다.
- `git status --short` 기준 변경 파일은 README와 docs/exec-plans 문서 파일뿐이다.
- 구현 완료 커밋 생성 후 `git status --short`: 출력 없음. 작업트리 clean.

## 자체 리뷰

- 공유된 이해 검증 내용과 ExecPlan 내용이 일치한다.
- 목표는 실험 사례 중심 공개 패키징으로 제한되어 있다.
- 포함 범위는 README 개선, 실행/조작 방법 정리, M1-M4 결과 요약, 하네스 회고, public repo 점검, 다음 프로젝트 규칙 정리, 상태/결정 문서 갱신으로 제한되어 있다.
- 제외 범위는 플레이 영상/GIF 준비 항목, 새 gameplay 기능, 새 레벨, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent, 외부 패키지 추가로 명시되어 있다.
- 구현 승인 전 상태가 `구현 승인 대기`로 표시되어 있다.
- 구현 승인 전에는 README 개선과 새 문서 작성을 시작하지 않도록 계획에 명시했다.
- 완료 기준은 문서 존재, README 내용, 회고 내용, public repo 점검 내용, 금지 범위 미포함, `git status` 확인으로 관찰 가능하다.

## 결정 기록

- 결정: M5의 포지셔닝은 게임 포트폴리오보다 Codex 기반 Unity 워크플로우 실험 사례를 중심으로 한다.
  근거: M5의 목표는 새 gameplay 기능 추가가 아니라 Delivery Bot Zero와 Codex 기반 Unity 개발 워크플로우 실험 결과를 외부에 보여줄 수 있게 정리하는 것이다.
  날짜: 2026-05-19

- 결정: 플레이 영상 또는 GIF 준비 항목은 M5 완료 범위에서 제외한다.
  근거: 영상과 GIF는 수동 캡처, 편집, 파일 용량, README 임베드 방식까지 엮이는 별도 공개 준비 작업에 가깝다. M5는 문서 중심 공개 패키징으로 유지한다.
  날짜: 2026-05-19

## 예상 밖 발견

- `README.md`가 M5 전에는 내부 상태 메모에 가까웠다. M5에서 외부 독자가 먼저 읽는 실험 사례 소개 문서로 재구성했다.

## 회고

M5 공개 포트폴리오와 회고 패키지를 완료했다.

- 완료한 것: `README.md`를 공개용 실험 사례 소개로 개선했고, `docs/harness-retrospective.md`와 `docs/public-repo-checklist.md`를 추가했다. `docs/current-state.md`와 `docs/decisions.md`도 M5 완료 상태와 장기 결정을 반영하도록 갱신했다.
- 완료하지 못한 것: 없음. 플레이 영상 또는 GIF, 새 gameplay 기능, 새 레벨, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가는 의도적으로 하지 않았다.
- 배운 것: M5의 가치는 게임을 더 크게 보이게 만드는 데 있지 않고, 작은 Unity 실험이 어떤 절차로 진행되고 검증됐는지 외부 독자가 따라 읽을 수 있게 만드는 데 있다.
- 다음에 해야 할 것: 필요하면 별도 계획으로 두 번째 작은 Unity 프로젝트에 하네스를 옮겨 보거나, 실제 GitHub 공개 전 라이선스와 선택적 플레이 GIF 여부를 검토한다.
- 다음 계획을 시작할 준비가 되었는지 여부: 예. 다만 이 실험의 M0-M5 범위는 완료되었다.
