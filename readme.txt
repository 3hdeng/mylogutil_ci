//=== 2018.11.11
$ ../mybash/createRepo_github.sh mylogutil
$ ../mybash/createRepo_github.sh mylogutil.tests



$ git remote add github ...
for  mylogutil and mylogutil.tests projs.



//=== "delete and re-create mylogutil_ci repo at github"

$ cd mylogutil_ci

$ ../mybash/createRepo_github.sh mylogutil_ci


$ git add *.sln *.yml
$ git commit -m "..."
$ git push github master

//===
$ git submodule add https://3hdeng@github.com/3hdeng/mylogutil.git
Adding existing repo at 'mylogutil' to the index



$ git submodule add https://3hdeng@github.com/3hdeng/mylogutil.tests.git
Cloning into 'C:/workspaces/mylogutil_ci/mylogutil.tests'...
remote: Enumerating objects: 4, done.
remote: Counting objects: 100% (4/4), done.
remote: Compressing objects: 100% (4/4), done.
remote: Total 4 (delta 0), reused 4 (delta 0), pack-reused 0
Unpacking objects: 100% (4/4), done.


//=== 

