# Git Training for Interns - 2 Day Course

## Course Overview
This 2-day course covers Git fundamentals and practical scenarios used in professional development environments.

**Duration:** 2 days
- **Day 1:** 2-hour theoretical session (Fundamentals)
- **Day 2:** Practical exercises and assessment

---

## Day 1: Git Fundamentals (2 Hours)

### Session 1: Introduction to Git (30 minutes)

#### What is Git?
- Distributed Version Control System (DVCS)
- Tracks changes in source code
- Enables team collaboration
- Maintains complete project history

#### Key Concepts
- **Repository (Repo):** Project folder tracked by Git
- **Commit:** Snapshot of your code at a specific point
- **Branch:** Independent line of development
- **Remote:** Server hosting your repository (e.g., Azure DevOps, GitHub)

#### Git Configuration
```bash
# Set your identity
git config --global user.name "Your Name"
git config --global user.email "your.email@company.com"

# View all configurations
git config --list

# Set default branch name
git config --global init.defaultBranch main
```

---

### Session 2: Basic Git Operations (45 minutes)

#### Creating and Cloning Repositories

**Initialize a new repository:**
```bash
# Create new project folder
mkdir my-project
cd my-project

# Initialize Git
git init
```

**Clone existing repository (most common in professional settings):**
```bash
# Clone from Azure DevOps
git clone https://dev.azure.com/yourorg/yourproject/_git/asset-universe

# Clone to specific folder
git clone https://dev.azure.com/yourorg/yourproject/_git/asset-universe my-folder
```

#### Understanding Git States

1. **Working Directory** - Your local files
2. **Staging Area (Index)** - Files ready to commit
3. **Repository** - Committed snapshots

```bash
# Check status of files
git status

# View short status
git status -s
```

#### Adding and Committing Changes

```bash
# Add specific file to staging
git add filename.txt

# Add all changed files
git add .

# Add all files with specific extension
git add *.cs

# Add files in specific directory
git add src/

# Commit with message
git commit -m "Add new feature for asset calculation"

# Add and commit in one command
git commit -am "Fix bug in pricing module"
```

**Best Practices for Commit Messages:**
- Use present tense: "Add feature" not "Added feature"
- Be descriptive but concise
- Reference ticket numbers: "Fix issue #123: Correct asset valuation"

#### Viewing History

```bash
# View commit history
git log

# View compact history
git log --oneline

# View last 5 commits
git log -5

# View history with graph
git log --oneline --graph --all

# View changes in commits
git log -p
```

---

### Session 3: Working with Branches (45 minutes)

#### Understanding Branches

Branches allow you to work on features independently without affecting the main codebase.

**Common branch naming conventions:**
- `master`/`main` - Production-ready code
- `develop` - Integration branch
- `feature/feature-name` - New features
- `hotfix/issue-description` - Urgent fixes
- `bugfix/bug-description` - Bug fixes

#### Branch Operations

```bash
# View all branches
git branch

# View all branches including remote
git branch -a

# Create new branch
git branch feature/add-user-authentication

# Switch to branch
git checkout feature/add-user-authentication

# Create and switch to branch (shortcut)
git checkout -b feature/calculate-asset-value

# Switch branches (modern command)
git switch feature/calculate-asset-value

# Create and switch (modern command)
git switch -c feature/new-dashboard

# Delete branch
git branch -d feature/completed-feature

# Force delete branch (if not merged)
git branch -D feature/abandoned-feature
```

#### Real-World Scenario: Creating a Feature Branch

```bash
# 1. Start from master branch
git checkout master

# 2. Pull latest changes
git pull origin master

# 3. Create feature branch
git checkout -b feature/asset-export

# 4. Make changes to files
# ... edit files ...

# 5. Stage and commit
git add .
git commit -m "Add CSV export functionality for assets"

# 6. Continue working with multiple commits
git commit -am "Add unit tests for export feature"
git commit -am "Update documentation for export API"
```

#### Merging Branches

```bash
# Switch to target branch (where you want to merge)
git checkout master

# Merge feature branch
git merge feature/asset-export

# If conflicts occur, resolve them, then:
git add .
git commit -m "Merge feature/asset-export into master"
```

---

### Session 4: Working with Remote Repositories (30 minutes)

#### Remote Operations

```bash
# View remote repositories
git remote -v

# Add remote repository
git remote add origin https://dev.azure.com/yourorg/project/_git/repo

# Fetch changes from remote (doesn't merge)
git fetch origin

# Pull changes from remote (fetch + merge)
git pull origin master

# Push changes to remote
git push origin feature/your-branch

# Push and set upstream
git push -u origin feature/your-branch

# After setting upstream, just use:
git push
```

#### Real-World Scenario: Daily Work Workflow

```bash
# Morning: Start your workday
git checkout master
git pull origin master
git checkout -b feature/update-pricing-model

# Make changes throughout the day
git add src/PricingService.cs
git commit -m "Update pricing calculation logic"

git add tests/PricingServiceTests.cs
git commit -m "Add tests for new pricing logic"

# End of day: Push your work
git push -u origin feature/update-pricing-model

# Next day: Get latest changes before continuing
git pull origin feature/update-pricing-model
```

#### Handling Merge Conflicts

```bash
# When pulling or merging, you might see:
# CONFLICT (content): Merge conflict in filename.cs

# 1. Open the file and look for conflict markers:
# <<<<<<< HEAD
# Your changes
# =======
# Incoming changes
# >>>>>>> branch-name

# 2. Edit the file to resolve conflicts

# 3. Stage the resolved file
git add filename.cs

# 4. Complete the merge
git commit -m "Resolve merge conflict in pricing module"
```

---

## Day 2: Practical Exercises and Exam (4 Hours)

### Part 1: Practical Exercises (2.5 hours)

#### Exercise 1: Repository Setup and Basic Operations (30 minutes)

**Task:** Set up a new project and make initial commits

```bash
# 1. Create and initialize repository
mkdir student-project
cd student-project
git init

# 2. Create README file
echo "# My Student Project" > README.md

# 3. Stage and commit
git add README.md
git commit -m "Initial commit: Add README"

# 4. Create source files
mkdir src
echo "console.log('Hello Git');" > src/app.js

# 5. Stage and commit
git add src/app.js
git commit -m "Add main application file"

# 6. View history
git log --oneline
```

**Expected Output:**
- Repository initialized
- At least 2 commits visible in log
- Clean working directory (`git status` shows nothing to commit)

---

#### Exercise 2: Branching and Merging (45 minutes)

**Scenario:** You need to add a new feature while keeping master stable

```bash
# 1. Create feature branch from master
git checkout master
git checkout -b feature/user-login

# 2. Create login file
mkdir src/auth
echo "function login(user, pass) { /* TODO */ }" > src/auth/login.js

# 3. Commit changes
git add src/auth/login.js
git commit -m "Add login function skeleton"

# 4. Continue development
echo "function validateUser(user) { /* TODO */ }" >> src/auth/login.js
git commit -am "Add user validation function"

# 5. Switch back to master and create another feature
git checkout master
git checkout -b feature/user-registration

# 6. Create registration file
echo "function register(user) { /* TODO */ }" > src/auth/register.js
git add src/auth/register.js
git commit -m "Add registration function"

# 7. Merge first feature to master
git checkout master
git merge feature/user-login

# 8. Merge second feature to master
git merge feature/user-registration

# 9. View branch graph
git log --oneline --graph --all

# 10. Clean up merged branches
git branch -d feature/user-login
git branch -d feature/user-registration
```

---

#### Exercise 3: Simulating Team Collaboration (45 minutes)

**Scenario:** Multiple developers working on the same project

**Setup (Instructor creates shared repository):**
```bash
# Instructor: Create bare repository (simulates Azure DevOps)
mkdir shared-repo.git
cd shared-repo.git
git init --bare
```

**Student Tasks:**

```bash
# 1. Clone the repository
git clone /path/to/shared-repo.git my-workspace
cd my-workspace

# 2. Create initial structure
mkdir src
echo "// Main application" > src/main.cs
git add .
git commit -m "Initial project structure"
git push origin master

# 3. Create feature branch
git checkout -b feature/add-asset-model

# 4. Add new file
echo "public class Asset { public int Id; }" > src/Asset.cs
git add src/Asset.cs
git commit -m "Add Asset model class"

# 5. Push feature branch
git push -u origin feature/add-asset-model

# 6. Simulate another developer's changes to master
# (Instructor or partner makes changes to master)

# 7. Update your feature branch with latest master
git checkout master
git pull origin master
git checkout feature/add-asset-model
git merge master

# 8. Push updated feature branch
git push
```

---

#### Exercise 4: Fixing Mistakes (30 minutes)

**Common scenarios and solutions:**

**Scenario A: Undo uncommitted changes**
```bash
# Create a file and modify it
echo "temp content" > temp.txt
git add temp.txt

# Unstage the file
git reset temp.txt

# Discard changes in working directory
git checkout -- temp.txt
# OR (modern command)
git restore temp.txt
```

**Scenario B: Amend last commit**
```bash
# Made a commit but forgot to add a file
git add forgotten-file.txt
git commit --amend --no-edit

# Change last commit message
git commit --amend -m "New commit message"
```

**Scenario C: Undo last commit (keep changes)**
```bash
# Undo commit but keep changes staged
git reset --soft HEAD~1

# Undo commit and unstage changes
git reset HEAD~1

# Undo commit and discard changes (DANGEROUS!)
git reset --hard HEAD~1
```

**Scenario D: Recover deleted branch**
```bash
# Find the commit hash of deleted branch
git reflog

# Recreate branch at that commit
git checkout -b recovered-branch <commit-hash>
```

---

### Part 2: Real-World Scenario Exercise (30 minutes)

**Scenario: Bug Hotfix in Production**

You discover a critical bug in production that needs immediate fixing.

```bash
# 1. Start from master (production code)
git checkout master
git pull origin master

# 2. Create hotfix branch
git checkout -b hotfix/fix-asset-calculation-error

# 3. Fix the bug
# Edit src/AssetCalculator.cs

# 4. Commit the fix
git add src/AssetCalculator.cs
git commit -m "Hotfix: Correct asset valuation formula"

# 5. Test the fix
# Run tests...

# 6. Add test to prevent regression
# Edit tests/AssetCalculatorTests.cs
git add tests/AssetCalculatorTests.cs
git commit -m "Add test for asset valuation edge case"

# 7. Merge hotfix to master
git checkout master
git merge hotfix/fix-asset-calculation-error

# 8. Push to production
git push origin master

# 9. Also merge to develop to keep it updated
git checkout develop
git pull origin develop
git merge hotfix/fix-asset-calculation-error
git push origin develop

# 10. Tag the release
git tag -a v1.2.1 -m "Hotfix: Asset calculation error"
git push origin v1.2.1

# 11. Delete hotfix branch
git branch -d hotfix/fix-asset-calculation-error
```

---

### Part 3: Exam (1 hour)

#### Theoretical Questions (20 points)

1. **What is the difference between `git fetch` and `git pull`?** (4 points)

2. **Explain the three states of Git (working directory, staging area, repository)** (4 points)

3. **What is a merge conflict and why does it occur?** (4 points)

4. **What's the difference between `git merge` and `git rebase`?** (4 points)

5. **Why should you never force push (`git push -f`) to shared branches?** (4 points)

---

#### Practical Exam (80 points)

**Scenario:** You're joining a team working on the asset-universe project.

**Task 1: Setup (10 points)**
```bash
# Clone the repository
# Configure your Git identity
# View the current branches
# Check the status
```

**Task 2: Feature Development (30 points)**
```bash
# Create a feature branch: feature/add-asset-filters
# Create a new file: src/AssetFilters.cs with a simple class
# Commit with proper message
# Create another file: tests/AssetFiltersTests.cs
# Commit with proper message
# Push the feature branch to remote
```

**Task 3: Collaboration (25 points)**
```bash
# Switch to master and pull latest changes
# Create a new branch: feature/improve-documentation
# Modify README.md (add any section)
# Stage and commit changes
# Switch back to feature/add-asset-filters
# Merge master into your feature branch
# Resolve any conflicts if they exist
```

**Task 4: Cleanup and History (15 points)**
```bash
# View the commit history in a graph format
# Delete the feature/improve-documentation branch
# Show all remote branches
# Display the last 3 commits with changes
```

---

## Professional Git Workflows Reference

### GitHub Flow (Simple)
```bash
# 1. Create branch
git checkout -b feature/new-feature

# 2. Make commits
git commit -m "Add feature"

# 3. Push and create PR
git push -u origin feature/new-feature

# 4. After PR approval, merge on web interface

# 5. Update local master
git checkout master
git pull origin master

# 6. Delete feature branch
git branch -d feature/new-feature
```

### Gitflow Workflow (Complex Projects)
```bash
# Development
git checkout develop
git checkout -b feature/new-feature
# ... work and commit ...
git checkout develop
git merge feature/new-feature

# Release
git checkout -b release/1.2.0
# ... final testing and bug fixes ...
git checkout master
git merge release/1.2.0
git tag -a v1.2.0
git checkout develop
git merge release/1.2.0

# Hotfix
git checkout master
git checkout -b hotfix/critical-bug
# ... fix and commit ...
git checkout master
git merge hotfix/critical-bug
git tag -a v1.2.1
git checkout develop
git merge hotfix/critical-bug
```

---

## Useful Git Commands Cheat Sheet

### Daily Commands
```bash
git status                          # Check status
git add .                           # Stage all changes
git commit -m "message"             # Commit with message
git push                            # Push to remote
git pull                            # Pull from remote
git checkout -b branch-name         # Create and switch to branch
```

### Viewing Information
```bash
git log --oneline --graph --all     # Visual history
git diff                            # View unstaged changes
git diff --staged                   # View staged changes
git show <commit-hash>              # Show commit details
git blame filename                  # Show who changed each line
```

### Undoing Changes
```bash
git restore filename                # Discard working changes
git restore --staged filename       # Unstage file
git reset HEAD~1                    # Undo last commit
git revert <commit-hash>            # Create commit that undoes another
```

### Advanced Commands
```bash
git stash                           # Save changes temporarily
git stash pop                       # Apply stashed changes
git cherry-pick <commit-hash>       # Apply specific commit
git rebase -i HEAD~3                # Interactive rebase last 3 commits
git clean -fd                       # Remove untracked files
```

---

## Additional Resources

- **Git Official Documentation:** https://git-scm.com/doc
- **Pro Git Book (Free):** https://git-scm.com/book/en/v2
- **Azure DevOps Git Tutorial:** https://docs.microsoft.com/azure/devops/repos/git/
- **Git Visualization:** https://git-school.github.io/visualizing-git/

---

## Grading Rubric

- **Theoretical Questions:** 20 points
- **Practical Exam:** 80 points
  - Task 1: 10 points
  - Task 2: 30 points
  - Task 3: 25 points
  - Task 4: 15 points

**Total:** 100 points

**Pass Mark:** 70 points

---

## Certificate of Completion

Upon successful completion (≥70 points), interns will receive a certificate showing proficiency in:
- Git fundamentals
- Branch management
- Team collaboration workflows
- Professional Git practices

---

**End of Training Document**

---
Son made change in README.
Toan made change in README.
Binh made some changes .

