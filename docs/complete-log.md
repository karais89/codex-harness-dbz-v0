# 마일 스톤 작업 체크 리스트

## M0-1. 프로젝트 생성

[x] Unity Hub에서 프로젝트 생성
[x] 프로젝트 이름은 codex-harness-dbz-v0
[x] Unity Editor에서 정상으로 열린다

## M0-2. Git 초기화

[x] git init 완료
[x] Unity용 .gitignore 추가
[x] 첫 커밋 생성
[x] git status clean

## M0-3. GitHub repo 연결

[x] GitHub repo 생성 완료 - https://github.com/karais89/codex-harness-dbz-v0
[x] origin remote 연결 완료
[x] main 브랜치 push 완료
[x] GitHub 웹에서 repo 확인 가능

## M0-4. README.md 작성

[x] README.md가 있다
[x] 프로젝트 목적이 설명되어 있다
[x] 현재 단계가 M0로 표시되어 있다
[x] 아직 하지 않을 것이 명시되어 있다

## M0-5. AGENTS.md 작성

[x] AGENTS.md가 있다
[x] Codex read order가 있다
[x] 금지사항이 있다
[x] Done 기준이 있다
[x] ExecPlan 사용 규칙이 한국어로 작성되어 있다

## M0-6. PLANS.md 작성

[x] PLANS.md가 있다
[x] ExecPlan의 목적이 설명되어 있다
[x] 필수 섹션이 있다
[x] 자기완결성 원칙이 있다
[x] ExecPlan 저장 위치와 파일 이름 규칙이 명시되어 있다

## M0-7. 최소 상태 문서와 갱신 규칙 추가

[x] docs/current-state.md가 있다
[x] docs/current-state.md에 Current Stage, Active Plan, Next Step이 있다
[x] docs/decisions.md가 있다
[x] docs/decisions.md에 초기 장기 결정이 기록되어 있다
[x] AGENTS.md에 docs/current-state.md와 docs/decisions.md를 읽는 규칙이 있다
[x] AGENTS.md에 두 파일을 언제 업데이트해야 하는지 규칙이 있다
[x] PLANS.md에 ExecPlan 결정 기록과 docs/decisions.md의 관계가 설명되어 있다

## M0-8. Codex로 exec-plans/000-bootstrap.md 생성 및 기존 ExecPlan 정리 기준 확인

[x] exec-plans/000-bootstrap.md가 존재한다.
[x] PLANS.md의 필수 섹션을 따른다.
[x] M0가 bootstrap 검증 단계임을 설명한다.
[x] M1과 M0의 범위를 분리한다.
[x] 기존 exec-plans 파일들을 삭제하지 않았다.
[x] 기존 exec-plans 파일이 있다면 마지막 보고에 목록화했다.
[x] docs/current-state.md의 Active Plan을 exec-plans/000-bootstrap.md로 맞추는 조건을 포함한다.
[x] M1 시작 조건이 명확하다.
[x] git / Unity / 문서 존재 여부를 검증하는 방법이 구체적이다.

## M0-9. M0 전체가 M1을 시작할 수 있는 상태인지 검증만 하는 단계