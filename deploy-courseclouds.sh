#! /bin/bash

./pull-examples.sh
./sphinx.sh && ./htmlzip.sh && ./rsync-all.sh 
