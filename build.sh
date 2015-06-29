#! /bin/bash

[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

make html
make epub
make LATEXOPTS=' -interaction=batchmode ' latexpdf
