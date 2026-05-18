# M0 Bootstrap Verification

## Purpose / Big Picture

This ExecPlan verifies M0 for `codex-harness-dbz-v0`, the `Codex Harness v0 - Delivery Bot Zero` repository. The experiment uses a small Unity 2D puzzle game idea to validate a minimal Codex-led Unity development workflow.

M0 is the bootstrap stage. Its purpose is to confirm that the Unity project exists, the repository is connected to GitHub, and the minimum Codex harness documents are present and usable. The minimum harness consists of `README.md`, `AGENTS.md`, `PLANS.md`, `docs/current-state.md`, `docs/decisions.md`, and this canonical bootstrap ExecPlan at `exec-plans/000-bootstrap.md`.

This is not a gameplay implementation plan. It must not add or change Unity scenes, C# scripts, gameplay logic, packages, MCP servers, custom skills, hooks, subagents, architecture, or a game specification.

M1 is a separate future stage for the first playable loop. M1 may start only after this M0 bootstrap verification shows that the repository and workflow are ready.

## Progress

- [x] `README.md` exists and describes the repository goal, current M0 stage, and excluded items.
- [x] `AGENTS.md` exists and defines Codex working rules, read order, document update rules, and completion criteria.
- [x] `PLANS.md` exists and defines ExecPlan rules, required sections, living document expectations, and validation rules.
- [x] `docs/current-state.md` exists and includes `Current Stage`, `Active Plan`, and `Next Step` sections.
- [x] `docs/decisions.md` exists and records durable project decisions.
- [x] The `exec-plans/` folder exists.
- [x] Existing ExecPlans were found and left in place: `001-execplan-storage-convention.md`, `002-git-worktree-execplan-smoke-test.md`, and `003-state-doc-routing-rules.md`.
- [x] `git remote -v` was checked on 2026-05-18 and showed GitHub `origin` at `https://github.com/karais89/codex-harness-dbz-v0.git`.
- [x] `git status --short` was checked before this plan was authored and showed a pre-existing modification to `docs/complete-log.md`.
- [x] `exec-plans/000-bootstrap.md` has been created as the canonical M0 bootstrap verification ExecPlan.
- [x] `docs/current-state.md` has been updated so `Active Plan` points to `exec-plans/000-bootstrap.md`.
- [ ] Unity project opens normally in Unity Editor without project-load or compile errors.
- [ ] `git status` is clean, or any remaining changes are explicitly recorded before M1 starts.
- [ ] A final M0 readiness review confirms every M1 start condition in this plan.
- [ ] Outcomes and retrospective are updated after M0 validation is executed.

This progress section intentionally does not declare M0 complete.

## Surprises & Discoveries

- PowerShell commands initially failed inside the default Windows sandbox with `CreateProcessAsUserW failed: 5`; read and inspection commands were run with approved escalated execution.
- `docs/complete-log.md` was already modified before this ExecPlan was authored. This plan does not edit that file, revert it, or treat it as part of the bootstrap plan unless a later validation step records it as a remaining change.
- Older ExecPlans exist in `exec-plans/`. They are historical workflow plans and must not be deleted, renamed, or moved as part of this M0 bootstrap verification.

## Decision Log

- Decision: Use `exec-plans/000-bootstrap.md` as the canonical M0 bootstrap verification ExecPlan.
- Rationale: The user requested this exact path and it gives M0 a stable reference point before any M1 work starts.
- Date: 2026-05-18

- Decision: Keep existing ExecPlans in place and do not rename or delete them.
- Rationale: Existing plans may be useful history. If they cause confusion, cleanup should be recommended separately and performed only with explicit approval.
- Date: 2026-05-18

- Decision: Limit this plan to bootstrap verification, not gameplay or Unity content changes.
- Rationale: M0 is about Unity project creation, GitHub connection, and minimum Codex harness readiness. M1 is the later first playable loop stage.
- Date: 2026-05-18

- Decision: `docs/current-state.md` should point its `Active Plan` to `exec-plans/000-bootstrap.md` while this M0 verification is active.
- Rationale: A new Codex session or person developer should be able to find the active plan from the state document without relying on prior chat context.
- Date: 2026-05-18

Durable decisions that should continue beyond this plan must also be recorded in `docs/decisions.md`. This plan's `Decision Log` records plan-local choices and rationale; `docs/decisions.md` records project rules that should survive after this plan closes.

## Outcomes & Retrospective

Current outcome: this plan establishes the M0 bootstrap verification target and required checks. It does not yet prove M0 complete because Unity Editor validation and final M1 readiness review are still pending.

Retrospective to complete after validation:

- Completed:
- Not completed:
- Learned:
- Next step:
- Ready to start M1:

## Context and Orientation

Repository: `codex-harness-dbz-v0`.

Experiment name: `Codex Harness v0 - Delivery Bot Zero`.

Current stage: M0 bootstrap.

M0 checks whether the repository is ready for Codex-guided Unity work. It verifies the presence and roles of the core workflow documents, confirms GitHub connection, confirms the Unity project opens, and records whether the worktree is clean or has documented remaining changes.

Key files:

- `README.md`: describes the repository goal, current M0 stage, and items intentionally not included yet.
- `AGENTS.md`: defines Codex rules, required read order, document update requirements, and completion criteria.
- `PLANS.md`: defines how ExecPlans are written, maintained, validated, and completed.
- `docs/current-state.md`: the current state document. It should show the current stage, the active plan, and the next step. During this verification, its `Active Plan` should point to `exec-plans/000-bootstrap.md`.
- `docs/decisions.md`: the durable decision log. It records project decisions that should continue beyond any single ExecPlan.
- `exec-plans/000-bootstrap.md`: this plan, the canonical M0 bootstrap verification plan.

Existing ExecPlans:

- `exec-plans/001-execplan-storage-convention.md`
- `exec-plans/002-git-worktree-execplan-smoke-test.md`
- `exec-plans/003-state-doc-routing-rules.md`

Those existing ExecPlans are not the canonical Bootstrap ExecPlan for this task. They should not be deleted, renamed, or moved without explicit approval.

## Plan of Work

1. Confirm that the required baseline documents exist and describe the expected M0 harness roles.
2. Confirm that `exec-plans/000-bootstrap.md` exists and follows `PLANS.md`, including the required living document sections.
3. Confirm that `docs/current-state.md` identifies M0 as the current stage and points `Active Plan` to `exec-plans/000-bootstrap.md`.
4. Confirm that `docs/decisions.md` contains durable project decisions and that any decision meant to survive this plan is also recorded there.
5. Confirm that existing ExecPlans are left in place and that `exec-plans/000-bootstrap.md` is the canonical Bootstrap plan.
6. Open the Unity project in Unity Editor and verify that it loads normally without project-load or compile errors.
7. Run Git checks to verify GitHub `origin` and worktree status.
8. Review the M1 start conditions in this plan and mark them complete only when directly verified.
9. Update `Progress`, `Surprises & Discoveries`, `Decision Log`, and `Outcomes & Retrospective` as validation is executed.
10. Update `docs/current-state.md` if the current stage, active plan, next step, or known limitations change.

## Concrete Steps

Run these from the repository root in Windows PowerShell:

```powershell
Get-ChildItem
Get-ChildItem docs
Get-ChildItem exec-plans
git remote -v
git status
```

Check required files:

```powershell
Test-Path README.md
Test-Path AGENTS.md
Test-Path PLANS.md
Test-Path docs/current-state.md
Test-Path docs/decisions.md
Test-Path exec-plans/000-bootstrap.md
```

Check key text in state and decision documents:

```powershell
Select-String -Path docs/current-state.md -Pattern "Current Stage"
Select-String -Path docs/current-state.md -Pattern "Active Plan"
Select-String -Path docs/current-state.md -Pattern "Next Step"
Select-String -Path docs/current-state.md -Pattern "exec-plans/000-bootstrap.md"
Select-String -Path docs/decisions.md -Pattern "Decision"
```

Manual Unity validation:

1. Open Unity Hub.
2. Open the project folder at the repository root.
3. Confirm the project loads.
4. Confirm the Unity Console does not show project-load or compile errors.
5. Do not create or modify scenes, scripts, packages, or gameplay while performing this validation.

If Unity validation produces generated metadata or other file changes, record them in `Progress` and `Surprises & Discoveries`, then decide whether they are expected before considering M1.

## Validation and Acceptance

M0 bootstrap verification is accepted only when all of these are true:

- Unity project opens normally in Unity Editor.
- `README.md` exists and explains the repository purpose, M0 stage, and excluded work.
- `AGENTS.md` exists and explains Codex working rules.
- `PLANS.md` exists and explains ExecPlan rules.
- `docs/current-state.md` exists and includes `Current Stage`, `Active Plan`, and `Next Step`.
- `docs/current-state.md` has `Active Plan` pointing to `exec-plans/000-bootstrap.md` while this plan is active.
- `docs/decisions.md` exists and records durable project decisions.
- This file exists at exactly `exec-plans/000-bootstrap.md`.
- No other Bootstrap ExecPlan is created in another location.
- Existing ExecPlans under `exec-plans/` are not deleted, renamed, or moved.
- `git remote -v` shows a GitHub `origin`.
- `git status` is clean, or all remaining changes are explicitly recorded and understood.
- No gameplay implementation, Unity scene modification, C# script addition, package addition, MCP, custom skill, hook, subagent, architecture expansion, game specification, or M1 implementation plan has been added during M0 verification.

M1 may start only when all of these conditions are met:

- Unity project opens.
- GitHub remote is connected.
- `README.md`, `AGENTS.md`, and `PLANS.md` exist.
- `docs/current-state.md` and `docs/decisions.md` exist.
- `exec-plans/000-bootstrap.md` exists and follows `PLANS.md`.
- `docs/current-state.md` has `Active Plan` pointing to `exec-plans/000-bootstrap.md` while M0 verification is active.
- `git status` is clean, or remaining changes are clearly recorded.
- It is clear that M0 did not implement gameplay.

## Idempotence and Recovery

This plan is idempotent. Re-running it should update `exec-plans/000-bootstrap.md` in place rather than creating a second Bootstrap plan.

If `exec-plans/` does not exist, create it and then create this file at `exec-plans/000-bootstrap.md`.

If other ExecPlan files exist, do not delete, rename, or move them. If they look duplicated, obsolete, or confusing, mention them in notes or a final recommended cleanup section only.

If `docs/current-state.md` does not point to this plan while M0 verification is active, update its `Active Plan` field to `exec-plans/000-bootstrap.md`.

If `git remote -v` does not show GitHub `origin`, record the failure and do not mark M0 ready for M1.

If `git status` is not clean, identify whether changes are from this plan, pre-existing work, Unity-generated files, or unrelated user work. Do not revert unrelated changes without explicit approval.

If Unity fails to open or reports compile errors, record the exact observed failure in `Surprises & Discoveries`, leave M1 start conditions incomplete, and do not implement gameplay as part of the fix unless a later ExecPlan explicitly authorizes it.

## Artifacts and Notes

Created or updated by this plan:

- `exec-plans/000-bootstrap.md`
- `docs/current-state.md`
- `docs/decisions.md`

Observed existing ExecPlans:

- `exec-plans/001-execplan-storage-convention.md`
- `exec-plans/002-git-worktree-execplan-smoke-test.md`
- `exec-plans/003-state-doc-routing-rules.md`

Recommended cleanup, if later approved:

- Review whether older completed ExecPlans need clearer archive notes or cross-references after `exec-plans/000-bootstrap.md` becomes the canonical M0 reference. Do not delete or move them without explicit approval.

## Interfaces and Dependencies

Required tools and interfaces:

- Windows PowerShell for file and Git checks.
- Git CLI for `git remote -v` and `git status`.
- Unity Hub and Unity Editor for manual project-open validation.
- GitHub remote named `origin`.

No new runtime interfaces or dependencies are introduced by this plan.

Explicitly not added by this plan:

- Gameplay implementation
- Unity scene changes
- C# scripts
- Unity packages
- MCP servers
- Custom skills
- Hooks
- Subagents
- Architecture expansion
- Game specification
- M1 implementation plan
