#! /bin/bash

./pull-examples.sh
./sphinx.sh && ./htmlzip.sh && ./rsync-courseclouds.sh  && ./rsync-distributed.sh

