# Public Repo 점검

## 목적

이 문서는 `Codex Harness v0 — Delivery Bot Zero`를 공개 저장소 기준으로 정리할 때 확인한 항목을 기록한다.

점검 기준은 민감 정보 노출 방지, 공개에 불필요한 로컬 생성물 제외, M5 범위 준수다. 이 문서는 보안 감사가 아니라 공개 전 저장소 위생 점검 기록이다.

## 점검 결과 요약

상태: 통과.

M5 문서 패키징 과정에서 새 gameplay 기능, 새 레벨, 아키텍처 리팩터링, hooks/MCP/custom skill/subagent/외부 패키지 추가는 하지 않았다. 공개 저장소에 포함되면 안 되는 비밀키나 개인 민감 정보도 발견하지 못했다.

## 민감 정보

상태: 통과.

점검 항목:

- 개인의 경력, 가족, 재정, 고용주 관련 민감 정보를 저장소 문서에 기록하지 않는다.
- 비밀키, 토큰, 인증 정보, 계정 비밀번호를 저장소 파일에 기록하지 않는다.
- 공개 README와 회고 문서는 프로젝트 실험 결과만 다룬다.

확인 결과:

- M5에서 추가한 문서는 프로젝트 하네스, Unity 실행 방법, 공개 점검 결과만 포함한다.
- 개인의 경력, 가족, 재정, 고용주 관련 민감 정보는 추가하지 않았다.
- 비밀키, 토큰, 인증 정보는 추가하지 않았다.

## 로컬 전용 정보

상태: 통과.

점검 항목:

- 공개 문서에는 특정 개인 환경에만 의미 있는 절대 경로를 넣지 않는다.
- Unity `Library/`, `Temp/`, `Logs/`, `UserSettings/` 같은 로컬 생성물은 추적하지 않는다.
- `.worktree/`는 로컬 worktree 용도로만 사용하고 공개 산출물로 취급하지 않는다.

확인 결과:

- README와 신규 문서는 저장소 상대 경로를 기준으로 작성했다.
- `.gitignore`가 `.worktree/`, `Library/`, `Temp/`, `Logs/`, `UserSettings/`, Visual Studio/Unity 자동 생성 파일을 제외한다.
- `git ls-files` 기준으로 `Library/`, `Temp/`, `Logs/`, `UserSettings/`, `.worktree/` 아래 파일은 추적되지 않는다.

## Unity 생성물과 패키지

상태: 통과.

점검 항목:

- Unity 프로젝트 재현에 필요한 `Assets/`, `Packages/`, `ProjectSettings/`는 유지한다.
- 자동 생성 `*.csproj`, `*.sln`, `Library/`, `Temp/`, `Logs/`는 공개 대상에서 제외한다.
- M5에서 새 외부 패키지를 추가하지 않는다.

확인 결과:

- `ProjectSettings/ProjectVersion.txt` 기준 Unity 버전은 6000.4.1f1이다.
- `Packages/manifest.json`은 기존 Unity 패키지 상태를 유지한다.
- M5 작업으로 `Packages/manifest.json` 또는 `Packages/packages-lock.json`를 수정하지 않았다.
- `*.csproj`와 `*.sln`은 `.gitignore`에 제외 규칙이 있고 현재 추적 파일 목록에 없다.

## M5 범위 점검

상태: 통과.

포함한 것:

- `README.md` 공개용 개선
- 실행/조작 방법 정리
- M1-M4 결과 요약
- 하네스 회고 작성
- public repo 기준 민감 정보 점검
- 다음 프로젝트에 가져갈 규칙과 버릴 규칙 정리

제외한 것:

- 플레이 영상 또는 GIF 준비 항목
- 새 gameplay 기능
- 새 레벨
- 아키텍처 리팩터링
- hooks/MCP/custom skill/subagent 추가
- 외부 패키지 추가

## 후속 필요

현재 후속 필수 항목은 없다.

나중에 실제 GitHub 공개 전에는 원격 저장소 설정, 공개 라이선스 필요 여부, README의 스크린샷 또는 GIF 추가 여부를 별도 결정으로 검토할 수 있다. 이 항목들은 M5 완료 조건에는 포함하지 않는다.
