# Decisions

## 2026-05-18

### Use prefix-based experiment naming

Decision:
Use `codex-harness-dbz-v0` as both the GitHub repo name and Unity project folder name.

Rationale:
The prefix makes experiment type visible first and keeps multiple experiment repos easy to scan.

### Start with minimal Codex harness

Decision:
Use README.md, AGENTS.md, PLANS.md, docs/current-state.md, docs/decisions.md, and one active/canonical Bootstrap ExecPlan.

Rationale:
M0 should stay small. MCP, custom skills, hooks, and subagents are deferred until there is real workflow friction.

### Route state and decision documents through AGENTS and PLANS

Decision:
Treat `docs/current-state.md` and `docs/decisions.md` as workflow documents that must be connected through read and update rules in `AGENTS.md` and `PLANS.md`.

Rationale:
State and decision documents are only reliable if Codex knows when to read them and when to update them.

### Separate plan-local decisions from durable project decisions

Decision:
Use each ExecPlan `Decision Log` or `결정 기록` for choices made inside that specific plan, and use `docs/decisions.md` for decisions that should continue beyond a single plan.

Rationale:
This keeps temporary execution context separate from long-term project rules.

### Use 000-bootstrap as the canonical M0 verification plan

Decision:
Use `exec-plans/000-bootstrap.md` as the canonical M0 Bootstrap verification ExecPlan.

Rationale:
M0 must have one stable reference plan for checking Unity project creation, GitHub connection, and minimum Codex harness readiness before any M1 first playable loop work starts.
