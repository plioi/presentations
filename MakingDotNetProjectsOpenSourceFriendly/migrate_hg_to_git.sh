#!/bin/sh

#Usage:
# ./migrate_hg_to_git LocalRepoFolderName HgSourceRepoUrl GitDestinationUrl
#
# For example:
# ./migrate_hg_to_git MyProject https://bitbucket.org/Example/myproject git@github.com:Example/MyProject.git
#
# The git destination URL should be a new, empty repository for which you have push rights.
#
# Note that the filter-branch 'quoted' script must be updated to translate specific users found in your HG project.

hg clone $2 $1
cd $1
hg bookmark -r default master
hg gexport
mv .hg/git .git
rm -rf .hg
git init
git checkout master -f
git filter-branch --env-filter '

an="$GIT_AUTHOR_NAME"
am="$GIT_AUTHOR_EMAIL"
cn="$GIT_COMMITTER_NAME"
cm="$GIT_COMMITTER_EMAIL"

if [ "$GIT_AUTHOR_NAME" = "hgjohn" ]
then
    cn="John Doe"
    cm="john@example.com"
    an="John Doe"
    am="john@example.com"
fi
if [ "$GIT_AUTHOR_NAME" = "hgjane" ]
then
    cn="Jane Doe"
    cm="jane@example.com"
    an="Jane Doe"
    am="jane@example.com"
fi

export GIT_AUTHOR_NAME="$an"
export GIT_AUTHOR_EMAIL="$am"
export GIT_COMMITTER_NAME="$cn"
export GIT_COMMITTER_EMAIL="$cm"
'

git remote add origin $3
git push origin master