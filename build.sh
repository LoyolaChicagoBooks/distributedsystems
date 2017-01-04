#! /bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

rm -rf build/*

make html
#make epub
#make LATEXOPTS=' -interaction=batchmode ' latexpdf

rm -rf build/html/code
mkdir -p build/html/code

cp -Rv source/code build/html
