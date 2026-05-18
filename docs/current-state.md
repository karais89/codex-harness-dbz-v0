# Current State

## Project phase

The repository is in M0: Unity project creation, GitHub upload, and minimal Codex harness setup.

The project intentionally does not include gameplay implementation, Unity MCP, custom skills, hooks, subagents, or external packages at this stage.

## Workflow conventions

- Non-trivial work uses an ExecPlan under `exec-plans/`.
- ExecPlan files use the `NNN-short-kebab-title.md` naming convention.
- Local Git worktrees for workflow tests are stored under the repository-root `.worktree/` directory.
- `.worktree/` is ignored by Git and is treated as local working storage, not project content.

## Git worktree + ExecPlan smoke test

Active plan: `exec-plans/002-git-worktree-execplan-smoke-test.md`

The smoke test checked that a workflow-only change can:

- Create or update an ExecPlan before implementation.
- Add the `.worktree/` ignore convention.
- Create a test worktree at `.worktree/execplan-smoke`.
- Use the `test/execplan-smoke` branch when no path or branch conflict exists.
- Record validation with `git worktree list` and `git status --short` in both the root worktree and the test worktree.

Result on 2026-05-18:

- `git worktree add .worktree/execplan-smoke -b test/execplan-smoke` succeeded.
- `git worktree list` showed the root worktree on `main` and `.worktree/execplan-smoke` on `test/execplan-smoke`.
- Root `git status --short` before commit showed only `.gitignore`, `docs/current-state.md`, and `exec-plans/002-git-worktree-execplan-smoke-test.md`.
- `.worktree/execplan-smoke` `git status --short` was empty.
- After commit, root `git status --short` was empty.

Status: completed.
